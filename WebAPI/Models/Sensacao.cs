using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class Sensacao
    {
        public int id { get; set; }
        public int id_cidade { get; set; }
        public int id_user { get; set; }
        public int temp_api { get; set; }
        public int  temp_user { get; set; }
        public string sens_user { get; set; }

        public Sensacao() { }

        public bool Inserir(string local, int temp_user, int temp_api)
        {
            using (Connection.Database DB = new Connection.Database())
            {
                bool bob;
                try
                {
                    var query = "call nova_discrepancia_sencacao ('" + local + "', " + temp_user + ", " + temp_api + ");";
                    DB.ExecuteCommand(query);
                    bob = true; return bob;
                }
                catch
                {
                    bob = false; return bob;
                }
            }
        }
    }
}
