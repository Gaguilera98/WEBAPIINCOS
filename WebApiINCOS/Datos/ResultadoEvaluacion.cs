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
    public class ResultadoEvaluacion:Conexion
    {
        private SqlTransaction st;
        public ResultadoEvaluacionTR item { get; set; }

        public ResultadoEvaluacion():base(cadenaConexion.cadena)
        {
            item = new ResultadoEvaluacionTR();
        }
        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Resultado", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pasigmat_est", SqlDbType.VarChar, 50).Value = item.cod_asigmat_estudiante;
                SqlCmd.Parameters.Add("pcod_eval", SqlDbType.VarChar, 50).Value = item.cod_evaluacion;
                SqlCmd.Parameters.Add("pnota", SqlDbType.Int).Value = item.nota;
                SqlCmd.Parameters.Add("pobservacion", SqlDbType.VarChar, 50).Value = item.observacion;

                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlCmd.ExecuteNonQuery();
                item.codigo = Convert.ToInt32(SqlCmd.Parameters["pcodigo"].Value);

                SqlCmd.Dispose();
                st.Commit();
                cerrarConexion();

            }
            catch (Exception ex)
            {
                st.Rollback();
                return 0;

            }
            return item.codigo;
        }

    }
}