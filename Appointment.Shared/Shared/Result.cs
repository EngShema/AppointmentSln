using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.result
{
    public class Result<T> where T: class,new()
    {
        public T? Obj { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
