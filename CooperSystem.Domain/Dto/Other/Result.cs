using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperSystem.Domain.Dto
{
    public class Result<T>
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public int Total { get; set; }
        public T Data { get; set; }
    }
}
