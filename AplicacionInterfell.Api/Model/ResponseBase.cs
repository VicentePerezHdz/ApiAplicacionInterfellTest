using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionInterfell.Api.Model
{
    public class ResponseBase
    {
        public bool Exito { get; set; }
        public bool Tecnico { get; set; } = false;

        public int ErroHttp { get; set; }

        public string Mensaje { get; set; }
        public string MensajeTecnico { get; set; }

        public ResponseBase()
        {
            Exito = true;
            MensajeDefault();
        }

        private void MensajeDefault()
        {
            Mensaje = "Ok";
        }

        public ResponseBase(bool exito)
        {
            Exito = exito;

            if (!Exito)
                Mensaje = "Algo salió mal, por favor intenta más tarde.";
            else
                MensajeDefault();
        }
    }
}