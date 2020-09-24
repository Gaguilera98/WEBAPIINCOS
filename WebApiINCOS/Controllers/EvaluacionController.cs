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
    [RoutePrefix("api/evaluacion")]

    public class EvaluacionController : ApiController
    {
        private NegEvaluacion _model;

        public EvaluacionController()
        {
            _model = new NegEvaluacion();
        }
        public EvaluacionController(NegEvaluacion model)
        {
            _model = model;
        }
        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("insertar")]
        public IHttpActionResult insertar([FromBody] EvaluacionCreacionDto param)
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

            var result = _model.Insertar(param);

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
        public IHttpActionResult Modificar([FromBody] EvaluacionTR param)
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
        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("EliminacionLog/{codigo}/{est}")]
        public IHttpActionResult EliminacionLog( int codigo, string est)
        {
            #region Validaciones

            if (codigo == null&& est==null)
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

            var result = _model.EliminacionLog(codigo,est);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion


        }
    }
}
