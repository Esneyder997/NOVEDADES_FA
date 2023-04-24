using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace NOVEDADES_FA.BD
{
    public class conexBD
    {

        protected string sql;
        
        private string connectionString = "Data Source=DESKTOP-LBO94RD\\SQLEXPRESS; Database=NOVEDADES_FA; User ID=sa; Password=Figue_997;";

        public DataTable Consultas(string scriptConsulta)
        {
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                using (SqlCommand lector = new SqlCommand(scriptConsulta, conex))
                {
                    using (SqlDataAdapter VistaRespuesta = new SqlDataAdapter(lector))
                    {
                        DataTable tabla1 = new DataTable();
                        conex.Open();
                        VistaRespuesta.Fill(tabla1);
                        conex.Close();
                        return tabla1;
                    }
                }
            }
        }

        public string CRUD(string scriptConsulta)
        {
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                using (SqlCommand lector = new SqlCommand(scriptConsulta, conex))
                {
                    string rta = "NO";
                    conex.Open();
                    int filaAfectada = lector.ExecuteNonQuery();
                    conex.Close();
                    if (filaAfectada > 0)
                        rta = "SI";
                    return rta;
                }
            }
        }

        public int CRUDretorna(string scriptConsulta)
        {
            using (SqlConnection conex = new SqlConnection(connectionString))
            {
                using (SqlCommand lector = new SqlCommand(scriptConsulta, conex))
                {
                    int rta = 0;
                    try
                    {
                        conex.Open();
                        rta = Convert.ToInt32(lector.ExecuteScalar());
                        conex.Close();
                        return rta;
                    }
                    catch (Exception aa)
                    {
                        conex.Close();
                        return 0;
                    }
                }
            }
        }
    }
}