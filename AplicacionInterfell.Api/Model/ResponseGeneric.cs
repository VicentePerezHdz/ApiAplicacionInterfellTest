using AplicacionInterfell.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionInterfell.Api
{
    public class ResponseGeneric<T> : ResponseBase where T : new()
    {
        public T Data { get; set; }
        public ResponseGeneric(T data) : base()
        {
            Data = data;
        }

        public ResponseGeneric(bool exito) : base(exito)
        {
            if (!exito)
            {
                Data = new T();
            }
        }

        public ResponseGeneric()
        {

        }
    }
}
