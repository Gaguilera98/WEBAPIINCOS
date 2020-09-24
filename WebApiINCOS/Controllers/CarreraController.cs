using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiINCOS.Negocio;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Controllers
{
    [RoutePrefix("api/carrera")]
    public class CarreraController : ApiController
    {
        private NegCarrera _model;

        public CarreraController()
        {
            _model = new NegCarrera();
        }
        public CarreraController(NegCarrera model)
        {
            _model = model;
        }
        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("insertar")]
        public IHttpActionResult insertar([FromBody] CarreraTR param)
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

            var result = _model.Registrar(param);

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
        public IHttpActionResult modificar([FromBody] CarreraTR param)
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

            var result = _model.Modificar(param);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }


        [HttpDelete]
        [ResponseType(typeof(bool))]
        [Route("eliminar/{codigo}")]
        public IHttpActionResult eliminar(int codigo)
        {
            #region Validaciones

            if (codigo == null)
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

            var result = _model.Eliminar(codigo);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("eliminacionLOGICA/{codigo}")]
        public IHttpActionResult eliminacion(int codigo, string est)
        {
            #region Validaciones

            if (codigo == null)
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

            var result = _model.EliminaciónLogica(codigo, est);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }

        [HttpGet]
        [ResponseType(typeof(List<CarreraTR>))]
        [Route("listar")]
        public IHttpActionResult listar()
        {
            #region Proceso

            var result = _model.Listar();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }

    }
}