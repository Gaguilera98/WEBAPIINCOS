using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class MateriaTR
    {
        public int codigo    { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public int cod_carrera { get; set; }
    }
}