using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula23.Models
{
    public class Tenis : BaseModels
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Marca { get; set; }
    }
}