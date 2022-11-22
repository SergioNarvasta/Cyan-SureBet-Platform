using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BEOCAprobacion
    {
        public string Glosa { get; set; }
        public int Codigo { get; set; }
        public int Nivel { get; set; }
        public string Cargo { get; set; }
        public string Descripcion { get; set; }
        public string Aprobacion { get; set; }
        public string Responsable { get; set; }
        public string NombreResponsable { get; set; }

        public string GlosaGeneral { get; set; }
    }
}
