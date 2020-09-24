using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiINCOS.Negocio;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Controllers
{
    [RoutePrefix("Consolidado")]
    public class ConsolidadoController : ApiController
    {
        private NegConsolidado _modelo;
        public ConsolidadoController()
        {
            _modelo = new NegConsolidado();
        }
        public ConsolidadoController(NegConsolidado modelo)
        {
            _modelo = modelo;
        }




        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("insertar")]
        public IHttpActionResult Insertar([FromBody]ConsolidadoTR parametro)
        {
            #region Validaciones

            if (parametro == null)
            {
                var error = "Dato requerido";
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        type = "ErrorBusinessValidation",
                        message = error
                    }))
                };
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                throw new HttpResponseException(message);
            }

            #endregion


            #region Proceso

            var result = _modelo.Registrar(parametro);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion


        }

        

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("modificar")]
        public IHttpActionResult modificar([FromBody] ConsolidadoTR param)
        {
            #region Validaciones

            if (param == null)
            {
                var error = "Dato requerido";
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        type = "ErrorBusinessValidation",
                        message = error
                    }))
                };
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                throw new HttpResponseException(message);
            }

            #endregion


            #region Proceso

            var result = _modelo.Modificar(param);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }



        [HttpGet]
        [ResponseType(typeof(List<ConsolidadoTR>))]
        [Route("listar")]
        public IHttpActionResult listar()
        {
            #region Proceso

            var result = _modelo.Listar();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }
    }
}
