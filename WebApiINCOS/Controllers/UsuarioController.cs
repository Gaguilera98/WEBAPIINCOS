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
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private NegUsuario _model;

        public UsuarioController()
        {
            _model = new NegUsuario();
        }
        public UsuarioController(NegUsuario model)
        {
            _model = model;
        }
        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("insertar")]
        public IHttpActionResult insertar([FromBody] UsuarioTR param)
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

        [HttpGet]
        [ResponseType(typeof(UsuarioTR))]
        [Route("Login/{usuario}/{contra}")]
        public IHttpActionResult obtenerLogin(string usuario, string contra )
        {
            #region Validaciones

            if (usuario == null)
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

            var result = _model.Login(usuario,contra);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }


    }
}
