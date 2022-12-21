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
    public class BLRequerimientoCompra
    {
        
        public BERequerimientoCompra ObtenerRequerimientoDeCompra(string CodCompania, string CodSucursal, string NumReqCompra)
        {
            return new DARequerimientoCompra().ObtenerRequerimientoDeCompra(CodCompania, CodSucursal, NumReqCompra);
        }

        public DataTable ObtenerDetalleRequerimientoCompra(string CodCompania, string CodSucursal, string NumReqCompra)
        {
            return new DARequerimientoCompra().ObtenerDetalleRequerimientoCompra(CodCompania, CodSucursal, NumReqCompra);
        }

        public DataTable ObtenerDetalleRequerimientoCompra_Aprobacion(string CodCompania, string CodSucursal, string NumReqCompra)
        {
            return new DARequerimientoCompra().ObtenerDetalleRequerimientoCompra_Aprobacion(CodCompania, CodSucursal, NumReqCompra);
        }

        public DataTable ObtenerDetalleRequerimientoCompra_Adjuntos(string CodCompania, string CodSucursal, string NumReqCompra)
        {
            return new DARequerimientoCompra().ObtenerDetalleRequerimientoCompra_Adjuntos(CodCompania, CodSucursal, NumReqCompra);
        }

        public BERequerimientoCompra_OKAprobacion ObtenerOKUsuario_ApruebaRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser)
        {
            return new DARequerimientoCompra().ObtenerOKUsuario_ApruebaRequerimientoCompra(CodCompania, CodSucursal, NumReq, CodUser);
        }

        public BERequerimientoCompra_Resultado ObtenerResultado_ApruebaRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser)
        {
            return new DARequerimientoCompra().ObtenerResultado_ApruebaRequerimientoCompra(CodCompania, CodSucursal, NumReq, CodUser);
        }

        public BERequerimientoCompra_Resultado ObtenerResultado_DevuelveRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser, string Motivo)
        {
            return new DARequerimientoCompra().ObtenerResultado_DevuelveRequerimientoCompra(CodCompania, CodSucursal, NumReq, CodUser,Motivo);
        }

        public BERequerimientoCompra_Resultado ObtenerResultado_RechazaRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser, string Motivo)
        {
            return new DARequerimientoCompra().ObtenerResultado_RechazaRequerimientoCompra(CodCompania, CodSucursal, NumReq, CodUser,Motivo);
        }
    }
}
