using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegEvaluacion
    {
        private Evaluacion _evaluacion;

        public NegEvaluacion()
        {
            _evaluacion = new Evaluacion();
        }
        public int Insertar(EvaluacionCreacionDto parametro)
        {
            _evaluacion.item.nombre = parametro.Nombre;
            _evaluacion.item.fecha = parametro.Fecha;
            _evaluacion.item.tipo = parametro.Tipo;
            _evaluacion.item.puntaje = parametro.Puntaje;
            _evaluacion.item.cod_consolidado = parametro.Codigo_consolidado;
            return _evaluacion.Guardar();
        }
        public bool Modificar(EvaluacionTR parametro)
        {
            _evaluacion.item.codigo = parametro.codigo;
            _evaluacion.item.fecha = parametro.fecha;
            _evaluacion.item.tipo = parametro.tipo;
            _evaluacion.item.estado = parametro.estado;
            return _evaluacion.Modificar();

        }

        public bool EliminacionLog(int cod, string est)
        {
            _evaluacion.item.codigo = cod;
            _evaluacion.item.estado = est;
            return _evaluacion.EliminacionLogica();

        }

        public EvaluacionTR Obtener(int cod)
        {
            _evaluacion.item.codigo = cod;
            _evaluacion.Obtener(cod);
            return _evaluacion.item;

        }

        public List<EvaluacionTR> Listar()
            {
            return _evaluacion.Listar();
        }

    }
}

