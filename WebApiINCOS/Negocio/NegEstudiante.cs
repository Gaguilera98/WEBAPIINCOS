using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegEstudiante
    {
        private Estudiante _estudiante;

        public NegEstudiante()
        {
            _estudiante = new Estudiante();
        }

        public int Registrar(EstudianteTR param)
        {
            _estudiante.item.codigo = param.codigo;
            _estudiante.item.nombres = param.nombres;

            _estudiante.item.apellido_paterno = param.apellido_paterno;
            _estudiante.item.apellido_materno = param.apellido_materno;
            _estudiante.item.cedula = param.cedula;
            

            return _estudiante.Guardar();
        }


        public bool Modificar(EstudianteTR param)
        {
            _estudiante.item.codigo = param.codigo;
            _estudiante.item.nombres = param.nombres;

            _estudiante.item.apellido_paterno = param.apellido_paterno;
            _estudiante.item.apellido_materno = param.apellido_materno;
            _estudiante.item.cedula = param.cedula;
            _estudiante.item.estado = param.estado;

            return _estudiante.Modificar();
        }
        public bool EliminaciónLogica(int para)
        {
            _estudiante.item.codigo = para;
            return _estudiante.EliminacionLogica();
        }

        public bool Eliminar(int idParam)
        {
            _estudiante.item.codigo = idParam;
            return _estudiante.Eliminar();
        }

        public EstudianteTR Obtener(int idParam)
        {
            _estudiante.item.codigo = idParam;
           
            _estudiante.Obtener(idParam);
            return _estudiante.item;
        }

        public List<EstudianteTR> Listar()
        {
            return _estudiante.Listar();
        }
    }
}
