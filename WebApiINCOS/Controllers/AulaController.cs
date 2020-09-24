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
    [RoutePrefix("api/aula")]
    public class AulaController : ApiController
    {
        private NegAula _model;
        public AulaController()
        {
            _model = new NegAula();
        }
        public AulaController(NegAula model)
        {
            _model = model;
        } 
        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("insertar")]
        public IHttpActionResult Insertar([FromBody] AulaCreacionDto param)
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

            int result = _model.Registrar(param);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }
    }
}
