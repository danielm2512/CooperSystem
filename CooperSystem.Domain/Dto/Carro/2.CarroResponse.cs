using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public sealed class CarroResponse : CarroString
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }

    }
}
