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
    public class AsignacionMateriaDocente : Conexion
    {
        private SqlTransaction st;
        public AsignacionMateriaDocenteTR item { get; set; }

        public AsignacionMateriaDocente():base(cadenaConexion.cadena)
            {
            item = new AsignacionMateriaDocenteTR();
            }

        public int Guardar()
        {
           
            abrirConexion();              
            SqlCommand SqlCmd = new SqlCommand("Insertar_AsigncionMateriaDo", obtenerConexion());
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add("pcoddocente", SqlDbType.Int).Value = item.cod_docente;
            SqlCmd.Parameters.Add("pcodmateria", SqlDbType.Int).Value = item.cod_materia;
            SqlCmd.Parameters.Add("pcod_aula", SqlDbType.Int).Value = item.cod_aula;

            SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            item.codigo = Convert.ToInt32(SqlCmd.Parameters["pcodigo"].Value);
            SqlCmd.Dispose();
            cerrarConexion();
            return item.codigo;
        }
        public bool Modificar()
        {

            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Modificar_AsignacionMateriaDo", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = item.codigo;
                SqlCmd.Parameters.Add("pfecha", SqlDbType.DateTime).Value = item.fecha;
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
                SqlCommand SqlCmd = new SqlCommand("Eliminar_AsignacionMateriaDoLog", obtenerConexion(), st);
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
                SqlCommand SqlCmd = new SqlCommand("[Buscar_AsignacionMaterDocente]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = cod;
                item.fecha = Convert.ToDateTime(dt.Rows[0]["fecha"]);
                item.estado = dt.Rows[0]["estado"].ToString();
                item.cod_docente = Convert.ToInt32(dt.Rows[0]["cod_docente"]);
                item.cod_materia = Convert.ToInt32(dt.Rows[0]["cod_materia"]);
                item.cod_aula = Convert.ToInt32(dt.Rows[0]["cod_aula"]);
            }
            catch (Exception Ex)
            {
            }
        }
        public List<AsignacionMateriaDocenteTR> Listar()
        {
            List<AsignacionMateriaDocenteTR> lPer = new List<AsignacionMateriaDocenteTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_AsignacionMaterDocente]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    AsignacionMateriaDocenteTR p = new AsignacionMateriaDocenteTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.fecha = Convert.ToDateTime(item["fecha"]);
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