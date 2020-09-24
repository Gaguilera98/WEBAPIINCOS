using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class EvaluacionTR
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public int puntaje { get; set; }
        public string estado { get; set; }
        public int cod_consolidado{ get; set; }
    }
}