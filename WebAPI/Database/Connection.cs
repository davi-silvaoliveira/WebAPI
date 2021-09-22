using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebAPI.Database
{
    public class Connection
    {
        public class Database : IDisposable
        {
            public MySqlConnection connection;

            public Database()
            {
                connection = new MySqlConnection("server = host.docker.internal; port = 3308; database = web_api; user id = root; password = root");
                //connection = new MySqlConnection("server = localhost; database = web_api; user id = root; password = root");
                connection.Open();
            }

            public void ExecuteCommand(string query)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }

            public MySqlDataReader ReturnCommand(string query)
            {
                var command = new MySqlCommand(query, connection);
                return command.ExecuteReader();
            }

            public void Dispose()
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
