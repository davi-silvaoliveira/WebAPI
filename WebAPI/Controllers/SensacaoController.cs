using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Database;

namespace WebAPI.Controllers
{
    public class SensacaoController : Controller
    {
        Sensacao sensacao = new Sensacao();

        [HttpPost]
        [ActionName("Insert")]
        public bool Insert(string local, int temp_user, int temp_api)
        {
                return sensacao.Inserir(local, temp_user, temp_api);
        }
    }
}
