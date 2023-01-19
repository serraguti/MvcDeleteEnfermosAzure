using MvcDeleteEnfermosAzure.Models;
using System.Data.SqlClient;

namespace MvcDeleteEnfermosAzure.Repositories
{
    public class RepositoryEnfermos
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryEnfermos(string connectionString)
        {
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Enfermo> GetEnfermos()
        {
            string sql = "SELECT * FROM ENFERMO";
            List<Enfermo> enfermos = new List<Enfermo>();
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Enfermo enf = new Enfermo();
                enf.Inscripcion = int.Parse(this.reader["INSCRIPCION"].ToString());
                enf.Apellido = this.reader["APELLIDO"].ToString();
                enf.Direccion = this.reader["DIRECCION"].ToString();
                enf.FechaNacimiento = DateTime.Parse(this.reader["FECHA_NAC"].ToString());
                enfermos.Add(enf);
            }
            this.reader.Close();
            this.cn.Close();
            return enfermos;
        }

        public void DeleteEnfermo(int inscripcion)
        {
            string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION=@INSCRIPCION";
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            this.com.Parameters.Add(paminscripcion);
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
