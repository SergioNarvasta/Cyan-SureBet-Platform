using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


public partial class OrdenCompra_Default : System.Web.UI.Page
{
  
protected void Page_Load(object sender, EventArgs e)
    {

        //Obtenemos al usuario de RED
        //string sUsario = this.User.ToString();
        //Obtenemos el parametro de entrada
        string sCodigoCIA = Request.QueryString["CodigoCIA"]; //.ToString();
        string sCodigoSUC = Request.QueryString["CodigoSUC"]; //.ToString();
        string sNumeroOC = Request.QueryString["NumeroOC"]; //.ToString();


        if (sCodigoCIA == null)
        {
            sCodigoCIA = "";
        }
        if (sCodigoSUC == null)
        {
            sCodigoSUC = "";
        }
        if (sNumeroOC == null)
        {
            sNumeroOC = "";
        }
        //Session["Usuario"] = sUsario;

        BLOrdenCompra objOC = new BLOrdenCompra(); 
        BEOrdenCompra rsOC = new BEOrdenCompra();
        DataTable rsOC_Detalle = new DataTable();
        DataTable rsOC_Detalle_Entrega = new DataTable();
        DataTable rsOC_Detalle_Aprobacion = new DataTable();
        DataTable rsOC_Detalle_CCosto = new DataTable();
        DataTable rsOC_Detalle_Pagos = new DataTable();
        DataTable rsOC_Detalle_Adelantos = new DataTable();
        List<BEOCReferencia> rsOC_Detalle_Kardex ;
        string strKardex = string.Empty;

        //Datos de Cabecera
        rsOC = objOC.ObtenerOrdenDeCompra(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle = objOC.ObtenerDetalleOrdenCompra(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle_Entrega = objOC.ObtenerDetalleOrdenCompra_Entrega(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle_Aprobacion = objOC.ObtenerDetalleOrdenCompra_Aprobacion(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle_CCosto = objOC.ObtenerDetalleOrdenCompra_CCosto(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle_Pagos = objOC.ObtenerDetalleOrdenCompra_Pagos(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle_Adelantos = objOC.ObtenerDetalleOrdenCompra_Adelantos(sCodigoCIA, sCodigoSUC, sNumeroOC);
        rsOC_Detalle_Kardex = objOC.ObtenerDetalleOrdenCompra_Kardex(sCodigoCIA, sCodigoSUC, sNumeroOC);

        txtSerie.Text = rsOC.Serie;
        txtNumero.Text = rsOC.Numero;
        txtFechaEmision.Text = rsOC.FechaEmision.ToString("dd/MM/yyyy");
        txtAnho.Text = rsOC.Anho;
        txtMes.Text = rsOC.Mes;
        txtTipoCambio.Text = rsOC.TipoCambio.ToString("##.###0");
        txtTasaIgv.Text = rsOC.TasaIgv.ToString("##.#0");
        txtLocal.Text = rsOC.Tipo;
        txtEstadoOC.Text = rsOC.Estado;
        txtEventoGenera.Text = rsOC.EventoGenera;
        txtRUCProveedor.Text = rsOC.RUCProveedor;
        txtRazonProveedor.Text = rsOC.RazonSocial;
        txtDireccionProveedor.Text = rsOC.ProveedorDireccion;
        txtDireccionTelefono.Text = rsOC.ProveedorTelefono;
        txtAtencion1.Text = rsOC.AtencionTipoDoc;
        txtAtencion2.Text = rsOC.AtencionNumero;
        txtAtencion3.Text = rsOC.AtencionNombre;
        txtCargo.Text = rsOC.AtencionCargo;
        txtTipoCompra.Text = rsOC.TipoCompra;
        txtMoneda.Text = rsOC.Moneda;
        txtCondicionPago.Text = rsOC.CondicionPago_1;
        txtDescripcionCP.Text = rsOC.CondicionPago_2;
        txtNroCuotas.Text = rsOC.NumeroCuotas;
        txtFechaEntrega.Text = rsOC.FechaEntrega.ToString("dd/MM/yyyy");
        txtLugarEntrega.Text = rsOC.LugarEntrega;
        txtSujetoDetraccion.Text = rsOC.SujetoDetraccion;
        txtImpuesto.Text = rsOC.TablaImpuesto;
        txtNombreImpuesto.Text = rsOC.TablaImpuestoNombre;
        txtTasaImpuesto.Text = rsOC.Tasa.ToString("#0.#0");
        txtRequerimiento.Text = rsOC.Requerimiento;
        txtGlosa.Text = rsOC.Glosa_OC;
        //MOD GCHERRE 20160418 - Campos retirados para colocar cuadro comparativo
        //txtSituacionAtendido.Text = rsOC.SituacionAtendido; 
        //chkControlAlmacenServicios.Checked = rsOC.ControlAlmacenServicio;
        //chkControlServicios.Checked = rsOC.ControlServicioMaquila;
        //txtRegistroDoc.Text = rsOC.RegistroDoc;
        txtCentroCosto.Text = rsOC.CentroCosto;
        txtDescripcionCC.Text = rsOC.NombreCentroCosto;
        txtCodResponsable.Text = rsOC.Responsable;
        txtNombreResponsable.Text = rsOC.NombreResponsable;
        txtIndicadorIGV.Text = rsOC.IndicadorIGV;
        txtCalcularItem.Text = rsOC.CalcularItem;
        txtTolerancia.Text = rsOC.PorcTolerancia.ToString("##0.#0%");
        txtImporteBruto.Text = rsOC.ImporteBruto.ToString("#,##0.#0");
        txtImporteDscto.Text = rsOC.ImporteDescuento.ToString("#,##0.#0");
        txtValorVenta.Text = rsOC.ValorVenta.ToString("#,##0.#0");
        txtImporteIgv.Text = rsOC.ImporteIGV.ToString("#,##0.#0");
        txtImporteTotal.Text = rsOC.ImporteTotal.ToString("#,##0.#0");
        HypCuadroComparativo.Text = "";
        HypCuadroComparativo.NavigateUrl = "";
        HypSoleSource.Text = "";
        HypSoleSource.NavigateUrl = "";
        if (rsOC.Tipo_OC=="4")
        {
            HypContrato.Text = "revisar documento del contrato...";
            HypContrato.NavigateUrl = rsOC.Contrato_Link;
            if (rsOC.Numero.Substring(0,2)!="AD" && rsOC.Numero.Substring(0,2)!="MO")
            {
                //if (rsOC.SoleSource_File != null && !rsOC.SoleSource_File.Equals(""))
                // Modificacion del 20160609 comprobar la ruta del Sole Source si es mayor a 2 porque cadena de ruta es: ".\"
                if (rsOC.SoleSource_Link!=null && rsOC.SoleSource_Link.Length > 2)
                {
                    HypSoleSource.Text = "revisar sole source...";
                    HypSoleSource.NavigateUrl = rsOC.SoleSource_Link;
                }
                else
                {
                    if (rsOC.CuadroComparativo_File != null && !rsOC.CuadroComparativo_File.Equals(""))
                    {
                        HypCuadroComparativo.Text = "revisar cuadro comparativo...";
                        HypCuadroComparativo.NavigateUrl = rsOC.CuadroComparativo_Link;
                    }
                    else
                    {
                        HypCuadroComparativo.Text = "!Falta cuadro comparativo! Avisar a Compras...";
                        HypCuadroComparativo.ForeColor = System.Drawing.Color.Red;
                        HypCuadroComparativo.NavigateUrl = rsOC.CuadroComparativo_Link;
                    }
                
                }


            }
        }
        else
        {
            HypContrato.Text = "";
            HypContrato.NavigateUrl = "";
            if (rsOC.SoleSource_Link != null && rsOC.SoleSource_Link.Length > 2)
            {
                HypSoleSource.Text = "revisar sole source...";
                HypSoleSource.NavigateUrl = rsOC.SoleSource_Link;
            }
            else
            {
                if (rsOC.CuadroComparativo_File != null && !rsOC.CuadroComparativo_File.Equals(""))
                {
                    HypCuadroComparativo.Text = "revisar cuadro comparativo...";
                    HypCuadroComparativo.NavigateUrl = rsOC.CuadroComparativo_Link;
                }
                else
                {
                    HypCuadroComparativo.Text = "!Falta cuadro comparativo! Avisar a Compras...";
                    HypCuadroComparativo.ForeColor = System.Drawing.Color.Red;
                    HypCuadroComparativo.NavigateUrl = rsOC.CuadroComparativo_Link;
                }
            }
        }

        //Fin Datos de Cabecera

        grvDetalle.DataSource = rsOC_Detalle;
        grvDetalle.DataBind();

        grvFechaEntrega.DataSource = rsOC_Detalle_Entrega;
        grvFechaEntrega.DataBind();

        grvAprobacion.DataSource = rsOC_Detalle_Aprobacion;
        grvAprobacion.DataBind();

        grvCentroCosto.DataSource = rsOC_Detalle_CCosto;
        grvCentroCosto.DataBind();

        grvRegistroCompras.DataSource = rsOC_Detalle_Pagos;
        grvRegistroCompras.DataBind();

        grvRequerimientoEfectivo.DataSource = rsOC_Detalle_Adelantos;
        grvRequerimientoEfectivo.DataBind();

        foreach (BEOCReferencia item in rsOC_Detalle_Kardex)
        {
            strKardex += item.AtencionAlmacen + Environment.NewLine;
        }
        txtAtencionAlmacen.Text = strKardex;
    
    }

    public void btnRegistrar_CLick(object sender, EventArgs e)
    {
        string sCia_codcia, sSuc_codsuc, sOcm_corocm; DateTime dOcc_fecdoc; string sOcc_tipocc, sTmo_codtmo;
        double nOcc_tipcam; string sOcc_gloocc; string sOcc_lugent; string sOcc_luginc; int nOcc_indmaq; string sOcc_indigv; double nOcc_tasigv; double nOcc_impbru;
        double nOcc_pordes; double nOcc_impde1; double nOcc_impigv; double nOcc_imptot; double nOcc_totfob; double nOcc_totfle;
        double nOcc_totseg; double nOcc_totcyf; double nOcc_tototr; double nOcc_totcif; double nOcc_portol; string sOcc_sitapr; string sOcc_sitlog;
        string sOcc_sitctb; int nOcc_indalm; string sOcc_indest; DateTime dOcc_fecact; string sOcc_codusu; int nOcc_indsap; int nOcc_locser; int nOcc_indcfm; int nOcc_tipcnt;

        sCia_codcia = Session["Cia"].ToString();
        sSuc_codsuc = Session["Suc"].ToString();
        sOcm_corocm = txtNumero.Text.ToString();
        dOcc_fecdoc = DateTime.Parse(txtFechaEmision.Text);
        sOcc_tipocc = txtLocal.Text.ToString();
        sTmo_codtmo = txtMoneda.Text.ToString().Substring(0,2); ;
        nOcc_tipcam = Double.Parse(txtTipoCambio.Text.ToString());
        sOcc_gloocc = txtGlosa.Text.ToString();
        sOcc_lugent = txtLugarEntrega.Text.ToString();
        sOcc_luginc = " ";
        nOcc_indmaq = 0;
        sOcc_indigv = txtIndicadorIGV.Text.ToString();
        nOcc_tasigv = Double.Parse(txtTasaIgv.Text.ToString());
        nOcc_impbru = Double.Parse(txtImporteBruto.Text.ToString());
        nOcc_pordes = 0;
        nOcc_impde1 = 0;
        nOcc_impigv = Double.Parse(txtImporteIgv.Text.ToString());
        nOcc_imptot = Double.Parse(txtImporteTotal.Text.ToString());
        nOcc_totfob = 0;
        nOcc_totfle = 0;
        nOcc_totseg = 0;
        nOcc_totcyf = 0;
        nOcc_tototr = 0;
        nOcc_totcif = 0;
        nOcc_portol = 0;
        sOcc_sitapr = "1";  // Situacion Aprobado '1'  'PENDIENTE' '2'  'APROBADO' '3'  'RECHAZADO'
        sOcc_sitlog = "1";
        sOcc_sitctb = "0";
        nOcc_indalm = 0;
        sOcc_indest = "1";    //Estado 1 Vigente 0 Cancelado
        dOcc_fecact = DateTime.Now;
        sOcc_codusu = Session["Usuario"].ToString();
        nOcc_indsap = 0;
        nOcc_locser = 0;
        nOcc_indcfm = 0;
        nOcc_tipcnt = 0;
        BLOrdenCompra objOC = new BLOrdenCompra();
        int rsOC = objOC.RegistrarOrdenCompra(sCia_codcia, sSuc_codsuc, sOcm_corocm, dOcc_fecdoc, sOcc_tipocc, sTmo_codtmo,
             nOcc_tipcam, sOcc_gloocc, sOcc_lugent, sOcc_luginc, nOcc_indmaq, sOcc_indigv, nOcc_tasigv, nOcc_impbru,
             nOcc_pordes, nOcc_impde1, nOcc_impigv, nOcc_imptot, nOcc_totfob, nOcc_totfle,
             nOcc_totseg, nOcc_totcyf, nOcc_tototr, nOcc_totcif, nOcc_portol, sOcc_sitapr, sOcc_sitlog,
             sOcc_sitctb, nOcc_indalm, sOcc_indest, dOcc_fecact, sOcc_codusu, nOcc_indsap, nOcc_locser, nOcc_indcfm, nOcc_tipcnt);
        if (rsOC == 1)
        {
            //Registro Correcto   
        }
        else
        {
            //No se registro
        }
    }
}

