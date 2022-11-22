using System;
using System.IO;
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
    public class DAOrdenCompra
    {
        
        public int RegistrarOrdenCompra(string Cia_codcia,string Suc_codsuc ,string Ocm_corocm,DateTime Occ_fecdoc,string Occ_tipocc, string tmo_codtmo,
          double Occ_tipcam,string Occ_gloocc,string Occ_lugent,string Occ_luginc,int Occ_indmaq,string Occ_indigv,double Occ_tasigv,double Occ_impbru,
          double Occ_pordes,double Occ_impde1,double Occ_impigv,double Occ_imptot,double Occ_totfob, double Occ_totfle,
		  double Occ_totseg,double Occ_totcyf,double Occ_tototr,double Occ_totcif,double Occ_portol,string Occ_sitapr,string Occ_sitlog,
		  string Occ_sitctb,int Occ_indalm,string Occ_indest,DateTime Occ_fecact,string Occ_codusu,int Occ_indsap,int Occ_locser,int Occ_indcfm,int Occ_tipcnt){

            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_COROCM", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_FECDOC", DbType.DateTime, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TIPOCC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODTMO", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TIPCAM", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_GLOOCC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_LUGENT", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_LUGINC", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_INDMAQ", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_INDIGV", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TASIGV", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_IMPBRU", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_PORDES", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_IMPDE1", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_IMPIGV", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_IMPTOT", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TOTFOB", DbType.Double, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TOTFLE", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TOTSEG", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TOTCYF", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TOTOTR", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TOTCIF", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_PORTOL", DbType.DateTime, ParameterDirection.Input),
                new DAABRequest.Parameter("P_SITAPR", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_SITLOG", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_SITCTB", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_INDALM", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_INDEST", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_FECACT", DbType.DateTime, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSU", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_INDSAP", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_LOCSER", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_INDCFM", DbType.Int16, ParameterDirection.Input),
                new DAABRequest.Parameter("P_TIPCNT", DbType.Int16, ParameterDirection.Input)
            };

            arrParam[0].Value  = Cia_codcia;
            arrParam[1].Value  = Suc_codsuc;
            arrParam[2].Value  = Ocm_corocm;
            arrParam[3].Value  = Occ_fecdoc;
            arrParam[4].Value  = Occ_tipocc;
            arrParam[5].Value  = tmo_codtmo;
            arrParam[6].Value  = Occ_tipcam;
            arrParam[7].Value  = Occ_gloocc;
            arrParam[8].Value  = Occ_lugent;
            arrParam[9].Value  = Occ_luginc;
            arrParam[10].Value = Occ_indmaq;
            arrParam[11].Value = Occ_indigv;
            arrParam[12].Value = Occ_tasigv;
            arrParam[13].Value = Occ_impbru;
            arrParam[14].Value = Occ_pordes;
            arrParam[15].Value = Occ_impde1;
            arrParam[16].Value = Occ_impigv;
            arrParam[17].Value = Occ_imptot;
            arrParam[18].Value = Occ_totfob;
            arrParam[19].Value = Occ_totfle;
            arrParam[20].Value = Occ_totseg;
            arrParam[21].Value = Occ_totcyf;
            arrParam[22].Value = Occ_tototr;
            arrParam[23].Value = Occ_totcif;
            arrParam[24].Value = Occ_portol;
            arrParam[25].Value = Occ_sitapr;
            arrParam[26].Value = Occ_sitlog;
            arrParam[27].Value = Occ_sitctb;
            arrParam[28].Value = Occ_indalm;
            arrParam[29].Value = Occ_indest;
            arrParam[30].Value = Occ_fecact;
            arrParam[31].Value = Occ_codusu;
            arrParam[32].Value = Occ_indsap;
            arrParam[33].Value = Occ_locser;
            arrParam[34].Value = Occ_indcfm;
            arrParam[35].Value = Occ_tipcnt;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spRegistrarOrdenCompraCab;
            objRequest.Parameters.AddRange(arrParam);
            try
            {
                return Int16.Parse(objRequest.Factory.ExecuteNonQuery(ref objRequest).ToString());
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
        public BEOrdenCompra ObtenerOrdenDeCompra(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };
            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Cab;
            objRequest.Parameters.AddRange(arrParam);

            BEOrdenCompra objItem = new BEOrdenCompra();
            IDataReader dr = null;

            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem.Serie = Funciones.CheckStr(dr["Occ_Serie"]);
                    objItem.Numero = Funciones.CheckStr(dr["Occ_Numero"]);
                    objItem.FechaEmision = Funciones.CheckDate(dr["OCC_Fecha"]);
                    objItem.Anho = Funciones.CheckStr(dr["Occ_Año"]);
                    objItem.ProveedorDireccion = Funciones.CheckStr(dr["Proveedor_Direccion"]);
                    objItem.ProveedorTelefono = Funciones.CheckStr(dr["Proveedor_Telefono"]);
                    objItem.Tipo = Funciones.CheckStr(dr["Terminnos_Compra"]);
                    objItem.Tipo_OC = Funciones.CheckStr(dr["OCC_Tipo_Id"]);
                    objItem.Estado = Funciones.CheckStr(dr["Occ_Estado"]);
                    objItem.EventoGenera = Funciones.CheckStr(dr["Occ_Evento"]);
                    objItem.AtencionTipoDoc = Funciones.CheckStr(dr["Occ_Atencion_TipDoc"]);
                    objItem.AtencionNumero = Funciones.CheckStr(dr["Occ_Atencion_Numero"]);
                    objItem.AtencionNombre = Funciones.CheckStr(dr["Occ_Atencion_Nombre"]);
                    objItem.AtencionCargo = Funciones.CheckStr(dr["Occ_Atencion_Cargo"]);
                    objItem.TipoCambio = Funciones.CheckDbl(dr["Occ_TipoCambio"]);
                    objItem.TasaIgv = Funciones.CheckDbl(dr["Occ_Tasa_IGV"]);
                    objItem.Situacion_Aprobado_ID = Funciones.CheckStr(dr["OCC_Situacion_Aprobado_ID"]);
                    objItem.Situacion_Aprobado = Funciones.CheckStr(dr["OCC_Situacion_Aprobado"]);
                    objItem.TipoCompra = Funciones.CheckStr(dr["Tipo_Solicitud"]);
                    objItem.Moneda = Funciones.CheckStr(dr["Moneda"]);
                    objItem.CondicionPago_1 = Funciones.CheckStr(dr["Occ_Condicion_Pago_Id"]);
                    objItem.CondicionPago_2 = Funciones.CheckStr(dr["Condicion_Pago"]);
                    objItem.NumeroCuotas = "0";
                    objItem.FechaEntrega = Funciones.CheckDate(dr["Occ_Fecha_Entrega"]);
                    objItem.LugarEntrega = Funciones.CheckStr(dr["Lugar_Entrega"]);
                    objItem.SujetoDetraccion = "NO";
                    objItem.Tasa = 0;
                    objItem.Requerimiento = "";
                    objItem.Glosa_OC = Funciones.CheckStr(dr["Occ_Glosa"]);
                    objItem.SituacionAtendido = Funciones.CheckStr(dr["Occ_Situacion_Logistica"]);
                    objItem.ControlAlmacenServicio = ((Funciones.CheckInt(dr["Occ_Indicador_Almacen"]) == 1) ? true : false);
                    objItem.CentroCosto = Funciones.CheckStr(dr["Occ_Centro_Costo_Id"]);
                    objItem.NombreCentroCosto = Funciones.CheckStr(dr["Centro_Costo"]);
                    objItem.Responsable = Funciones.CheckStr(dr["Occ_Empleado_Id"]);
                    objItem.NombreResponsable = Funciones.CheckStr(dr["Empleado"]);
                    objItem.IndicadorIGV = Funciones.CheckStr(dr["Occ_Indicador_IGV"]);
                    objItem.CalcularItem = Funciones.CheckStr(dr["Occ_Indicador_Calculo"]);

                    objItem.PorcTolerancia = Funciones.CheckDbl(dr["Occ_Tolerancia"]);
                    objItem.ImporteBruto = Funciones.CheckDbl(dr["Occ_Importe_bruto"]);
                    objItem.ImporteDescuento = Funciones.CheckDbl(dr["Occ_Importe_Descuento"]);
                    objItem.ValorVenta = Funciones.CheckDbl(dr["Occ_Importe_Valor_Venta"]);
                    objItem.ImporteIGV = Funciones.CheckDbl(dr["Occ_Importe_IGV"]);
                    objItem.ImporteTotal = Funciones.CheckDbl(dr["Occ_Importe_Total"]);

                    objItem.Contrato_Inicio = Funciones.CheckDate(dr["Contrato_Inicio"]);
                    objItem.Contrato_Final = Funciones.CheckDate(dr["Contrato_Final"]);
                    objItem.Contrato_File = Funciones.CheckStr(dr["Contrato_File"]);
                    objItem.CuadroComparativo_File = Funciones.CheckStr(dr["CuadroComparativo_File"]);
                    objItem.SoleSource_File = Funciones.CheckStr(dr["SoleSource_File"]);
                    objItem.SoleSource_File_CCO = Funciones.CheckStr(dr["SoleSource_File_CCO"]);
                    objItem.Solicitud = Funciones.CheckStr(dr["Solicitud"]);
                    objItem.Requisicion = Funciones.CheckStr(dr["Requisicion"]);
                    objItem.OCC_Ruta_Intranet = Funciones.CheckStr(dr["OCC_Ruta_intranet"]);
                    objItem.OCC_Ruta_Extranet = Funciones.CheckStr(dr["OCC_Ruta_Extranet"]);
                    objItem.RCO_Ruta_Intranet = Funciones.CheckStr(dr["RCO_Ruta_intranet"]);
                    objItem.RCO_Ruta_Extranet = Funciones.CheckStr(dr["RCO_Ruta_Extranet"]);
                    objItem.CCO_Ruta_Intranet = Funciones.CheckStr(dr["CCO_Ruta_intranet"]);
                    objItem.CCO_Ruta_Extranet = Funciones.CheckStr(dr["CCO_Ruta_Extranet"]);
                    objItem.Contrato_Link = objItem.OCC_Ruta_Intranet.Trim() + Path.GetFileName(objItem.Contrato_File);
                    objItem.CuadroComparativo_Link = objItem.OCC_Ruta_Intranet.Trim() + objItem.CuadroComparativo_File;
                    // Modificacion 20160609 Cambiar ruta del Sole Source
                    objItem.SoleSource_Link = "";
                    if (objItem.SoleSource_File_CCO.Length > 0)
                    {
                        objItem.SoleSource_Link = objItem.CCO_Ruta_Intranet.Trim() + objItem.SoleSource_File_CCO;
                    }
                    else
                    {
                        if (objItem.SoleSource_File.Length > 0)
                        {
                            objItem.SoleSource_Link = objItem.RCO_Ruta_Intranet.Trim() + objItem.SoleSource_File;
                        }
                    }

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

        public DataTable ObtenerDetalleOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle;
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

        public DataTable ObtenerDetalleOrdenCompra_Entrega(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle_Entrega;
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

        public DataTable ObtenerDetalleOrdenCompra_Aprobacion(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle_Aprobacion;
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

        public DataTable ObtenerDetalleOrdenCompra_CCosto(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle_CCosto;
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

        public DataTable ObtenerDetalleOrdenCompra_Pagos(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle_Pagos;
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

        public DataTable ObtenerDetalleOrdenCompra_Adelantos(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle_Adelantos;
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

        public List<BEOCReferencia> ObtenerDetalleOrdenCompra_Kardex(string CodCompania, string CodSucursal, string NumOrdenCompra)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input)
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOrdenCompra_Detalle_Adelantos;
            objRequest.Parameters.AddRange(arrParam);
            objRequest.SaveLog = false;

            List<BEOCReferencia> objLista = new List<BEOCReferencia>();
            BEOCReferencia objItem = null;
            IDataReader dr = null;
            try
            {
                dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
                while (dr.Read())
                {
                    objItem = new BEOCReferencia();
                    objItem.AtencionAlmacen = Funciones.CheckStr(dr["KARDEX"]);
                    objLista.Add(objItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null && dr.IsClosed == false) dr.Close();
                objRequest.Factory.Dispose();
            }
            return objLista;
        }

        public BEOrdenCompra_OKAprobacion ObtenerOKUsuario_ApruebaOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;
            arrParam[3].Value = CodUser;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerOKUsuario_ApruebaOC;
            objRequest.Parameters.AddRange(arrParam);

            BEOrdenCompra_OKAprobacion objItem = new BEOrdenCompra_OKAprobacion();
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

        public BEOrdenCompra_Resultado ObtenerResultado_ApruebaOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;
            arrParam[3].Value = CodUser;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerResultado_ApruebaOC;
            objRequest.Parameters.AddRange(arrParam);

            BEOrdenCompra_Resultado objItem = new BEOrdenCompra_Resultado();
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

        public BEOrdenCompra_Resultado ObtenerResultado_DevuelveOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser, string Motivo)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_MOTIVO", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;
            arrParam[3].Value = CodUser;
            arrParam[4].Value = Motivo;
            arrParam[4].Size = 200;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerResultado_DevuelveOC;
            objRequest.Parameters.AddRange(arrParam);

            BEOrdenCompra_Resultado objItem = new BEOrdenCompra_Resultado();
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

        public BEOrdenCompra_Resultado ObtenerResultado_RechazaOrdenCompra(string CodCompania, string CodSucursal, string NumOrdenCompra, string CodUser, string Motivo)
        {
            DAABRequest.Parameter[] arrParam = {
                new DAABRequest.Parameter("P_CODCIA", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODSUC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_NUMOC", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_CODUSR", DbType.String, ParameterDirection.Input),
                new DAABRequest.Parameter("P_MOTIVO", DbType.String, ParameterDirection.Input),
            };

            arrParam[0].Value = CodCompania;
            arrParam[1].Value = CodSucursal;
            arrParam[2].Value = NumOrdenCompra;
            arrParam[3].Value = CodUser;
            arrParam[4].Value = Motivo;
            arrParam[4].Size = 200;

            BDLAVALINWEB obj = new BDLAVALINWEB();
            DAABRequest objRequest = obj.CreaRequest(new StackTrace(true));
            objRequest.CommandType = CommandType.StoredProcedure;
            objRequest.Command = BaseDatos.spObtenerResultado_RechazaOC;
            objRequest.Parameters.AddRange(arrParam);

            BEOrdenCompra_Resultado objItem = new BEOrdenCompra_Resultado();
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
