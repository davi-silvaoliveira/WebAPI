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
        public string nome_cidade { get; set; }
        public Sensacao() { }

        public Sensacao(string name, int temp_user, int temp_api, string sens_user) 
        {
            this.nome_cidade = name; this.temp_user = temp_user; this.temp_api = temp_api; this.sens_user = sens_user;
        }

        public void Inserir()
        {
            using (Connection.Database DB = new Connection.Database())
            {
                string query;
                int x = Local.VerificarLocal(this.nome_cidade);
                if(x == 0)
                {
                    Local.Inserir(this.nome_cidade);
                }

                if (this.sens_user != null)
                    query = "call nova_discrepancia_temp ('" + this.nome_cidade + "', null, " + this.temp_api + ", '" + this.sens_user + "');";
                else
                    query = "call nova_discrepancia_temp ('" + this.nome_cidade + "', " + this.temp_user + ", " + this.temp_api + ", null);";

                DB.ExecuteCommand(query);
            }
        }
    }
}
