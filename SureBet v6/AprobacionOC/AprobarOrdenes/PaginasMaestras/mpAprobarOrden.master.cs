using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;



public partial class PaginasMaestras_mpAprobarOrden : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Obtenemos el parametro de entrada
        string sUser="";
        int nPosDif=-1;
        string sLogin = Request.ServerVariables["LOGON_USER"].ToString();
        string sCodigoCIA = Request.QueryString["CodigoCIA"]; //.ToString();
        string sCodigoSUC = Request.QueryString["CodigoSUC"]; //.ToString();
        string sNumeroOC = Request.QueryString["NumeroOC"]; //.ToString();
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
            nPosDif = sLogin.IndexOf("\\");
            if (nPosDif > -1)
            {
                sUser = sLogin.Substring(nPosDif + 1);
                if (sUser.Equals("Gerardo"))
                {
                    sUser = "VASQF6"; //"CARRL7"; //"BONIL"; //"PADIH2"; // "GRIMC4";
                }
            }
            else
            {
                sUser = sLogin.Trim();
            }
            Session["Usuario"] = sUser;
            Session["Cia"] = sCodigoCIA;
            Session["Suc"] = sCodigoSUC;
            Session["NumeroOC"] = sNumeroOC;
        }

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
        if (sMensajeEJE == null)
        {
            sMensajeEJE = "";
        }
        BLOrdenCompra objOC = new BLOrdenCompra();
        BEOrdenCompra rsOC_Cab = new BEOrdenCompra();
        BEOrdenCompra_OKAprobacion rsOC = new BEOrdenCompra_OKAprobacion();
        rsOC = objOC.ObtenerOKUsuario_ApruebaOrdenCompra(sCodigoCIA, sCodigoSUC, sNumeroOC, sUser);
        rsOC_Cab = objOC.ObtenerOrdenDeCompra(sCodigoCIA, sCodigoSUC, sNumeroOC);
        if (rsOC_Cab.Situacion_Aprobado_ID == null)
        {
            // Si no Esta Pendiente se deshabilitan los botones de EVALUACION
            btnAprobar.BackColor = System.Drawing.Color.Gray;
            btnAprobar.Enabled = false;
            btnRechazar.BackColor = System.Drawing.Color.Gray;
            btnRechazar.Enabled = false;
            btnDevolver.BackColor = System.Drawing.Color.Gray;
            btnDevolver.Enabled = false;
            lblMensaje.Visible = true;
            lblMensaje.Text = "No hay Orden de Compra para Visualizar";
            return;
        }

        if (!rsOC_Cab.Situacion_Aprobado_ID.Equals("1"))
        {
            // Si no Esta Pendiente se deshabilitan los botones de EVALUACION
            btnAprobar.BackColor = System.Drawing.Color.Gray;
            btnAprobar.Enabled = false;
            btnRechazar.BackColor = System.Drawing.Color.Gray;
            btnRechazar.Enabled = false;
            btnDevolver.BackColor = System.Drawing.Color.Gray;
            btnDevolver.Enabled = false;
            lblMensaje.Visible = true;
            lblMensaje.Text = "Orden de Compra " + sNumeroOC + " ya esta " + rsOC_Cab.Situacion_Aprobado;
        }
        else
        {
            if (rsOC.OK_User == 1)
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
                    lblMensaje.Text = "(*) Usuario " + sUser + " no puede evaluar OC";
                }
                else
                {
                    lblResultado.Visible = true;
                    lblResultado.Text = sMensajeEJE;
                }
            }
        }
    }
    protected void btnRegistrar_CLick(object sender, EventArgs e)
    {
        string sCia_codcia, sSuc_codsuc, sOcm_corocm; DateTime dOcc_fecdoc; string sOcc_tipocc, sTmo_codtmo;
        double nOcc_tipcam; string sOcc_gloocc; string sOcc_lugent; string sOcc_luginc; int    nOcc_indmaq; string sOcc_indigv; double nOcc_tasigv; double nOcc_impbru;
        double nOcc_pordes; double nOcc_impde1; double nOcc_impigv; double nOcc_imptot; double nOcc_totfob; double nOcc_totfle;
        double nOcc_totseg; double nOcc_totcyf; double nOcc_tototr; double nOcc_totcif; double nOcc_portol; string sOcc_sitapr; string sOcc_sitlog;
        string sOcc_sitctb; int    nOcc_indalm; string sOcc_indest; DateTime dOcc_fecact; string sOcc_codusu; int  nOcc_indsap; int    nOcc_locser; int nOcc_indcfm; int nOcc_tipcnt;
 
        sCia_codcia = Session["Cia"].ToString();
        sSuc_codsuc = Session["Suc"].ToString(); 
        sOcc_codusu = Session["Usuario"].ToString();     
    }
    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        string sUser, sCodigoCIA, sCodigoSUC, sNumeroOC;

        sUser = Session["Usuario"].ToString();
        sCodigoCIA = Session["Cia"].ToString();
        sCodigoSUC = Session["Suc"].ToString();
        sNumeroOC = Session["NumeroOC"].ToString();
        BLOrdenCompra objOC = new BLOrdenCompra();
        BEOrdenCompra_Resultado rsOC = new BEOrdenCompra_Resultado();
        rsOC = objOC.ObtenerResultado_ApruebaOrdenCompra(sCodigoCIA, sCodigoSUC, sNumeroOC, sUser);

        if (rsOC.Codigo == 1)
        {
            //Aprobacion Correcta
            lblMensaje.Visible = true;
            lblMensaje.Text = "Aprobacion EXITOSA";
            Response.Redirect("./OrdenCompra.aspx?codigoCIA=" + sCodigoCIA + "&CodigoSUC=" + sCodigoSUC + "&NumeroOC=" + sNumeroOC + "&Mensaje=" + lblMensaje.Text);
        }
        else
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "(*) " + rsOC.Mensaje;
        }
    }
    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        string sUser, sCodigoCIA, sCodigoSUC, sNumeroOC, sMotivo;

        sUser = Session["Usuario"].ToString();
        sCodigoCIA = Session["Cia"].ToString();
        sCodigoSUC = Session["Suc"].ToString();
        sNumeroOC = Session["NumeroOC"].ToString();
        sMotivo = txtMotivo.Text;
        BLOrdenCompra objOC = new BLOrdenCompra();
        BEOrdenCompra_Resultado rsOC = new BEOrdenCompra_Resultado();
        rsOC = objOC.ObtenerResultado_RechazaOrdenCompra(sCodigoCIA, sCodigoSUC, sNumeroOC, sUser, sMotivo);

        if (rsOC.Codigo == 1)
        {
            //Aprobacion Correcta
            lblMensaje.Visible = true;
            lblMensaje.Text = "Rechazo EXITOSO";
            Response.Redirect("./OrdenCompra.aspx?codigoCIA=" + sCodigoCIA + "&CodigoSUC=" + sCodigoSUC + "&NumeroOC=" + sNumeroOC + "&Mensaje=" + lblMensaje.Text);
        }
        else
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "(*) " + rsOC.Mensaje;
        }
    }
    protected void btnDevolver_Click(object sender, EventArgs e)
    {
        string sUser, sCodigoCIA, sCodigoSUC, sNumeroOC, sMotivo;

        sUser = Session["Usuario"].ToString();
        sCodigoCIA = Session["Cia"].ToString();
        sCodigoSUC = Session["Suc"].ToString();
        sNumeroOC = Session["NumeroOC"].ToString();
        sMotivo = txtMotivo.Text.Trim();
        BLOrdenCompra objOC = new BLOrdenCompra();
        BEOrdenCompra_Resultado rsOC = new BEOrdenCompra_Resultado();
        rsOC = objOC.ObtenerResultado_DevuelveOrdenCompra(sCodigoCIA, sCodigoSUC, sNumeroOC, sUser, sMotivo);

        if (rsOC.Codigo == 1)
        {
            //Aprobacion Correcta
            lblResultado.Visible = true;
            lblResultado.Text = "Devolucion EXITOSA";
            Response.Redirect("./OrdenCompra.aspx?codigoCIA=" + sCodigoCIA + "&CodigoSUC=" + sCodigoSUC + "&NumeroOC=" + sNumeroOC + "&Mensaje=" + lblResultado.Text);
        }
        else
        {
            lblResultado.Visible = true;
            lblResultado.Text = "(*) " + rsOC.Mensaje;
        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {

    }
}
