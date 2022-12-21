using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

public partial class PaginasMaestras_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Obtenemos el parametro de entrada
        string sUser = "";
        int nPosDif = -1;
        string sLogin = Request.ServerVariables["LOGON_USER"].ToString();
        string sCodigoCIA = Request.QueryString["CodigoCIA"]; //.ToString();
        string sCodigoSUC = Request.QueryString["CodigoSUC"]; //.ToString();
        string sNumeroRQ = Request.QueryString["NumeroRQ"]; //.ToString();
        string sMensajeEJE = Request.QueryString["Mensaje"];

        lblResultado.Visible = false;
        lblResultado.Text = "";

        if (sLogin == null)
        {
            Response.Redirect("../Error/ErrorAcceso.aspx");
            Response.End();
        }
        if (sLogin.Equals(""))
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "(*) No se puede Identifica usuario para activar EVALUACION";
        }
        else
        {
            //Response.Write(sLogin);
            lblMensaje.Visible = false;
            lblMensaje.Text = "";
            nPosDif = sLogin.IndexOf("\\");
            if (nPosDif > -1)
            {
                sUser = sLogin.Substring(nPosDif + 1);
                //Response.Write(sUser);
                //Response.Write(sLogin.Substring(nPosDif+2));
                if (sUser.Equals("snarvasta"))
                {
                    sUser = "TELLM2"; // "CARRL7"; //"BONIL"; //"PADIH2"; // "GRIMC4";
                }
            }
            else
            {
                sUser = sLogin.Trim();
            }
            Session["Usuario"] = sUser;
            Session["Cia"] = sCodigoCIA;
            Session["Suc"] = sCodigoSUC;
            Session["NumeroRQ"] = sNumeroRQ;
        }

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
        if (sMensajeEJE == null)
        {
            sMensajeEJE = "";
        }
        BLRequerimientoCompra objRQ = new BLRequerimientoCompra();
        BERequerimientoCompra_OKAprobacion rsRQ = new BERequerimientoCompra_OKAprobacion();
        BERequerimientoCompra rsRQ_Cab = new BERequerimientoCompra();
        rsRQ = objRQ.ObtenerOKUsuario_ApruebaRequerimientoCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ, sUser);
        rsRQ_Cab = objRQ.ObtenerRequerimientoDeCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ);
        if (rsRQ_Cab.Situacion_Aprobado_ID == null)
        {
            // Si no Esta Pendiente se deshabilitan los botones de EVALUACION
            btnAprobar.BackColor = System.Drawing.Color.Gray;
            btnAprobar.Enabled = false;
            btnRechazar.BackColor = System.Drawing.Color.Gray;
            btnRechazar.Enabled = false;
            btnDevolver.BackColor = System.Drawing.Color.Gray;
            btnDevolver.Enabled = false;
            lblMensaje.Visible = true;
            lblMensaje.Text = "No hay Requerimiento para Visualizar";
            return;
        }

        // Modificacion GCHERRE 20160103 Cambio del Titulo
        if (rsRQ_Cab.Tipo_Requisicion != null)
        {
            if (rsRQ_Cab.Tipo_Requisicion_ID.Equals("2"))
            {
                lblTitulo0.Text = "EVALUACION DE " + rsRQ_Cab.Tipo_Requisicion.Trim();
            }
            else
            {
                lblTitulo0.Text = "EVALUACION DE REQUISICION PARA " + rsRQ_Cab.Tipo_Requisicion.Trim();
            }
            
        }

        if (!rsRQ_Cab.Situacion_Aprobado_ID.Equals("1"))
        {  
            // Si no Esta Pendiente se deshabilitan los botones de EVALUACION
            btnAprobar.BackColor = System.Drawing.Color.Gray;
            btnAprobar.Enabled = false;
            btnRechazar.BackColor = System.Drawing.Color.Gray;
            btnRechazar.Enabled = false;
            btnDevolver.BackColor = System.Drawing.Color.Gray;
            btnDevolver.Enabled = false;
            lblMensaje.Visible = true;
            lblMensaje.Text = "Requerimiento " + sNumeroRQ + " ya esta " + rsRQ_Cab.Situacion_Aprobado;
        }
        else
        {
            if (rsRQ.OK_User == 1)
            {
                //Usuario puede EVALUAR OC
                lblMensaje.Visible = false;
                lblMensaje.Text = "";
                btnAprobar.Enabled = true;
                btnRechazar.Enabled = true;
                btnDevolver.Enabled = true;
            }
            else
            {
                btnAprobar.BackColor = System.Drawing.Color.Gray;
                btnAprobar.Enabled = false;
                btnRechazar.BackColor = System.Drawing.Color.Gray;
                btnRechazar.Enabled = false;
                btnDevolver.BackColor = System.Drawing.Color.Gray;
                btnDevolver.Enabled = false;
                if (sMensajeEJE.Equals(""))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "(*) Usuario " + sUser + " no puede evaluar RQ";
                }
                else
                {
                    lblResultado.Visible = true;
                    lblResultado.Text = sMensajeEJE;
                }
        }
        
            
        }

    }
    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        string sUser, sCodigoCIA, sCodigoSUC, sNumeroRQ;

        sUser = Session["Usuario"].ToString();
        sCodigoCIA = Session["Cia"].ToString();
        sCodigoSUC = Session["Suc"].ToString();
        sNumeroRQ = Session["NumeroRQ"].ToString();
        BLRequerimientoCompra objRQ = new BLRequerimientoCompra();
        BERequerimientoCompra_Resultado rsRQ = new BERequerimientoCompra_Resultado();
        rsRQ = objRQ.ObtenerResultado_ApruebaRequerimientoCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ, sUser);

        if (rsRQ.Codigo == 1)
        {
            //Aprobacion Correcta
            lblMensaje.Visible = true;
            lblMensaje.Text = "Aprobacion EXITOSA";
            Response.Redirect("./RequerimientoCompra.aspx?codigoCIA=" + sCodigoCIA + "&CodigoSUC=" + sCodigoSUC + "&NumeroRQ=" + sNumeroRQ + "&Mensaje=" + lblMensaje.Text);
        }
        else
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "(*) " + rsRQ.Mensaje;
        }

    }
    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        string sUser, sCodigoCIA, sCodigoSUC, sNumeroRQ, sMotivo;

        sUser = Session["Usuario"].ToString();
        sCodigoCIA = Session["Cia"].ToString();
        sCodigoSUC = Session["Suc"].ToString();
        sNumeroRQ = Session["NumeroRQ"].ToString();
        sMotivo = txtMotivo.Text;
        BLRequerimientoCompra objRQ = new BLRequerimientoCompra();
        BERequerimientoCompra_Resultado rsRQ = new BERequerimientoCompra_Resultado();
        rsRQ = objRQ.ObtenerResultado_RechazaRequerimientoCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ, sUser, sMotivo);

        if (rsRQ.Codigo == 1)
        {
            //Aprobacion Correcta
            lblMensaje.Visible = true;
            lblMensaje.Text = "Rechazo EXITOSO";
            Response.Redirect("./RequerimientoCompra.aspx?codigoCIA=" + sCodigoCIA + "&CodigoSUC=" + sCodigoSUC + "&NumeroRQ=" + sNumeroRQ + "&Mensaje=" + lblMensaje.Text);
        }
        else
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "(*) " + rsRQ.Mensaje;
        }

    }
    protected void btnDevolver_Click(object sender, EventArgs e)
    {
        string sUser, sCodigoCIA, sCodigoSUC, sNumeroRQ, sMotivo;

        sUser = Session["Usuario"].ToString();
        sCodigoCIA = Session["Cia"].ToString();
        sCodigoSUC = Session["Suc"].ToString();
        sNumeroRQ = Session["NumeroRQ"].ToString();
        sMotivo = txtMotivo.Text;
        BLRequerimientoCompra objRQ = new BLRequerimientoCompra();
        BERequerimientoCompra_Resultado rsRQ = new BERequerimientoCompra_Resultado();
        rsRQ = objRQ.ObtenerResultado_DevuelveRequerimientoCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ, sUser, sMotivo);

        if (rsRQ.Codigo == 1)
        {
            //Aprobacion Correcta
            lblResultado.Visible = true;
            lblResultado.Text = "Devolucion EXITOSA";
            Response.Redirect("./RequerimientoCompra.aspx?codigoCIA=" + sCodigoCIA + "&CodigoSUC=" + sCodigoSUC + "&NumeroRQ=" + sNumeroRQ + "&Mensaje=" + lblResultado.Text);
        }
        else
        {
            lblResultado.Visible = true;
            lblResultado.Text = "(*) " + rsRQ.Mensaje;
        }
    }
}
