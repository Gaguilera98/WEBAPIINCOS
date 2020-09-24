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
    [RoutePrefix("AsignacionMateriaEstudiante")]
    public class AsignacionMateriaEstudianteController : ApiController
    {
        private NegAsignacionMateriaEstudiante _model;

        public AsignacionMateriaEstudianteController()
        {
            _model = new NegAsignacionMateriaEstudiante();
        }
        public AsignacionMateriaEstudianteController( NegAsignacionMateriaEstudiante modelo)
        {
            _model = modelo;
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("insertar")]
        public IHttpActionResult insertar(AsignacionMateriaEstudianteCreacionDTO param)
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

            bool result = _model.Registra(param);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion
        }
        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("eliminacionLogica/{cod}")]
        public IHttpActionResult eliminacionlog(int cod)
        {
            #region Validaciones

            if (cod == null)
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

            var result = _model.EliminLog(cod);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
            #endregion
        }
        [HttpGet]
        [ResponseType(typeof(AsignacionMateriaEstudianteTR))]
        [Route("obtener/{cod}")]
        public IHttpActionResult obtener(int cod)
        {
            #region Validaciones

            if (cod == null)
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

            var result = _model.Obtener(cod);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }
        [HttpGet]
        [ResponseType(typeof(List<AsignacionMateriaEstudianteTR>))]
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
