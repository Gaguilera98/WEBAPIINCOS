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
    [RoutePrefix("api/listadoestudianteconsolidado")]
    public class ListaEstudianteConsolidadoController : ApiController
    {

        private NegListadoEstudianteConsolidado _model;

        public ListaEstudianteConsolidadoController()
        {
            _model = new NegListadoEstudianteConsolidado();
        }
        public ListaEstudianteConsolidadoController(NegListadoEstudianteConsolidado model)
        {
            _model = model;

        }




        [HttpPut]
        [ResponseType(typeof(List<ListaEstudianteConsolidadoTR>))]
        [Route("obtener")]
        public IHttpActionResult obtener([FromBody] ObtenerListaEstudianteCondolidadoTR param)
        {
            #region Validaciones

            if (param==null)
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

            var result = _model.Obtener(param);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            #endregion

        }


    }
}
