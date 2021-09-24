using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Database;

namespace WebAPI.Controllers
{
    public class CondicaoController : Controller
    {
        [HttpPost]
        [ActionName("insertCond")]
        public void Insert([FromBody] Condicao cond)
        {
            cond.Inserir();
        }
    }
}
