using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class EstudianteTR

    {
        public int codigo { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string cedula { get; set; }
        public string estado { get; set; }
    }
}