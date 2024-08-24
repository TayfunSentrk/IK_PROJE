using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Wrapper
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(T value)
        {
            Result = value;
        }
        public string? Message { get; set; }
        public bool? IsSuccsess { get; set; }
        public T Result { get; set; }

    }
}
