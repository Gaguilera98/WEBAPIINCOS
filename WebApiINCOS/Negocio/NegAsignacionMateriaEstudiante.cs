using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegAsignacionMateriaEstudiante
    {
        private AsignacionMateriaEstudiante _asigestudiante;

        public NegAsignacionMateriaEstudiante()
        {
            _asigestudiante = new AsignacionMateriaEstudiante();
        }

        public bool Registra(AsignacionMateriaEstudianteCreacionDTO parametro)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var asignacion in parametro.Asignaciones)
                    {

                        _asigestudiante.item = new AsignacionMateriaEstudianteTR
                        {
                            gestion = parametro.Gestion,
                            observacion = parametro.Observacion,
                            cod_estudiante = parametro.Cod_Estudiante,
                            cod_asig_matdocente = asignacion.Cod_Asig_MatDocente
              
                        };

                        _asigestudiante.Guardar();
                    }
                    scope.Complete();


                }
                return true;
            }
            catch (Exception e)
            {
                return false;

            }

        }
        public bool EliminLog(int cod)
        {
            _asigestudiante.item.codigo = cod;
            return _asigestudiante.EliminacionLogica();

        }
        public AsignacionMateriaEstudianteTR Obtener(int codigo)
        {
            _asigestudiante.item.codigo = codigo;
            _asigestudiante.Obtener(codigo);
            return _asigestudiante.item;
        }

        public List<AsignacionMateriaEstudianteTR> Listar()
        {
            return _asigestudiante.Listar();
        }


    }
    }
