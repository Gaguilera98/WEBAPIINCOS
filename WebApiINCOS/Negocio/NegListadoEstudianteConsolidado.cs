using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINCOS.Datos;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Negocio
{
    public class NegListadoEstudianteConsolidado
    {

        private ListaEstudianteConsolidado _listado;

        public NegListadoEstudianteConsolidado()
            {

            _listado = new ListaEstudianteConsolidado();
           }
        public  List<ListaEstudianteConsolidadoTR> Obtener(ObtenerListaEstudianteCondolidadoTR p)
        {
           
     
            return _listado.Obtener(p);
        }

    }
}