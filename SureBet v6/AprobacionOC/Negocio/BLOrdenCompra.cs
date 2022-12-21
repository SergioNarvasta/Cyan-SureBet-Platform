using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using Data;
using Entidades;

namespace Negocio
{   
    public class BLOrdenCompra
    {
        public int RegistrarOrdenCompra(string sCia_codcia, string sSuc_codsuc, string sOcm_corocm, DateTime dOcc_fecdoc, string sOcc_tipocc,string sTmo_codtmo,
        double nOcc_tipcam, string sOcc_gloocc, string sOcc_lugent, string sOcc_luginc, int    nOcc_indmaq, string sOcc_indigv, double nOcc_tasigv, double nOcc_impbru,
        double nOcc_pordes, double nOcc_impde1, double nOcc_impigv, double nOcc_imptot, double nOcc_totfob, double nOcc_totfle,
        double nOcc_totseg, double nOcc_totcyf, double nOcc_tototr, double nOcc_totcif, double nOcc_portol, string sOcc_sitapr, string sOcc_sitlog,
        string sOcc_sitctb, int  nOcc_indalm, string sOcc_indest, DateTime dOcc_fecact, string sOcc_codusu, int    nOcc_indsap, int    nOcc_locser, int nOcc_indcfm, int nOcc_tipcnt)
        {
            return new DAOrdenCompra().RegistrarOrdenCompra(sCia_codcia, sSuc_codsuc, sOcm_corocm, dOcc_fecdoc, sOcc_tipocc, sTmo_codtmo,
             nOcc_tipcam, sOcc_gloocc, sOcc_lugent, sOcc_luginc, nOcc_indmaq, sOcc_indigv, nOcc_tasigv, nOcc_impbru,
             nOcc_pordes, nOcc_impde1, nOcc_impigv, nOcc_imptot, nOcc_totfob,nOcc_totfle,
             nOcc_totseg, nOcc_totcyf, nOcc_tototr, nOcc_totcif, nOcc_portol, sOcc_sitapr, sOcc_sitlog,
             sOcc_sitctb, nOcc_indalm, sOcc_indest, dOcc_fecact, sOcc_codusu, nOcc_indsap, nOcc_locser, nOcc_indcfm, nOcc_tipcnt);
        }

        public BEOrdenCompra ObtenerOrdenDeCompra(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerOrdenDeCompra(CodCompania, CodSucursal, NumOrdenCompra); 
        }

        public DataTable ObtenerDetalleOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public DataTable ObtenerDetalleOrdenCompra_Entrega(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra_Entrega(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public DataTable ObtenerDetalleOrdenCompra_Aprobacion(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra_Aprobacion(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public DataTable ObtenerDetalleOrdenCompra_CCosto(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra_CCosto(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public DataTable ObtenerDetalleOrdenCompra_Pagos(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra_Pagos(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public DataTable ObtenerDetalleOrdenCompra_Adelantos(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra_Adelantos(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public List<BEOCReferencia> ObtenerDetalleOrdenCompra_Kardex(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            return new DAOrdenCompra().ObtenerDetalleOrdenCompra_Kardex(CodCompania, CodSucursal, NumOrdenCompra);
        }

        public BEOrdenCompra_OKAprobacion ObtenerOKUsuario_ApruebaOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser)
        {
            return new DAOrdenCompra().ObtenerOKUsuario_ApruebaOrdenCompra(CodCompania, CodSucursal, NumOrdenCompra, CodUser);
        }

        public BEOrdenCompra_Resultado ObtenerResultado_ApruebaOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser)
        {
            return new DAOrdenCompra().ObtenerResultado_ApruebaOrdenCompra(CodCompania, CodSucursal, NumOrdenCompra, CodUser);
        }

        public BEOrdenCompra_Resultado ObtenerResultado_DevuelveOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser, string Motivo)
        {
            return new DAOrdenCompra().ObtenerResultado_DevuelveOrdenCompra(CodCompania, CodSucursal, NumOrdenCompra, CodUser, Motivo);
        }

        public BEOrdenCompra_Resultado ObtenerResultado_RechazaOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser, string Motivo)
        {
            return new DAOrdenCompra().ObtenerResultado_RechazaOrdenCompra(CodCompania, CodSucursal, NumOrdenCompra, CodUser, Motivo);
        }

    }
}
