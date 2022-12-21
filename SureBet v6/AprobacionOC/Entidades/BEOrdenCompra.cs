using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BEOrdenCompra
    {
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Anho { get; set; }
        public string Mes { get; set; }
        public string RUCProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string ProveedorDireccion { get; set; }
        public string ProveedorTelefono { get; set; }
        public double TipoCambio { get; set; }
        public double TasaIgv { get; set; }
        public string Tipo { get; set; }
        public string Tipo_OC { get; set; }
        public string Situacion_Aprobado_ID { get; set; }
        public string Situacion_Aprobado { get; set; }
        public string Estado { get; set; }
        public string EventoGenera { get; set; }

        public string AtencionTipoDoc { get; set; }
        public string AtencionNumero { get; set; }
        public string AtencionNombre { get; set; }
        public string AtencionCargo { get; set; }

        public string TipoCompra { get; set; }

        public string Moneda { get; set; }
        public string CondicionPago_1 { get; set; }
        public string CondicionPago_2 { get; set; }
        public string NumeroCuotas { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string LugarEntrega { get; set; }

        public string SujetoDetraccion { get; set; }
        public string TablaImpuesto { get; set; }
        public string TablaImpuestoNombre { get; set; }
        public double Tasa { get; set; }
        public string Requerimiento { get; set; }

        public string Glosa_OC { get; set; }
        public string SituacionAtendido { get; set; }
        public string RegistroDoc { get; set; }
        public Boolean ControlServicioMaquila { get; set; }
        public Boolean ControlAlmacenServicio { get; set; }

        public string CentroCosto { get; set; }
        public string NombreCentroCosto { get; set; }
        public string Responsable { get; set; }
        public string NombreResponsable { get; set; }
        public string IndicadorIGV { get; set; }
        public string CalcularItem { get; set; }

        public double PorcTolerancia { get; set; }
        public double ImporteBruto { get; set; }
        public double ImporteDescuento { get; set; }
        public double ValorVenta { get; set; }
        public double ImporteIGV { get; set; }
        public double ImporteTotal { get; set; }

        public DateTime Contrato_Inicio { get; set; }
        public DateTime Contrato_Final { get; set; }
        public string Contrato_File { get; set; }
        public string CuadroComparativo_File { get; set; }
        public string SoleSource_File { get; set; }
        public string SoleSource_File_CCO { get; set; }
        public string Solicitud { get; set; }
        public string Requisicion { get; set; }
        public string OCC_Ruta_Intranet { get; set; }
        public string OCC_Ruta_Extranet { get; set; }
        public string RCO_Ruta_Intranet { get; set; }
        public string RCO_Ruta_Extranet { get; set; }
        public string CCO_Ruta_Intranet { get; set; }
        public string CCO_Ruta_Extranet { get; set; }
        public string Contrato_Link { get; set; }
        public string CuadroComparativo_Link { get; set; }
        public string SoleSource_Link { get; set; }

    }

    public class BEOrdenCompra_OKAprobacion
    {
        public int OK_User { get; set; }
        public string OK_Descri { get; set; }
    }

    public class BEOrdenCompra_Resultado
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
    }
    

}
