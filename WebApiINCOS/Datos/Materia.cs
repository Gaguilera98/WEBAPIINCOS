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
    public class Materia : Conexion
    {
        private SqlTransaction st;
        public MateriaTR item { get; set; }
        public MateriaxCarreraTR itemnu { get; set; }
        //public CarreraTR item2 { get; set; }

        public Materia() : base(cadenaConexion.cadena)
        {
             item = new MateriaTR();
            itemnu = new MateriaxCarreraTR();
        }
        public int Guardar()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Insertar_Materia", obtenerConexion(), st);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("pnombre", SqlDbType.VarChar, 50).Value = item.nombre;
                
                SqlCmd.Parameters.Add("pcod_carrera", SqlDbType.Int).Value = item.cod_carrera;

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
                SqlCommand SqlCmd = new SqlCommand("Modificar_Materia", obtenerConexion(), st);
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
        public bool EliminacionLogica()
        {
            string Resultado = null;
            try
            {
                abrirConexion();
                st = obtenerConexion().BeginTransaction("trasn");
                SqlCommand SqlCmd = new SqlCommand("Eliminar_Materia_lo", obtenerConexion(), st);
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
                SqlCommand SqlCmd = new SqlCommand("[Buscar_Materia]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("pcodigo", SqlDbType.Int).Value = cod;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];

                item.codigo = cod;
                item.nombre = dt.Rows[0]["nombre"].ToString();
                item.estado = dt.Rows[0]["estado"].ToString();

            }
            catch (Exception Ex)
            {
            }
        }
        public List<MateriaTR> Listar()
        {
            List<MateriaTR> lPer = new List<MateriaTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_Materia]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    MateriaTR p = new MateriaTR();

                    p.codigo = Convert.ToInt32((item["codigo"]));
                    p.nombre = item["nombre"].ToString();
                    p.estado = item["estado"].ToString();
                    p.cod_carrera = Convert.ToInt32((item["codigo_carrera"]));



                    lPer.Add(p);
                }
            }
            catch (Exception Ex)
            {
                return lPer;
            }

            return lPer;
        }
        public List<MateriaxCarreraTR> ListarMateriaxCarrera()
        {
            List<MateriaxCarreraTR> lPer = new List<MateriaxCarreraTR>();
            DataSet ds = new DataSet();
            try
            {
                abrirConexion();
                SqlCommand SqlCmd = new SqlCommand("[Listar_MateriasxCarrera]", obtenerConexion());
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                SqlCmd.Dispose();
                cerrarConexion();

                DataTable dt = ds.Tables[0];
                foreach (DataRow itemnu in dt.Rows)
                {
                    MateriaxCarreraTR p = new MateriaxCarreraTR();

                    p.codigo = Convert.ToInt32((itemnu["codigo"]));
                    p.nombre = itemnu["nombre"].ToString();
                    p.estado = itemnu["estado"].ToString();
                    p.cod_carrera = Convert.ToInt32((itemnu["codigo_carrera"]));
                    p.nombre_carrera = itemnu["nombre_materia"].ToString();



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