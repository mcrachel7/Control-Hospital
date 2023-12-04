using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Proyecto_Examen.Models
{
    public class ClaseConexion
    {
        public string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = ExamenDB; Integrated Security = True";


        public IEnumerable<Hospital> getPacientes()
        {
            string sql = "select * from Hospital";
            List<Hospital> lstpaciente = new List<Hospital>();
            using (SqlConnection conexionSQL = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conexionSQL);
                conexionSQL.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Hospital pac = new Hospital();
                    pac.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    pac.Nombre = sqlDataReader["Nombre"].ToString();
                    pac.Edad = Convert.ToInt32(sqlDataReader["Edad"]);
                    pac.Ciudad = sqlDataReader["Ciudad"].ToString();
                    pac.Fecha_Consulta = Convert.ToDateTime(sqlDataReader["Fecha_Consulta"]); 
                    pac.Sintomas = sqlDataReader["Sintomas"].ToString();
                    pac.Diagnóstico = sqlDataReader["Diagnóstico"].ToString();
                    lstpaciente.Add(pac);
                }
                conexionSQL.Close();
                return lstpaciente;
            }
        }

        public int addPaciente(Hospital paciente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into Hospital values (@Nombre, @Edad, @Ciudad, @Fecha_Consulta, @Sintomas, @Diagnóstico)", con);
                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                cmd.Parameters.AddWithValue("@Ciudad", paciente.Ciudad);
                cmd.Parameters.AddWithValue("@Fecha_Consulta", paciente.Fecha_Consulta);
                cmd.Parameters.AddWithValue("@Sintomas", paciente.Sintomas);
                cmd.Parameters.AddWithValue("@Diagnóstico", paciente.Diagnóstico);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                con.Close();
                return filas;
            }
        }

        public Hospital getPaciente(int? ID)
        {
            Hospital paciente = new Hospital();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Hospital WHERE ID= " + ID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    paciente.ID = Convert.ToInt32(rdr["ID"]);
                    paciente.Nombre = rdr["Nombre"].ToString();
                    paciente.Edad = Convert.ToInt32(rdr["Edad"]);
                    paciente.Ciudad = rdr["Ciudad"].ToString();
                    paciente.Fecha_Consulta = Convert.ToDateTime(rdr["Fecha_Consulta"]);
                    paciente.Sintomas = rdr["Sintomas"].ToString();
                    paciente.Diagnóstico = rdr["Diagnostico"].ToString();
                
                }
                con.Close();
            }
            return paciente;
        }

    }
}
