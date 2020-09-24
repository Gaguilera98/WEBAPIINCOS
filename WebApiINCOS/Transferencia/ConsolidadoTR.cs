using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class ConsolidadoTR
    {
        public int codigo{ get; set; }
        public DateTime fechaentrega { get; set; }
        public int num_pagina { get; set; }
        public string observacion { get; set; }
        public string bimestre { get; set; }

    }
}