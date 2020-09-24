using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegResultadoEvaluacion
    {
        private ResultadoEvaluacionTR _resultado;

        public NegResultadoEvaluacion()
        {
            _resultado = new ResultadoEvaluacionTR();
    }

        //public bool Registrar(ResultadoEvaluacionCrear parametro)
        //{
        //    try
        //    {
        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            foreach (var materia in parametro.materias)
        //            {
        //                _asignacion.item = new AsignacionMateriaDocenteTR
        //                {
        //                    cod_docente = parametro.codDocente,
        //                    cod_materia = materia.codMateria,
        //                    cod_aula = parametro.codAula
        //                };
        //                _asignacion.Guardar();
        //            }

        //            scope.Complete();
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
    }
   
}