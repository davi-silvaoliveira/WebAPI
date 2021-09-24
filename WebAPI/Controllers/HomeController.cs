using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Database;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //"Reinicia" a API, mantendo os locais já salvos
        [HttpDelete]
        [ActionName("ZerarAPI")]
        public void Zerar()
        {
            using (Connection.Database DB = new Connection.Database())
            {
                var query = "call zerar()";
                DB.ExecuteCommand(query);
            }
        }



        /// 

        [HttpPost]
        [ActionName("Send")]
        public void SendWeather([FromBody] Weather w)
        {

            if (w.cond_api == null)
                Local.ClimaCerto(w.nome_cidade);
            else
            {
                Condicao condicao = new Condicao(w.nome_cidade, w.cond_api, w.cond_user);
                condicao.Inserir();
            }

            if (w.sens_user == null)
                Local.ClimaCerto(w.nome_cidade);
            else
            {
                try
                {
                    int x;
                    x = Convert.ToInt32(w.sens_user.ToString());
                    Sensacao sensacao1 = new Sensacao(w.nome_cidade, x, w.temp_api, null);
                    sensacao1.Inserir();
                }
                catch
                {
                    Sensacao sensacao2 = new Sensacao(w.nome_cidade, 0, w.temp_api, w.sens_user);
                    sensacao2.Inserir();
                }
            }
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
