using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegCarrera
    {

        private Datos.Carrera _carrera;

    public NegCarrera()
        {
            _carrera = new Datos.Carrera();
        }
    public int Registrar (CarreraTR param)
        {
            _carrera.item.codigo = param.codigo;
            _carrera.item.nombre = param.nombre;
            

            return _carrera.Guardar();
        }

        public bool Modificar(CarreraTR param)
        {
            _carrera.item.codigo = param.codigo;
            _carrera.item.nombre = param.nombre;
            _carrera.item.estado = param.estado;

            return _carrera.Modificar();
        }

        public bool EliminaciónLogica(int cod, string esta)
        {
            _carrera.item.codigo = cod;
            _carrera.item.estado = esta;
            return _carrera.EliminacionLogica();
        }

        public bool Eliminar (int param)
        {
            _carrera.item.codigo = param;

            return _carrera.Eliminar();
        }
        public List<CarreraTR> Listar()
        {
            return _carrera.Listar();
        }
    }
}