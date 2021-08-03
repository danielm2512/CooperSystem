using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public abstract class OrigemBase
    {
        public string Abbr { get; set; }
        public string Country { get; set; }
    }
}
