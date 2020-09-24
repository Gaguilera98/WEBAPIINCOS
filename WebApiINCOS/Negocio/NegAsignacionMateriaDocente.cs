using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegAsignacionMateriaDocente
    {
        private AsignacionMateriaDocente _asignacion;

        public NegAsignacionMateriaDocente()
        {
            _asignacion = new AsignacionMateriaDocente();
        }
        public bool Registrar(AsignacionDocenteMateriaCreacionDto parametro)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var materia in parametro.materias)
                    {
                        _asignacion.item = new AsignacionMateriaDocenteTR
                        {
                            cod_docente = parametro.codDocente,
                            cod_materia = materia.codMateria,
                            cod_aula = parametro.codAula
                        };
                        _asignacion.Guardar();
                    }

                    scope.Complete();
                }                  

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Modificar(AsignacionMateriaDocenteTR parametro)
        {
            _asignacion.item.codigo = parametro.codigo;
            _asignacion.item.fecha = parametro.fecha;
            _asignacion.item.estado = parametro.estado;

            return _asignacion.Modificar();
        }
        public bool EliminacionLog(int codigo)
        {
            _asignacion.item.codigo = codigo;
           

            return _asignacion.EliminacionLogica();
        }
        public AsignacionMateriaDocenteTR Obtener(int codigo)
        {
            _asignacion.item.codigo = codigo;
            _asignacion.Obtener(codigo);
            return _asignacion.item;
        }
        public List<AsignacionMateriaDocenteTR> Listar()
        {
            return _asignacion.Listar();
        }
    }
}