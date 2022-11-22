using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BEOCEnvioMaterial
    {
        public string Item { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tip_Inv { get; set; }
        public string UM { get; set; }
        public int Cantidad_Solicitado { get; set; }
        public int Cantidad_Env_Proveedor { get; set; }
        public int Cantidad_Pendiente { get; set; }
    }
}
