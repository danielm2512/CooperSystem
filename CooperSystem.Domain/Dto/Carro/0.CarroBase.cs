using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public abstract class CarroBase
    {
        public string Nome { get; set; }
        public decimal Km_por_galao { get; set; }
        public int Cilindros { get; set; }
        public int Cavalor_de_forca { get; set; }
        public int Peso { get; set; }
        public int Aceleraçao { get; set; }
        public DateTime Ano { get; set; }

    }
}
