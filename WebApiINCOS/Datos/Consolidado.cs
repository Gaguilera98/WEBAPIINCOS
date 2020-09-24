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
    public class Consolidado:Conexion
    {
        private SqlTransaction st;
        public ConsolidadoTR item { get; set; }

        public Consolidado():base(cadenaConexion.cadena)
        {
            item = new ConsolidadoTR();
        }
        public int Guardar()
        {
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Consolidado", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pfechaentrega", SqlDbType.DateTime).Value = item.fechaentrega;
                SqlCmd.Parameters.Add("pnumpag", SqlDbType.Int).Value = item.num_pagina;
                SqlCmd.Parameters.Add("pobservacion", SqlDbType.VarChar,50).Value = item.observacion;
                SqlCmd.Parameters.Add("pbimestre", SqlDbType.VarChar).Value = item.bimestre;


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
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Modificar_Consolidado", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int, 50).Value = item.codigo;
                SqlCmd.Parameters.Add("pfecha_entrega", SqlDbType.VarChar, 50).Value = item.fechaentrega;
                SqlCmd.Parameters.Add("pnumpag", SqlDbType.VarChar, 10).Value = item.num_pagina;
                SqlCmd.Parameters.Add("pobservacion", SqlDbType.VarChar, 10).Value = item.observacion;
                SqlCmd.Parameters.Add("pbimestre", SqlDbType.VarChar, 10).Value = item.bimestre;




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
        public List<ConsolidadoTR> Listar()
        {
            List<ConsolidadoTR> lPer = new List<ConsolidadoTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_Consolidado]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    ConsolidadoTR p = new ConsolidadoTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.num_pagina = Convert.ToInt32((item["num_pagina"]));
                    p.fechaentrega = Convert.ToDateTime(item["fecha_entrega"]);
                    p.observacion = item["observacion"].ToString();
                    p.bimestre= item["bimestre"].ToString();

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