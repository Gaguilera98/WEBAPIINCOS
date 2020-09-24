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
    public class Evaluacion : Conexion
    {
        private SqlTransaction st;
        public EvaluacionTR item { get; set; }
        public Evaluacion(): base(cadenaConexion.cadena)
        {
            item= new EvaluacionTR();
    }
        public int Guardar()
        {
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Evaluacion", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombre;
                SqlCmd.Parameters.Add("pfecha", SqlDbType.DateTime).Value = item.fecha;
                SqlCmd.Parameters.Add("ptipo", SqlDbType.VarChar, 50).Value = item.tipo;
                SqlCmd.Parameters.Add("ppuntaje", SqlDbType.Int).Value = item.puntaje;
                SqlCmd.Parameters.Add("pcod_consol", SqlDbType.Int).Value = item.cod_consolidado;


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

        public bool Modificar()
        {
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Modificar_Evaluacion", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;
                SqlCmd.Parameters.Add("pfecha", SqlDbType.DateTime).Value = item.fecha;
                SqlCmd.Parameters.Add("ptipo", SqlDbType.VarChar, 50).Value = item.tipo;
                SqlCmd.Parameters.Add("pestado", SqlDbType.VarChar, 10).Value = item.estado;
            
                SqlCmd.ExecuteNonQuery();
                

                SqlCmd.Dispose();
                st.Commit();
                cerrarConexion();

            }
            catch (Exception ex)
            {
                st.Rollback();
                return false;
            }
            return true;
        }
        public bool EliminacionLogica()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Evaluacion_lo", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;
                SqlCmd.Parameters.Add("pestado", SqlDbType.VarChar, 50).Value = item.estado;


                SqlCmd.ExecuteNonQuery();

                SqlCmd.Dispose();
                st.Commit();
                cerrarConexion();

            }
            catch (Exception Ex)
            {
                st.Rollback();
                return false;
            }
            return true;
        }
        public void Obtener(int cod)
        {
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Buscar_Evaluacion]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = cod;
                item.fecha = Convert.ToDateTime(dt.Rows[0]["fecha"]);
                item.tipo = dt.Rows[0]["tipo"].ToString();
                item.estado = dt.Rows[0]["estado"].ToString();
            }
            catch (Exception Ex)
            {
            }
        }
        public List<EvaluacionTR> Listar()
        {
            List<EvaluacionTR> lPer = new List<EvaluacionTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_Evaluacion]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                   EvaluacionTR p = new EvaluacionTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    
                    p.fecha =Convert.ToDateTime(item["fecha"].ToString());
                    p.tipo = item["tipo"].ToString();
                    p.estado = item["estado"].ToString();

                    lPer.Add(p);
                }
            }
            catch (Exception Ex)
            {
                return lPer;
            }

            return lPer;
        }


    }
}