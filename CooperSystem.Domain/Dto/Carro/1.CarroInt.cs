using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public abstract class CarroInt : CarroBase
    {
        public int OrigemId { get; set; }
    }
}
