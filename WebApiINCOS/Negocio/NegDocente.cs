using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegDocente
    {
        private Docente _docente;

        public NegDocente()
        {
            _docente = new Docente();
        }
        public int Registrar( DocenteTR param)
        {
            _docente.item.codigo = param.codigo;
            _docente.item.nombres = param.nombres;
            _docente.item.apellido_paterno = param.apellido_paterno;
            _docente.item.apellido_materno = param.apellido_materno;
            _docente.item.cedula = param.cedula;
          

            return _docente.Guardar();
        }
        public bool Modificar(DocenteTR param)
        {
            _docente.item.codigo = param.codigo;
            _docente.item.nombres = param.nombres;
            _docente.item.apellido_paterno = param.apellido_paterno;
            _docente.item.apellido_materno = param.apellido_materno;
            _docente.item.cedula = param.cedula;
            _docente.item.estado = param.estado;

            return _docente.Modificar();

        }
        public bool EliminaciónLogica(int cod)
        {
            _docente.item.codigo = cod;
           
            return _docente.EliminacionLogica();
        }

        public bool Eliminar(int idParam)
        {
            _docente.item.codigo = idParam;
            return _docente.Eliminar();
        }

        public DocenteTR Obtener(int idParam)
        {
            _docente.item.codigo = idParam;
            _docente.Obtener(idParam);
            return _docente.item;
        }

        public List<DocenteTR> Listar()
        {
            return _docente.Listar();
        }
    }
}