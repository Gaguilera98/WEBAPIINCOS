using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class ListaEstudianteConsolidadoTR

    {
        //public int codigoDocente { get; set; }
        //public int codigoMateria { get; set; }
        //public int codigoAula { get; set; }
        public int codigoEstudiante { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public int codmateria { get; set; }


    }
    public class ObtenerListaEstudianteCondolidadoTR
    {
        public int codigoDocente { get; set; }
        public int codigoMateria { get; set; }
        public int codigoAula { get; set; }
    }
}