using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class ResultadoEvaluacionTR
    {
        public int codigo { get; set; }
        public int cod_asigmat_estudiante { get; set; }
        public int cod_evaluacion { get; set; }
        public int nota { get; set; }
        public string observacion { get; set; }
    }
   
}