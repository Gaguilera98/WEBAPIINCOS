using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiINCOS.Transferencia
{
    public class AsignacionDocenteMateriaCreacionDto
    {
        public int codDocente { get; set; }
        public List<AsignacionDocenteMateriaCreacionDtoMaterias> materias { get; set; }
        public int codAula { get; set; }
    }

    public class AsignacionDocenteMateriaCreacionDtoMaterias
    {
        public int codMateria { get; set; }
    }

}