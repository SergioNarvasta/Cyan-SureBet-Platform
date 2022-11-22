using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using Entidades;
using IData;
using Comunes;

namespace Data
{
    public class DARequerimientoCompra
    {
        public BERequerimientoCompra ObtenerRequerimientoDeCompra(string CodCompania, string CodSucursal, string NumReq)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerRequerimientoCompra_Cab;
            objRequest.Parameters.AddRange(arrParam);

            BERequerimientoCompra objItem = new BERequerimientoCompra();
            IDataReader dr = null;

            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem.Numero = Funciones.CheckStr(dr["RCO_Numero"]);
                    objItem.FechaRegistro = Funciones.CheckDate(dr["RCO_Fec_Registro"]);
                    objItem.FechaSugerida = Funciones.CheckDate(dr["RCO_Fec_Sugerida"]);
                    objItem.Estado = Funciones.CheckStr(dr["RCO_Estado"]);
                    objItem.Unidad_Negocio_ID = Funciones.CheckStr(dr["RCO_U_Negocio_ID"]);
                    objItem.Unidad_Negocio = Funciones.CheckStr(dr["U_Negocio"]);
                    objItem.Centro_Costo_ID = Funciones.CheckStr(dr["RCO_Centro_Costo_ID"]);
                    objItem.Centro_Costo = Funciones.CheckStr(dr["Centro_Costo"]);
                    objItem.Resumen = Funciones.CheckStr(dr["RCO_Resumen"]);
                    objItem.Motivo = Funciones.CheckStr(dr["RCO_Motivo"]);
                    objItem.Situacion_Aprobado_ID = Funciones.CheckStr(dr["RCO_Situacion_Aprobado_ID"]);
                    objItem.Situacion_Aprobado = Funciones.CheckStr(dr["RCO_Situacion_Aprobado"]);
                    objItem.Usuario_Origen_ID = Funciones.CheckStr(dr["RCO_User_Origen_ID"]);
                    objItem.Usuario_Origen = Funciones.CheckStr(dr["User_Origen"]);
                    objItem.Prioridad = Funciones.CheckStr(dr["Rco_Prioridad"]);
                    objItem.PCN = Funciones.CheckStr(dr["RCO_PCN"]);
                    objItem.Disciplina_ID = Funciones.CheckStr(dr["RCO_Disciplina_ID"]);
                    objItem.Disciplina = Funciones.CheckStr(dr["Disciplina"]);
                    objItem.Reembolso = Funciones.CheckStr(dr["RCO_Reembolso"]);
                    objItem.Presupuesto = Funciones.CheckStr(dr["RCO_Presupuesto"]);
                    objItem.NueveDigitos = Funciones.CheckStr(dr["RCO_9_Digitos"]);
                    objItem.Usuario_Creacion = Funciones.CheckStr(dr["RCO_User_Creacion"]);
                    objItem.Fecha_Creacion = Funciones.CheckDate(dr["RCO_Fecha_Creacion"]);
                    objItem.Usuario_Creacion = Funciones.CheckStr(dr["RCO_User_Actualiza"]);
                    objItem.Fecha_Creacion = Funciones.CheckDate(dr["RCO_Fecha_Actualiza"]);
                    objItem.Justificacion = Funciones.CheckStr(dr["RCO_Justificacion"]);
                    objItem.Usuario_Solicita = Funciones.CheckStr(dr["User_Solicita"]);
                    objItem.Usuario_Solicita_ID = Funciones.CheckStr(dr["RCO_User_Solicita_ID"]);
                    objItem.Categorizado = Funciones.CheckStr(dr["RCO_Categorizado"]);
                    objItem.Procura = Funciones.CheckStr(dr["RCO_Procura"]);
                    objItem.Procura_ID = Funciones.CheckStr(dr["RCO_Procura_ID"]);
                    objItem.FlgAtencion = Funciones.CheckStr(dr["RCO_FlgAtencion"]);
                    objItem.FlgAtencion_ID = Funciones.CheckStr(dr["RCO_FlgAtencion_ID"]);
                    objItem.FlgCompra = Funciones.CheckStr(dr["RCO_FlgCompra"]);
                    objItem.FlgCompra_ID = Funciones.CheckStr(dr["RCO_FlgCompra_ID"]);
                    objItem.Justificacion_Atencion = Funciones.CheckStr(dr["RCO_Justificacion_ATE"]);
                    objItem.MigracionID = Funciones.CheckStr(dr["RCO_MigracionID"]);
                    objItem.Area = Funciones.CheckStr(dr["RCO_Area"]);
                    objItem.Tipo_Requisicion_ID = Funciones.CheckStr(dr["RCO_Tipo_Requisicion_ID"]);
                    objItem.Tipo_Requisicion = Funciones.CheckStr(dr["Tipo_Requisicion"]);
                    objItem.Orden_Compra = Funciones.CheckStr(dr["RCO_Orden_Compra"]);
                    objItem.Proveedor_OC = Funciones.CheckStr(dr["RCO_Proveedor_OC"]);
                    objItem.Solicitud = Funciones.CheckStr(dr["RCO_Solicitud"]);
                    objItem.Moneda_Presupuesto = Funciones.CheckStr(dr["RCO_Moneda_PRE"]);
                    objItem.Importe_Presupuesto = Funciones.CheckDbl(dr["RCO_Importe_PRE"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null && dr.IsClosed == false) dr.Close();
                objRequest.Parameters.Clear();
                objRequest.Factory.Dispose();
            }

            return objItem;
        }

        public DataTable ObtenerDetalleRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerRequerimientoCompra_Detalle;
            objRequest.Parameters.AddRange(arrParam);
            objRequest.SaveLog = false;

            try
            {
                return objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRequest.Factory.Dispose();
            }
        }

        public DataTable ObtenerDetalleRequerimientoCompra_Aprobacion(string CodCompania, string CodSucursal, string NumReq)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerRequerimientoCompra_Detalle_Aprobacion;
            objRequest.Parameters.AddRange(arrParam);
            objRequest.SaveLog = false;

            try
            {
                return objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRequest.Factory.Dispose();
            }
        }

        public DataTable ObtenerDetalleRequerimientoCompra_Adjuntos(string CodCompania, string CodSucursal, string NumReq)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerRequerimientoCompra_Detalle_Adjuntos;
            objRequest.Parameters.AddRange(arrParam);
            objRequest.SaveLog = false;

            try
            {
                return objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRequest.Factory.Dispose();
            }
        }

        public BERequerimientoCompra_OKAprobacion ObtenerOKUsuario_ApruebaRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;
            arrParam[3].Value = CodUser;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOKUsuario_ApruebaRQ;
            objRequest.Parameters.AddRange(arrParam);

            BERequerimientoCompra_OKAprobacion objItem = new BERequerimientoCompra_OKAprobacion();
            IDataReader dr = null;

            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem.OK_User = Funciones.CheckInt(dr["OK_User"]);
                    objItem.OK_Descri = Funciones.CheckStr(dr["Ok_Descri"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null && dr.IsClosed == false) dr.Close();
                objRequest.Parameters.Clear();
                objRequest.Factory.Dispose();
            }

            return objItem;
        }

        public BERequerimientoCompra_Resultado ObtenerResultado_ApruebaRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;
            arrParam[3].Value = CodUser;
            
            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerResultado_ApruebaRQ;
            objRequest.Parameters.AddRange(arrParam);

            BERequerimientoCompra_Resultado objItem = new BERequerimientoCompra_Resultado();
            IDataReader dr = null;

            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem.Codigo = Funciones.CheckInt(dr["Cod_Resultado"]);
                    objItem.Mensaje = Funciones.CheckStr(dr["Des_Resultado"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null && dr.IsClosed == false) dr.Close();
                objRequest.Parameters.Clear();
                objRequest.Factory.Dispose();
            }

            return objItem;
        }

        public BERequerimientoCompra_Resultado ObtenerResultado_DevuelveRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser, string Motivo)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_MOTIVO", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;
            arrParam[3].Value = CodUser;
            arrParam[4].Value = Motivo;
            arrParam[4].Size = 200;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerResultado_DevuelveRQ;
            objRequest.Parameters.AddRange(arrParam);

            BERequerimientoCompra_Resultado objItem = new BERequerimientoCompra_Resultado();
            IDataReader dr = null;

            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem.Codigo = Funciones.CheckInt(dr["Cod_Resultado"]);
                    objItem.Mensaje = Funciones.CheckStr(dr["Des_Resultado"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null && dr.IsClosed == false) dr.Close();
                objRequest.Parameters.Clear();
                objRequest.Factory.Dispose();
            }

            return objItem;
        }

        public BERequerimientoCompra_Resultado ObtenerResultado_RechazaRequerimientoCompra(string CodCompania, string CodSucursal, string NumReq, string CodUser, string Motivo)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMRQ", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_MOTIVO", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumReq;
            arrParam[3].Value = CodUser;
            arrParam[4].Value = Motivo;
            arrParam[4].Size = 200;


            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerResultado_RechazaRQ;
            objRequest.Parameters.AddRange(arrParam);

            BERequerimientoCompra_Resultado objItem = new BERequerimientoCompra_Resultado();
            IDataReader dr = null;

            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem.Codigo = Funciones.CheckInt(dr["Cod_Resultado"]);
                    objItem.Mensaje = Funciones.CheckStr(dr["Des_Resultado"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null && dr.IsClosed == false) dr.Close();
                objRequest.Parameters.Clear();
                objRequest.Factory.Dispose();
            }

            return objItem;
        }
    }
}
