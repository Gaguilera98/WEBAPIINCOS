using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegAula
    {
        private Aula _aula;
        public NegAula()
        {
            _aula = new Aula();
        }
        public int Registrar(AulaCreacionDto parametro)
        {
            _aula.item = new AulaTR();
            _aula.item.cursoCodigo = parametro.CodigoCurso;
            _aula.item.paraleloCodigo = parametro.CodigoParalelo;
            return _aula.Guardar();
        }
    }
}