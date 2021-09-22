using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Database;


namespace WebAPI.Controllers
{
    public class LocalController : Controller
    {
        /*List<Local> teste = new List<Local>(new Local[]
        {
            new Local(3, "São Paulo", 1, 0),
            new Local(2, "Rio de Janeiro", 5, 2),
            new Local(4, "Taubaté", 2, 3)
        });*/


        ///
        Local local = new Local();

        //Registrando locais na API
        [HttpPost]
        [ActionName("Insert")]
        public Local Insert([FromBody] Local loc)
        {
            return loc.Inserir();
        }

        //Buscando locais pelo ID
        [HttpGet]
        [ActionName("getLocal")]
        public Local Get(string nome)
        {
            local = Local.BuscarLocal(nome);            
            return local;
        }

        //Buscando todos os locais
        [HttpGet]
        [ActionName("ListAll")]
        public IEnumerable ListAll()
        {
            try
            {
                return local.ListarTodos();
            }
            catch
            {
                RedirectToAction("Index", "Home");
                return null;
            }
        }
    }
}
