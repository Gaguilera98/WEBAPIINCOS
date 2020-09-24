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
    public class Carrera : Conexion
    {
        private SqlTransaction st;
        public CarreraTR item { get; set; }

        public Carrera() : base(cadenaConexion.cadena)
            {
            item = new CarreraTR();
            }

        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Carrera_p", obtenerConexion(), st);
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
                SqlCommand SqlCmd = new SqlCommand("Modificar_Carrera_p", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int, 50).Value = item.codigo;
                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombre;
                SqlCmd.Parameters.Add("pestado", SqlDbType.VarChar, 10).Value = item.estado;

                

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

        public bool Eliminar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Carrera", obtenerConexion(), st);
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
        public bool EliminacionLogica()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Elimar_Carrera_logica", obtenerConexion(), st);
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
        public List<CarreraTR> Listar()
        {
            List<CarreraTR> lPer = new List<CarreraTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_Carrera]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    CarreraTR p = new CarreraTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.nombre = item["nombre"].ToString();
                   
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