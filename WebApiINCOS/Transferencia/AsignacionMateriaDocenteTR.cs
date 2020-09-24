using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class AsignacionMateriaDocenteTR
    {
        public int codigo   { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public int cod_docente { get; set; }
        public int cod_materia { get; set; }
        public int cod_aula { get; set; }

    }
}
