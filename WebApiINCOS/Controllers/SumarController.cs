using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiINCOS.Controllers
{
    [RoutePrefix("api/calculadora")]
    public class SumarController : ApiController
    {
        [Route("sumar/{valor1}/{valor2}")]
        [HttpGet]
        public decimal Sumar(decimal valor1, decimal valor2)
        {
            decimal re = valor1 + valor2;
            return re;
        }

        [Route("restar/{valor1}/{valor2}")]
        [HttpGet]
        public decimal Restar(decimal valor1, decimal valor2)
        {
            decimal re = valor1 - valor2;
            return re;
        }
        [Route("multiplicar/{valor1}/{valor2}")]
        [HttpGet]
        public decimal Multiplicar(decimal valor1, decimal valor2)
        {
            decimal re = valor1 * valor2;
            return re;
        }


        [Route("Dividir/{valor1}/{valor2}")]
        [HttpGet]

        public decimal Dividir(decimal valor1, decimal valor2)
        {

            //var error = "no se puedde dividir entre cero";
            //if (valor1 == 0 && valor2 == 0)
            //{
            //    return error;
            //}

            //string resultado = Convert.ToString(valor1 / valor2);
            decimal re = valor1/valor2;
            return re;


        }
    }
}
