using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sCodigoCIA, sCodigoSUC, sNumeroOC, sUsuario;

        sCodigoCIA = txtCIA.Text;
        sCodigoSUC = sCodigoCIA;
        sNumeroOC = txtNRO.Text;
        sUsuario = txtUSR.Text;

        BLOrdenCompra objOC = new BLOrdenCompra();
        BEOrdenCompra_OKAprobacion rsOC = new BEOrdenCompra_OKAprobacion();
        
        
        //Datos de Cabecera
        rsOC = objOC.ObtenerOKUsuario_ApruebaOrdenCompra(sCodigoCIA, sCodigoSUC, sNumeroOC,sUsuario);

        if (rsOC.OK_User == 1)
        { 
            Response.Write("Respuesta de Aplicacion");
            Response.Write(rsOC.OK_Descri);
        }
        else 
        {
            Response.Write("Usuario " + sUsuario + " CEROOOOOOO");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string sCodigoCIA, sCodigoSUC, sNumeroRQ, sUsuario;

        sCodigoCIA = txtCIA_RQ.Text;
        sCodigoSUC = sCodigoCIA;
        sNumeroRQ = txtRQ.Text;
        sUsuario = txtUser_RQ.Text;

        BLRequerimientoCompra objOC = new BLRequerimientoCompra();
        BERequerimientoCompra_OKAprobacion rsOC = new BERequerimientoCompra_OKAprobacion();
        
        //Datos de Cabecera
        rsOC = objOC.ObtenerOKUsuario_ApruebaRequerimientoCompra(sCodigoCIA, sCodigoSUC, sNumeroRQ, sUsuario);

        if (rsOC.OK_User == 1)
        {
            Response.Write("Respuesta de Aplicacion");
            txtMensaje.Text = rsOC.OK_Descri;
        }
        else
        {
            Response.Write("Usuario " + sUsuario + " CEROOOOOOO");
        }
    }
    protected void btnServer_Click(object sender, EventArgs e)
    {
        Response.Write("Se escribio este mensaje : " + txtMensaje.Text);
        txtMensaje.Text = "OK Metodo ejecutado en el servidor";
    }
}