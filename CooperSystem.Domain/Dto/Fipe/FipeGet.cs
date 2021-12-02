using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto.Fipe
{
    public sealed class FipeGet
    {
        public int Id { get; set; }
        public string NomeCarro { get; set; }
        public DateTime Ano { get; set; }
        public string Valor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
