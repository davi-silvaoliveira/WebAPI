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
        List<Local> teste = new List<Local>(new Local[]
        {
            new Local(3, "São Paulo", 1, 0),
            new Local(2, "Rio de Janeiro", 5, 2),
            new Local(4, "Taubaté", 2, 3)
        });

        Local local = new Local();

        [HttpGet]
        [ActionName("ListAll")]
        public IEnumerable ListAll()
        {
            return local.ListarTodos();
            /*try
            {
                return local.ListarTodos();
            }
            catch
            {
                RedirectToAction("Index", "Home");
                return null;
            }*/
        }

        /*[HttpGet]
        [ActionName("getLivro")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1\n", "value2\n" };
        }*/

        /*public Local Get(int id)
        {
            var local = locais.FirstOrDefault((p) => p. == id);
            if (livro == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            //locais.
            return livro;
        }*/
    }
}
