using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCompromisso.Models
{
    public class Compromisso
    {
        public int Id{get; set; }
        public string Descricao{get; set; }
        public string Local{get; set; }
        public DateTime Data{get; set; }
        public bool Realizado{get; set; }

    }
}
