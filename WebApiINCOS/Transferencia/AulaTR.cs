using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class AulaTR
    {
        public int codigo { get; set; }
        public int cursoCodigo { get; set; }
        public int paraleloCodigo { get; set; }
        public string estado { get; set; }
    }
}