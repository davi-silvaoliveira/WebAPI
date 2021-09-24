using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Weather
    {
        public int temp_api { get; set; }
        public string sens_user { get; set; }
        public string nome_cidade { get; set; }
        public string cond_api { get; set; }
        public string cond_user { get; set; }
    }
}
