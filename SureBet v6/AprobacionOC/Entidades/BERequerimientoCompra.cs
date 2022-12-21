using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BERequerimientoCompra
    {
        public string Numero { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaSugerida { get; set; }
        public string Unidad_Negocio_ID { get; set; }
        public string Unidad_Negocio { get; set; }
        public string Centro_Costo_ID { get; set; }
        public string Centro_Costo { get; set; }
        public string Resumen { get; set; }
        public string Motivo { get; set; }
        public string Situacion_Aprobado_ID { get; set; }
        public string Situacion_Aprobado { get; set; }
        public string Usuario_Origen { get; set; }
        public string Usuario_Origen_ID { get; set; }
        public string Prioridad { get; set; }
        public string PCN { get; set; }
        public string Disciplina_ID { get; set; }
        public string Disciplina { get; set; }
        public string Reembolso { get; set; }
        public string Presupuesto { get; set; }
        public string NueveDigitos { get; set; }
        public string Usuario_Creacion { get; set; }
        public string Usuario_Actualiza { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Actualiza { get; set; }
        public string Justificacion { get; set; }
        public string Usuario_Solicita_ID { get; set;}
        public string Usuario_Solicita { get; set;}
        public string Codigo_Alterno { get; set;}
        public string Categorizado { get; set;}
        public string Procura { get; set;}
        public string Procura_ID { get; set;}
        public string FlgCompra_ID { get; set;}
        public string FlgCompra { get; set;}
        public string FlgAtencion_ID { get; set;}
        public string FlgAtencion { get; set;}
        public string Justificacion_Atencion { get; set;}
        public string MigracionID { get; set;}
        public string Area { get; set; }
        public string Tipo_Requisicion { get; set; }
        public string Tipo_Requisicion_ID { get; set; }
        public string Orden_Compra { get; set; }
        public string Proveedor_OC { get; set; }
        public string Solicitud { get; set; }
        public string Moneda_Presupuesto { get; set; }
        public double Importe_Presupuesto { get; set; }
    }

    public class BERequerimientoCompra_OKAprobacion
    {
        public int OK_User { get; set; }
        public string OK_Descri { get; set; }
    }

    public class BERequerimientoCompra_Resultado
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
    }
}

