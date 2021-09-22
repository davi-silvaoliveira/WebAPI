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

        public Local Inserir()
        {
            using (Connection.Database DB = new Connection.Database())
            {
                
                var query = "call insert_local(@nome, @discrepancias, @concordancias);";
                MySqlCommand cmd = new MySqlCommand(query, DB.connection);

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = this.nome;

                cmd.Parameters.Add("@discrepancias", MySqlDbType.Int32);
                cmd.Parameters["@discrepancias"].Value = this.discrepancias;

                cmd.Parameters.Add("@concordancias", MySqlDbType.Int32);
                cmd.Parameters["@concordancias"].Value = this.concordancias;

                this.id = Convert.ToInt32(cmd.ExecuteScalar());                

                return this;
            }
        }

        public static Local BuscarLocal(string nome)
        {
            using (Connection.Database DB = new Connection.Database())
            {
                Local loc = new Local();
                string query = "select * from local where nome = '" + nome + "';";
                MySqlDataReader reader = DB.ReturnCommand(query);
                reader.Read();

                loc.id = int.Parse(reader["id"].ToString());
                loc.nome = reader["nome"].ToString();
                loc.discrepancias = int.Parse(reader["discrepancias"].ToString());
                loc.concordancias = int.Parse(reader["concordancias"].ToString());

                reader.Close(); return loc;

                /*try
                {
                    reader.Read();

                    loc.id = int.Parse(reader["id"].ToString());
                    loc.nome = reader["nome"].ToString();
                    loc.discrepancias = int.Parse(reader["discrepancias"].ToString());
                    loc.concordancias = int.Parse(reader["concordancias"].ToString());

                    reader.Close(); return loc;
                }
                catch
                {
                    reader.Close(); return null;
                }*/
            }
        }
    }
}
