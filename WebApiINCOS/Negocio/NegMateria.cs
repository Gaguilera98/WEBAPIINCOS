using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegMateria
    {
        private Materia _materia;

        public NegMateria()
        {
            _materia = new Materia();
        }
        public int Registrar(MateriaTR param)
        {
            _materia.item.codigo = param.codigo;
            _materia.item.nombre = param.nombre;
            _materia.item.cod_carrera = param.cod_carrera;
            return _materia.Guardar();
        }
        public bool Modificar(MateriaTR param)
        {
            _materia.item.codigo = param.codigo;
            _materia.item.nombre = param.nombre;
            _materia.item.estado = param.estado;
            return _materia.Modificar();
        }
        public bool EliminaciónLogica(int cod, string esta)
        {
            _materia.item.codigo = cod;
            _materia.item.estado = esta;
            return _materia.EliminacionLogica();
        }
        public MateriaTR ObtenerM(int idParam)
        {
            _materia.item.codigo = idParam;
            _materia.Obtener(idParam);
            return _materia.item;
        }
        public List<MateriaTR> Listar()
        {
            return _materia.Listar();
        }
        public List<MateriaxCarreraTR> ListarMatxCar()
        {
            return _materia.ListarMateriaxCarrera();
        }
    }
}
