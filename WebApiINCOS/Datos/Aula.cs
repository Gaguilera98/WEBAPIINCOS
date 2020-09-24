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
    public class Aula: Conexion
    {
        private SqlTransaction st;

        public AulaTR item { get; set; }

        public Aula() : base(cadenaConexion.cadena)
        {
            item = new AulaTR();
        }
        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Aula", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

               
                SqlCmd.Parameters.Add("pcod_curso", SqlDbType.Int).Value = item.cursoCodigo;
                SqlCmd.Parameters.Add("pcod_paralelo", SqlDbType.Int).Value = item.paraleloCodigo;

                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlCmd.ExecuteNonQuery();
                item.codigo = Convert.ToInt32(SqlCmd.Parameters["pcodigo"].Value);

                SqlCmd.Dispose();
                st.Commit();
                cerrarConexion();

            }
            catch (Exception Ex)
            {
                st.Rollback();
                return 0;
            }
            return item.codigo;
        }
        public void Obtener(int cod)
        {
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Buscar_Aula]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = cod;
                item.paraleloCodigo = Convert.ToInt32(dt.Rows[0]["cod_paralelo"]);
                item.cursoCodigo = Convert.ToInt32(dt.Rows[0]["cod_curso"]);
                item.estado = dt.Rows[0]["estado"].ToString();
            }
            catch (Exception Ex)
            {
            }
        }


    }
}