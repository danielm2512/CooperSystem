using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto.Fipe
{
    public abstract class FipeBase
    {
            public string NomeCarro { get; set; }
            public string Valor { get; set; }
            public DateTime Ano { get; set; }

        }
    }

