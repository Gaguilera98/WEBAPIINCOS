using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class AsignacionMateriaEstudianteTR
    {
        public int codigo { get; set; }
        public DateTime fecha { get; set; }
        public string gestion { get; set; }
        public string observacion { get; set; }
        public int cod_estudiante { get; set; }
        public int cod_asig_matdocente { get; set; }
        public string estado { get; set; }
    }
}