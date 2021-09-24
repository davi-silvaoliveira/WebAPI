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
        [HttpPost]
        [ActionName("insertTemp")]
        public void Insert([FromBody] Sensacao feels)
        {
            feels.Inserir();
        }
    }
}
