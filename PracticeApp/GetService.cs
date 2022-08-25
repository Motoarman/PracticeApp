using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApp
{
    public class GetService
    {
        private static string _Datasource = "myserver300.database.windows.net";
        private static string _Username = "Arman15411";
        private static string _Password = "M8$tek23";
        private static string _Database = "mydatabase";

        public SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = _Datasource;
            _builder.UserID = _Username;
            _builder.Password = _Password;
            _builder.InitialCatalog = _Database;

            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Details> GetDetails()
        {
            SqlConnection conn = GetConnection();

            List<Details> _Details = new List<Details>();

            string Statement = "select * from Details";

            conn.Open();

            SqlCommand cmd = new SqlCommand(Statement, conn);

            using (SqlDataReader Reader = cmd.ExecuteReader())
            {
                while(Reader.Read())
                {
                    Details details = new Details()
                    {
                        Id = Reader.GetInt32(0),
                        Name = Reader.GetString(1)

                    };
                    _Details.Add(details);
                }
            }

            conn.Close();

            return _Details;
        }
    }
}
