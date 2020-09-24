using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegConsolidado
    {
        private Consolidado _consol; 

        public NegConsolidado()
        {
            _consol = new Consolidado();
        }
        public int Registrar(ConsolidadoTR param)
        {
            _consol.item.codigo = param.codigo;
            _consol.item.fechaentrega = param.fechaentrega;
            _consol.item.num_pagina = param.num_pagina;
            _consol.item.observacion = param.observacion;
            _consol.item.bimestre = param.bimestre;
            return _consol.Guardar();
        }
        public bool Modificar(ConsolidadoTR param)
        {
            _consol.item.codigo = param.codigo;
            _consol.item.fechaentrega = param.fechaentrega;
            _consol.item.num_pagina = param.num_pagina;
            _consol.item.observacion = param.observacion;
            _consol.item.bimestre = param.bimestre;
            return _consol.Modificar();
        }
        public List<ConsolidadoTR> Listar()
        {
            return _consol.Listar();
        }
    }
}