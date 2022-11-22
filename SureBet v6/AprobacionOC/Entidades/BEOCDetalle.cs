using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BEOCDetalle
    {
        public string item { get; set; }
        public string Producto { get; set; }
        public string Tip_Inv { get; set; }
        public string Descripcion { get; set; }
        public string Especificacion { get; set; }
        public int Cantidad { get; set; }
        public double Porcent_Ajuste { get; set; }
        public double Monto_Ajuste{ get; set; }
        public int Unid_Comp { get; set; }
        public int Unidad { get; set; }
        public double Precio_Unit { get; set; }
        public double Imp_Bruto{ get; set; }
        public double Porc_Descto_1{ get; set; }
        public double Imp_Descto_1 { get; set; }
        public double Porc_Descto_2 { get; set; }
        public double Imp_Descto_2 { get; set; }
        public double Porc_Descto_3 { get; set; }
        public double Imp_Descto_3 { get; set; }
    }
}
