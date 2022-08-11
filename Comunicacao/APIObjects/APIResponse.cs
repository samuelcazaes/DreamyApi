using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicacao.APIObjects
{
    public class APIResponse
    {
        public APIResponse() { Success = false; }
        public bool Success { get; set; }
        public object Object { get; set; }
        public string Message { get; set; }
    }
}
