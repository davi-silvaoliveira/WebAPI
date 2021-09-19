using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class Local
    {
        public int id { get; set; }
        public string nome  { get; set; }
        public int discrepancias  { get; set; }
        public int concordancias  { get; set; }

        public Local() { }

        public Local(int id, string nome, int discrepancias,int concordancias)
        {
            this.nome = nome; this.discrepancias = discrepancias; this.concordancias = concordancias;
            this.id = id;
        }

        public List<Local> ListarTodos()
        {
            using (Connection.Database DB = new Connection.Database())
            {
                var query = "select * from local;";
                var retorno = DB.ReturnCommand(query);
                return ListaLocais(retorno);
            }
        }

        public List<Local> ListaLocais(MySqlDataReader retorno)
        {
            var locais = new List<Local>();
            while (retorno.Read())
            {
                var listaDeLocais = new Local()
                {
                    id = int.Parse(retorno["id"].ToString()),
                    nome = retorno["nome"].ToString(),
                    discrepancias = int.Parse(retorno["discrepancias"].ToString()),
                    concordancias = int.Parse(retorno["concordancias"].ToString()),
                };
                locais.Add(listaDeLocais);
            }
            retorno.Close();
            return locais;
        }
    }
}
