using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BEOCDetalleReq
    {
        public string Requerimiento {get; set;}
        public string Originado_por {get; set;}
        public int Cantidad_En_OC {get; set;}
        public DateTime Fecha_Entrega {get; set;}
        public string Pedido {get; set;}
        public string Cliente {get; set;}
    }
}
