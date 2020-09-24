using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegCurso
    {
        private Curso _curso; 

        public NegCurso()
        {
            _curso = new Curso();
        }
        public int Registrar(CursoTR param)
        {
            _curso.item.codigo = param.codigo;
            _curso.item.nombre = param.nombre;
            _curso.item.estado = param.estado;
            return _curso.Guardar();
        }
        public bool Modificar(CursoTR param)
        {
            _curso.item.codigo = param.codigo;
            _curso.item.nombre = param.nombre;
            _curso.item.estado = param.estado;
            return _curso.Modificar();
        }
        public bool EliminaciónLogica(int cod, string esta)
        {
            _curso.item.codigo = cod;
            _curso.item.estado = esta;
            return _curso.EliminacionLogica();
        }
        public bool Eliminar(int idParam)
        {
            _curso.item.codigo = idParam;
            return _curso.Eliminar();
        }
        public CursoTR ObtenerC(int idParam)
        {
            _curso.item.codigo = idParam;
            _curso.Obtener(idParam);
            return _curso.item;
        }
        public List<CursoTR> Listar()
        {
            return _curso.Listar();
        }
    }
}