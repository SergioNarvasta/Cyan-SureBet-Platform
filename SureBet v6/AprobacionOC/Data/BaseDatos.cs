using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Data
{
    class BaseDatos
    {
        static BaseDatos()
        {
            BDLavalin = "";
        }

        public static string BDLavalin { get; private set; }

        public static string spRegistrarOrdenCompraCab
        {
            get
            {
                string p = "dbo.PA_HD_WEB_OC_RegistrarOC";
                return p;
            }
        }
        public static string spObtenerOrdenCompra_Cab
        {
            get
            {
                string p = "dbo.PA_HD_WEB_OC_Consulta_Cabecera";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle
        {
            get
            {
                string p = "dbo.PA_HD_WEB_OC_Consulta_Detalle_PRD";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle_Entrega
        {
            get
            {
                string p = "PA_HD_WEB_OC_Consulta_Detalle_Entrega";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle_Aprobacion
        {
            get
            {
                string p = "PA_HD_WEB_OC_Consulta_Detalle_Aprobacion";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle_CCosto
        {
            get
            {
                string p = "PA_HD_WEB_OC_Consulta_Detalle_Centro_Costo";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle_Kardex
        {
            get
            {
                string p = "PA_HD_WEB_OC_Consulta_Detalle_Kardex";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle_Pagos
        {
            get
            {
                string p = "PA_HD_WEB_OC_Consulta_Detalle_Pagos";
                return p;
            }
        }

        public static string spObtenerOrdenCompra_Detalle_Adelantos
        {
            get
            {
                string p = "PA_HD_WEB_OC_Consulta_Detalle_Adelantos";
                return p;
            }
        }

        public static string spObtenerOKUsuario_ApruebaOC
        {
            get
            {
                string p = "PA_HD_WEB_OC_OK_Usuario_Aprueba";
                return p;
            }
        }

        public static string spObtenerRequerimientoCompra_Cab
        {
            get
            {
                string p = "dbo.PA_HD_WEB_RQ_Consulta_Cabecera";
                return p;
            }
        }

        public static string spObtenerRequerimientoCompra_Detalle
        {
            get
            {
                string p = "dbo.PA_HD_WEB_RQ_Consulta_Detalle_PRD";
                return p;
            }
        }
                
        public static string spObtenerRequerimientoCompra_Detalle_Aprobacion
        {
            get
            {
                string p = "dbo.PA_HD_WEB_RQ_Consulta_Detalle_Aprobacion";
                return p;
            }
        }

        public static string spObtenerRequerimientoCompra_Detalle_Adjuntos
        {
            get
            {
                string p = "dbo.PA_HD_WEB_RQ_Consulta_Detalle_Adjuntos";
                return p;
            }
        }

        public static string spObtenerOKUsuario_ApruebaRQ
        {
            get
            {
                string p = "PA_HD_WEB_RQ_OK_Usuario_Aprueba";
                return p;
            }
        }

        public static string spObtenerResultado_ApruebaRQ
        {
            get
            {
                string p = "PA_HD_WEB_RQ_Aprueba";
                return p;
            }
        }

        public static string spObtenerResultado_DevuelveRQ
        {
            get
            {
                string p = "PA_HD_WEB_RQ_Devuelve";
                return p;
            }
        }

        public static string spObtenerResultado_RechazaRQ
        {
            get
            {
                string p = "PA_HD_WEB_RQ_Rechaza";
                return p;
            }
        }

        public static string spObtenerResultado_ApruebaOC
        {
            get
            {
                string p = "PA_HD_WEB_OC_Aprueba";
                return p;
            }
        }

        public static string spObtenerResultado_DevuelveOC
        {
            get
            {
                string p = "PA_HD_WEB_OC_Devuelve";
                return p;
            }
        }

        public static string spObtenerResultado_RechazaOC
        {
            get
            {
                string p = "PA_HD_WEB_OC_Rechaza";
                return p;
            }
        }
    }
}
