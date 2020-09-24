using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class AsignacionMateriaEstudianteCreacionDTO
    {
        public string Gestion { get; set; }
        public string Observacion { get ; set; }
        public int Cod_Estudiante { get; set; }
        public List<AsignacionMateriasDocente> Asignaciones { get; set; }
      

    }
    public class AsignacionMateriasDocente
    {
        public int  Cod_Asig_MatDocente{ get; set; }
    }
}