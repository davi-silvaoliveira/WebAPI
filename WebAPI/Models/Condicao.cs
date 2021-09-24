using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class Condicao
    {
        public int id { get; set; }
        public int id_cidade { get; set; }
        public int id_user { get; set; }
        public string cond_api { get; set; }
        public string cond_user { get; set; }
        public string nome_cidade { get; set; }
        public Condicao(string name, string cond_api, string cond_user) 
        {
            this.nome_cidade = name; this.cond_api = cond_api; this.cond_user = cond_user;
        }

        public void Inserir()
        {
            using (Connection.Database DB = new Connection.Database())
            {
                string query;
                int x = Local.VerificarLocal(this.nome_cidade);
                if (x == 0)
                {
                    Local.Inserir(this.nome_cidade);
                }
                    query = "call nova_discrepancia_cond ('" + this.nome_cidade + "', '" + this.cond_api + "', '" + this.cond_user + "');";

                DB.ExecuteCommand(query);
            }
        }
    }
}
