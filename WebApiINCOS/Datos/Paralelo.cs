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
    public class Paralelo: Conexion
    {
        private SqlTransaction st;

        public ParaleloTR item { get; set; }

        public Paralelo(): base(cadenaConexion.cadena)
        {
            item = new ParaleloTR();
        }


        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Paralelo", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombre;
               

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
        public bool Modificar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Modificar_Paralelo", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;
                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombre;

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

        //public bool EliminacionLogica()
        //{
        //    string Resultado = null;
        //    try
        //    {
        //        abrirConexion();
        //        st = obtenerConexion().BeginTransaction("trasn");
        //        SqlCommand SqlCmd = new SqlCommand("Eliminar_Estu_lo_p", obtenerConexion(), st);
        //        SqlCmd.CommandType = CommandType.StoredProcedure;
        //        SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;
        //        SqlCmd.Parameters.Add("pestado", SqlDbType.VarChar, 50).Value = item.estado;


        //        SqlCmd.ExecuteNonQuery();

        //        SqlCmd.Dispose();
        //        st.Commit();
        //        cerrarConexion();

        //    }
        //    catch (Exception Ex)
        //    {
        //        st.Rollback();
        //        return false;
        //    }
        //    return true;
        //}
        public bool Eliminar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Paralelo", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;

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
                SqlCommand SqlCmd = new SqlCommand("[Buscar_Paralelo]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = cod;
                item.nombre = dt.Rows[0]["nombre"].ToString();
              
            }
            catch (Exception Ex)
            {
            }
        }
        public List<ParaleloTR> Listar()
        {
            List<ParaleloTR> lPer = new List<ParaleloTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_Paralelo]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    ParaleloTR p = new ParaleloTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.nombre = item["nombre"].ToString();
                  
                 

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