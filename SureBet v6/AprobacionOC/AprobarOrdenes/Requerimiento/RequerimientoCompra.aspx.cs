using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

public partial class Requerimiento_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Obtenemos al usuario de RED
        string sUsario = this.User.ToString();

        //Obtenemos el parametro de entrada
        string sCodigoCIA = Request.QueryString["CodigoCIA"]; //.ToString();
        string sCodigoSUC = Request.QueryString["CodigoSUC"]; //.ToString();
        string sNumeroRQ = Request.QueryString["NumeroRQ"]; //.ToString();

        if (sCodigoCIA == null)
        {
            sCodigoCIA = "";
        }
        if (sCodigoSUC == null)
        {
            sCodigoSUC = "";
        }
        if (sNumeroRQ == null)
        {
            sNumeroRQ = "";
        }
        if (sUsario.Equals(""))
        {

            Response.Redirect("../Error/ErrorAcceso.aspx");
            Response.End();
        }

        Session["Usuario"] = sUsario;

        BLRequerimientoCompra objRQ = new BLRequerimientoCompra();
        BERequerimientoCompra rsRQ = new BERequerimientoCompra();
        DataTable rsRQ_Detalle = new DataTable();
        DataTable rsRQ_Detalle_Aprobacion = new DataTable();
        DataTable rsRQ_Detalle_Adjuntos = new DataTable();

        //Datos de Cabecera
        rsRQ = objRQ.ObtenerRequerimientoDeCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ);
        rsRQ_Detalle = objRQ.ObtenerDetalleRequerimientoCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ);
        rsRQ_Detalle_Aprobacion = objRQ.ObtenerDetalleRequerimientoCompra_Aprobacion(sCodigoCIA, sCodigoSUC, sNumeroRQ);
        rsRQ_Detalle_Adjuntos = objRQ.ObtenerDetalleRequerimientoCompra_Adjuntos(sCodigoCIA, sCodigoSUC, sNumeroRQ);

        txtNumero.Text = rsRQ.Numero;
        txtFecRegistro.Text = rsRQ.FechaRegistro.ToString("dd/MM/yyyy");
        txtFecSugerida.Text = rsRQ.FechaSugerida.ToString("dd/MM/yyyy");
        txtSituacion.Text = rsRQ.Situacion_Aprobado;
        txtEstado.Text = rsRQ.Estado;
        txtUNegocio.Text = rsRQ.Unidad_Negocio;
        txtCenCos.Text = rsRQ.Centro_Costo;
        txtCenCos_ID.Text = rsRQ.Centro_Costo_ID;
        txtUser_Origen_ID.Text = rsRQ.Usuario_Origen_ID;
        txtUser_Origen.Text = rsRQ.Usuario_Origen;
        txtResumen.Text = rsRQ.Resumen;
        txtMotivo.Text = rsRQ.Motivo;
        txtPrioridad.Text = rsRQ.Prioridad;
        txtPCN.Text = rsRQ.PCN;
        txtDisciplina_ID.Text = rsRQ.Disciplina_ID;
        txtDisciplina.Text = rsRQ.Disciplina;
        txtReembolso.Text = rsRQ.Reembolso;
        txtPresupuesto.Text = rsRQ.Presupuesto;
        txt9Digitos.Text = rsRQ.NueveDigitos;
        txtJustifica.Text = rsRQ.Justificacion;
        txtTipo_Requisicion.Text = rsRQ.Tipo_Requisicion;
        txtOrden_Compra.Text = rsRQ.Orden_Compra;
        txtProveedor.Text = rsRQ.Proveedor_OC;
        if (rsRQ.Tipo_Requisicion_ID=="2")
        {
            if (txtOrden_Compra.Text.Equals(""))
            {
                txtOrden_Compra.Text = "Falta Indicar AM o CLS";
                txtOrden_Compra.BackColor = System.Drawing.Color.Red;
            }

        }
        if (txtJustifica.Text.Equals(""))
        {
            txtJustifica.Visible = false;
                    }
        else
        {
            txtJustifica.Visible = true;
        }
        if (txtOrden_Compra.Text.Equals(""))
        {
            txtOrden_Compra.Visible = false;
            lblOrden_Compra.Visible = false;
        }
        else
        {
            txtOrden_Compra.Visible = true;
            lblOrden_Compra.Visible = true;
        }
        txtSolicitud.Text = rsRQ.Solicitud;
        txtImportePresupuesto.Text = rsRQ.Importe_Presupuesto.ToString("#,##0.#0");
        txtMonedaPresupuesto.Text = rsRQ.Moneda_Presupuesto;
        //txtUsuCre.Text = rsRQ.Usuario_Creacion;
        //txtUsuAct.Text = rsRQ.Usuario_Actualiza;
        //txtFecCre.Text = rsRQ.Fecha_Creacion.ToString("dd/MM/yyyy HH:mm:ss");
        //txtFecAct.Text = rsRQ.Fecha_Actualiza.ToString("dd/MM/yyyy HH:mm:ss");
        //Fin Datos de Cabecera

        grvDetalle.DataSource = rsRQ_Detalle;
        grvDetalle.DataBind();

        grvAprobacion.DataSource = rsRQ_Detalle_Aprobacion;
        grvAprobacion.DataBind();

        grvAdjuntos.DataSource = rsRQ_Detalle_Adjuntos;
        grvAdjuntos.DataBind();

    }
}