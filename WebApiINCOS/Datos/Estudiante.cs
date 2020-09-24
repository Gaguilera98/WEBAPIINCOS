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
    public class Estudiante : Conexion
    {
        private SqlTransaction st;

        public EstudianteTR item { get; set; }

     

        public Estudiante() : base(cadenaConexion.cadena)
        {
            item = new EstudianteTR();
        }



        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Estudiante_p", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                
                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombres;
                SqlCmd.Parameters.Add("papellido_paterno", SqlDbType.VarChar, 50).Value = item.apellido_paterno;
                SqlCmd.Parameters.Add("papellido_materno", SqlDbType.VarChar, 50).Value = item.apellido_materno;
                SqlCmd.Parameters.Add("pcedula", SqlDbType.VarChar, 50).Value = item.cedula;
               

                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlCmd.ExecuteNonQuery();
                item.codigo= Convert.ToInt32(SqlCmd.Parameters["pcodigo"].Value);

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
                SqlCommand SqlCmd = new SqlCommand("Modificar_Estu_p", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;
                SqlCmd.Parameters.Add("pnombres", SqlDbType.VarChar, 50).Value = item.nombres;
                SqlCmd.Parameters.Add("papellido_paterno", SqlDbType.VarChar, 50).Value = item.apellido_paterno;
                SqlCmd.Parameters.Add("papellido_materno", SqlDbType.VarChar, 50).Value = item.apellido_materno;
                SqlCmd.Parameters.Add("pcedula", SqlDbType.VarChar, 50).Value = item.cedula;
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
        public bool EliminacionLogica()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Estu_lo_p", obtenerConexion(), st);
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

        public bool Eliminar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Estu_p", obtenerConexion(), st);
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
                SqlCommand SqlCmd = new SqlCommand("[Obtener_Estudiante_p]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
          
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo =cod;
                item.nombres = dt.Rows[0]["nombre"].ToString();
                item.apellido_paterno = dt.Rows[0]["apellido_paterno"].ToString();
                item.apellido_materno = dt.Rows[0]["apellido_materno"].ToString();
                item.cedula= dt.Rows[0]["cedula"].ToString();
                item.estado = dt.Rows[0]["estado"].ToString();
            }
            catch (Exception Ex)
            {
            }
        }


        public List<EstudianteTR> Listar()
        {
            List<EstudianteTR> lPer = new List<EstudianteTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_Estudiante]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                  EstudianteTR p = new EstudianteTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.nombres = item["nombre"].ToString();
                    p.apellido_paterno = item["apellido_paterno"].ToString();
                    p.apellido_materno = item["apellido_materno"].ToString();
                    p.cedula = item["cedula"].ToString();
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