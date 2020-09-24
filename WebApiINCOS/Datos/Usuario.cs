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
    public class Usuario : Conexion 
    {
        private SqlTransaction st;

        public UsuarioTR item { get; set; }
        

        public Usuario() : base(cadenaConexion.cadena)
        {
            this.item = new UsuarioTR();
        }
        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Usuario", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pusuario", SqlDbType.VarChar, 50).Value = item.usuario;
                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombre;
                SqlCmd.Parameters.Add("papellido_paterno", SqlDbType.VarChar, 50).Value = item.apellido_paterno;
                SqlCmd.Parameters.Add("papellido_materno", SqlDbType.VarChar, 50).Value = item.apellido_materno;
                SqlCmd.Parameters.Add("pcontrasena", SqlDbType.VarChar, 50).Value = item.contrasena;
                SqlCmd.Parameters.Add("pestado", SqlDbType.VarChar, 50).Value = item.estado;

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

        public void Obtenerlogin(string vusuario, string vcontrasena)
        {
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Obtener_login]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pusuario", SqlDbType.VarChar,50).Value =vusuario;
                SqlCmd.Parameters.Add("pcontraseña", SqlDbType.VarChar,50).Value = vcontrasena;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = Convert.ToInt32(dt.Rows[0]["codigo"]);
                item.usuario = dt.Rows[0]["usuario"].ToString();
                item.nombre = dt.Rows[0]["nombre"].ToString();
                item.apellido_paterno = dt.Rows[0]["apellido_paterno"].ToString();
                item.apellido_materno = dt.Rows[0]["apellido_materno"].ToString();
                item.estado = dt.Rows[0]["estado"].ToString();
            }
            catch (Exception Ex)
            {
            }
        }
    }
}