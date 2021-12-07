using CooperSystem.Domain.Dto.Fipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public abstract class CarroString : CarroBase
    {
        public OrigemResponse Origem { get; set; }
        public FipeResponse Fipe { get; set; }
    }
}
