﻿using Newtonsoft.Json;
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
    [RoutePrefix("api/curso")]
    public class CursoController: ApiController
    {
        private NegCurso _model;
        public CursoController()
        {
            _model = new NegCurso();
        }

        public CursoController(NegCurso model)
        {
            _model = model;
        }
        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("insertar")]
        public IHttpActionResult insertar([FromBody] CursoTR param)
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
        public IHttpActionResult modificar([FromBody] CursoTR param)
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
        [Route("eliminacion/{codigo}")]
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
        [ResponseType(typeof(CursoTR))]
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

            var result = _model.ObtenerC(cod);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }


        [HttpGet]
        [ResponseType(typeof(List<CursoTR>))]
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