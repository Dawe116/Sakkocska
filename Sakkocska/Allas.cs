using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakkocska
{
    public class Allas
    {
        public int Id { get; set; }
        public string  Vilagos { get; set; }
        public string Sotet { get; set; }
        public string[,] Tabla { get; set; }
        public bool VilagosJon { get; set; }
        public DateTime? MentesiIdo { get; set; }


    }
}
