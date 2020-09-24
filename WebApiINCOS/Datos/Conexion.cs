using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
/// 
namespace WebApi.Datos
{
    public class Conexion
    {
        private SqlConnection cn;

        public Conexion()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //        

            string cnString = @"Data Source=GIORDANY\SQLEXPRESS;Initial Catalog=INCOS;Persist Security Info=True;User ID=Giordany;Password=123456;";
            cn = new SqlConnection(cnString);

        }

        protected virtual void abrirConexion()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al establecer conexión con el servidor de base de datos. " + ex.Message);
            }
        }

        protected virtual void cerrarConexion()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión con el servidor de base de datos. " + ex.Message);
            }
        }

        protected virtual SqlConnection obtenerConexion()
        {
            return cn;
        }
    }
}
