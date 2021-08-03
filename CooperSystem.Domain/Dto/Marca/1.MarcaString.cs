using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public abstract class MarcaString : MarcaBase
    {
        public OrigemResponse origem { get; set; }
    }
}
