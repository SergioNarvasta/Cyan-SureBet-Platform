using System;
using System.Configuration;
using Configuracion;
using IData;
using System.Diagnostics;

namespace Data
{
    public class BDLAVALINWEB
    {
        protected string msBaseDatos;
        protected string msUsuarioBD;
        protected string msPassword;
        protected string msServidor;
        protected string msProvider;
        protected BDConfiguracion mConfiguracion;

        public BDLAVALINWEB()
        {
            msBaseDatos = LeerBaseDatos;
            msUsuarioBD = LeerUsuarioBD;
            msPassword = LeerPassword;
            msServidor = LeerServidor;
            msProvider = LeerProvider;
        }

        protected IBDConfiguracion Configuracion
        {
            get
            {
                return GeneraConfiguracion();
            }
        }

        private IBDConfiguracion GeneraConfiguracion()
        {
            if (mConfiguracion == null)
            {
                if (string.IsNullOrEmpty(msBaseDatos))
                {
                    throw new ApplicationException("No ha especificado el nombre de Base de Datos");
                }

                if (string.IsNullOrEmpty(msBaseDatos))
                {
                    throw new ApplicationException("No se encuentra el Key de Base de Datos en el Archivo de Configuracion");
                }
                mConfiguracion = ConfigConexionOC.GetInstance(msBaseDatos, msUsuarioBD, msPassword, msServidor, msProvider).Parametros;
            }
            return mConfiguracion;
        }

        public DAABRequest CreaRequest()
        {
            DAABRequest.TipoOrigenDatos obOrigen;
            
            obOrigen = DAABRequest.TipoOrigenDatos.SQL;
            return new DAABRequest(obOrigen, Configuracion.CadenaConexion, Configuracion.BaseDatos);
        }

        public DAABRequest CreaRequest(StackTrace stTrace)
        {
            DAABRequest.TipoOrigenDatos obOrigen;
            
            obOrigen = DAABRequest.TipoOrigenDatos.SQL;
            return new DAABRequest(obOrigen, Configuracion.CadenaConexion, Configuracion.BaseDatos, stTrace);
        }

        protected string LeerBaseDatos
        {
            get
            {
                return ConfigurationManager.AppSettings["strBaseDatos"];
            }
        }
        protected string LeerUsuarioBD
        {
            get
            {
                return ConfigurationManager.AppSettings["strUsuarioBD"];
            }
        }
        protected string LeerPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["strPaswordBD"];
            }
        }
        protected string LeerServidor
        {
            get
            {
                return ConfigurationManager.AppSettings["strServidorBD"];
            }
        }
        protected string LeerProvider
        {
            get
            {
                return ConfigurationManager.AppSettings["strProviderBD"];
            }
        }
    }
}
