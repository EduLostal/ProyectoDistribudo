using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace CambioMoneda.Models
{
    public class Cambio
    {
        public string MonedaDestino { get; set; }

        public string MonedaOrigen { get; set; }

        public decimal Moneda {  get; set; }
                       

    }
}