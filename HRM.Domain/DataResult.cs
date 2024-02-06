using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain
{
    public class DataResult<T> where T : class
    {
        public T? Data { get; set; }
        public bool Success { get; set; }  = false;
        public string Message { get; set; } = string.Empty;
        public DataResult() { }
        public DataResult(bool success, string message, T? data)
        {
            Data = data;
            Success = success;
            Message = message;
        }       
    }
}
