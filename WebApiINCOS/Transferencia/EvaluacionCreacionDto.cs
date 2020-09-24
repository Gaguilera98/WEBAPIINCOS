using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class EvaluacionCreacionDto
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int Puntaje { get; set; }
        public int Codigo_consolidado { get; set; }
     }
 
}