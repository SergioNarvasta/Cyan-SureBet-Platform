using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BEOCReferenciaCompra
    {
        public string Cuenta_Corriente { get; set; }
        public DateTime Fecha { get; set; }
        public double Imp_Nacional { get; set; }
        public double Imp_Dolar { get; set; }
    }
}
