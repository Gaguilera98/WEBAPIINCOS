using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class ResultadoEvaluacionCrearDto
    {
            public List< AsignacionesEstudiantes > Asignaciones { get; set; }
            public List<Evaluaciones>Evaluaciones         { get; set; }
            public int Nota                   { get; set; }
            public string Observacion         { get; set; }
 
    }

    public class AsignacionesEstudiantes
    {
        public int Cod_Asigmat_Est { get; set; }
    }
    public class Evaluaciones
    {
        public int codigo { get; set; }
    }
}