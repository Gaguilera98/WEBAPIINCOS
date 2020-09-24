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
    public class AsignacionMateriaEstudiante: Conexion
    {

        private SqlTransaction st;
        public AsignacionMateriaEstudianteTR item { get; set; }

        public AsignacionMateriaEstudiante(): base(cadenaConexion.cadena)
        {
            item = new AsignacionMateriaEstudianteTR();
        }

        public int Guardar()
        {

            abrirConexion();
            SqlCommand SqlCmd = new SqlCommand("Insertar_Asig_Materia_Estudiante", obtenerConexion());
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add("pgestion", SqlDbType.VarChar, 50).Value = item.gestion;
            SqlCmd.Parameters.Add("pobservacion", SqlDbType.VarChar, 50).Value = item.observacion;
            SqlCmd.Parameters.Add("pcodestudiante", SqlDbType.Int).Value = item.cod_estudiante;
            SqlCmd.Parameters.Add("pcodasign_mater_docente", SqlDbType.Int).Value = item.cod_asig_matdocente;
         

            SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            item.codigo = Convert.ToInt32(SqlCmd.Parameters["pcodigo"].Value);
            SqlCmd.Dispose();
            cerrarConexion();
            return item.codigo;
        }
        public bool EliminacionLogica()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Asign_MateriaEstu_log", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcod", SqlDbType.Int).Value = item.codigo;



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
                SqlCommand SqlCmd = new SqlCommand("[Buscar_AsigMaterEst]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = cod;
                item.fecha = Convert.ToDateTime(dt.Rows[0]["fecha"]);
                item.gestion = dt.Rows[0]["gestion"].ToString();
                item.observacion = dt.Rows[0]["observacion"].ToString();
                item.cod_estudiante = Convert.ToInt32(dt.Rows[0]["cod_estudiante"]);
                item.cod_asig_matdocente = Convert.ToInt32(dt.Rows[0]["cod_asig_materia_docente"]);
                item.estado = dt.Rows[0]["estado"].ToString();
               
            }
            catch (Exception Ex)
            {
            }
        }

        public List<AsignacionMateriaEstudianteTR> Listar()
        {
            List<AsignacionMateriaEstudianteTR> lPer = new List<AsignacionMateriaEstudianteTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_AsignacionMaterEstudiante]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    AsignacionMateriaEstudianteTR p = new AsignacionMateriaEstudianteTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.fecha = Convert.ToDateTime(item["fecha"]);
                    p.gestion = item["gestion"].ToString();
                    p.observacion = item["observacion"].ToString();
                    p.cod_estudiante = Convert.ToInt32(item["cod_estudiante"]);
                    p.cod_asig_matdocente = Convert.ToInt32(item["cod_asig_materia_docente"]);
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