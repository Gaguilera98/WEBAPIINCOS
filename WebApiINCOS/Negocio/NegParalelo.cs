using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegParalelo
    {
        private Paralelo _paralelo;

        public NegParalelo()
        {
            _paralelo = new Paralelo();
        }
        public int Registrar(ParaleloTR param)
        {
            _paralelo.item.codigo = param.codigo;
            _paralelo.item.nombre = param.nombre;
            return _paralelo.Guardar();

        }

        public bool Modificar(ParaleloTR param)
        {
            _paralelo.item.codigo = param.codigo;
            _paralelo.item.nombre = param.nombre;
            return _paralelo.Modificar();
        }
        //public bool EliminaciónLogica(int cod, string esta)
        //{
        //    _paralelo.item.codigo = cod;
        //    _paralelo.item.estado = esta;
        //    return _paralelo.EliminacionLogica();
        //}
        public bool Eliminar(int idParam)
        {
            _paralelo.item.codigo = idParam;
            return _paralelo.Eliminar();
        }
        public ParaleloTR ObtenerP(int idParam)
        {
            _paralelo.item.codigo = idParam;
            _paralelo.Obtener(idParam);
            return _paralelo.item;
        }
        public List<ParaleloTR> Listar()
        {
            return _paralelo.Listar();
        }
    }

}