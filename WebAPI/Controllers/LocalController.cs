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


        ///
      
        
        Local local = new Local();

        //Registrando locais na API
        [HttpPost]
        [ActionName("Insert")]
        public Local Insert([FromBody] Local loc)
        {
            return loc.Inserir();
        }

        //Atualizando registro de concordâncias
        [HttpPut]
        [ActionName("ClimaOK")]
        public bool Insert([FromBody] string nome)
        {
            try
            {
                Local.ClimaCerto(nome);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Buscando locais pelo nome
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
