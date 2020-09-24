using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class UsuarioTR
    { public int codigo { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }

    }
}