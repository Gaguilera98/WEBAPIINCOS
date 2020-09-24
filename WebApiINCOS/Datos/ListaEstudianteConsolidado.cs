using Sqlsever.Acceso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiINCOS.Transferencia;

namespace WebApiINCOS.Datos
{
    public class ListaEstudianteConsolidado:Conexion
    {
        private SqlTransaction st;
        
        public ListaEstudianteConsolidadoTR item { get; set; }

        public ListaEstudianteConsolidado():base(cadenaConexion.cadena)
        {
            item = new ListaEstudianteConsolidadoTR();
        }

        public List<ListaEstudianteConsolidadoTR> Obtener(ObtenerListaEstudianteCondolidadoTR pa)
        {
            List<ListaEstudianteConsolidadoTR> re = new List<ListaEstudianteConsolidadoTR>();
            DataSet ds = new DataSet();

            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[ListarEstudiantesConsolidado]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcoddocente", SqlDbType.Int).Value = pa.codigoDocente;
                SqlCmd.Parameters.Add("pcodmateria", SqlDbType.Int).Value = pa.codigoMateria;
                SqlCmd.Parameters.Add("pcodaula", SqlDbType.Int).Value = pa.codigoAula;

                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    ListaEstudianteConsolidadoTR p = new ListaEstudianteConsolidadoTR();
                    ObtenerListaEstudianteCondolidadoTR pp = new ObtenerListaEstudianteCondolidadoTR();

                    //pp.codigoDocente = Convert.ToInt32((item["codigo"]));
                    //pp.codigoMateria = Convert.ToInt32((item["cod_materia"]));
                    //pp.codigoAula = Convert.ToInt32((item["Cod_Aula"]));
                    pp.codigoDocente = pa.codigoDocente;
                    pp.codigoMateria = pa.codigoMateria;
                    pp.codigoAula = pa.codigoAula;
                    p.codigoEstudiante = Convert.ToInt32((item["cod_estudiante"]));
                    p.nombre = item["Nombre_Estudiante"].ToString();
                    p.apellido_paterno = item["apellido_paterno"].ToString();
                    p.apellido_materno = item["apellido_materno"].ToString();
                    p.codmateria = Convert.ToInt32((item["cod_materia"]));

                    re.Add(p);
                }

                
                //item.cedula = dt.Rows[0]["cedula"].ToString();
                //item.estado = dt.Rows[0]["estado"].ToString();
            }
            catch (Exception Ex)
            {
                return re;
            }
            return re;
        }

    }
}