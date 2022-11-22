using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Configuracion
{
    public class ConfigConexionOC
    {
        private static BDConfiguracion pmConf;
        private static Mutex mMutex = new Mutex();
        private static ConfigConexionOC mInstancia;

        public ConfigConexionOC(string sBaseDatos, string sUsuarioBD, string sPassword, string sServidor, string sProvider)
        {
            try
            {
                pmConf = new BDConfiguracion();
                pmConf = ConexionBD(sBaseDatos, sUsuarioBD, sPassword, sServidor, sProvider);

            }
            catch
            {
                throw;
            }
        }

        private BDConfiguracion ConexionBD(string sBaseDatos, string sUsuarioBD, string sPassword, string sServidor, string sProvider)
        {
            pmConf = new BDConfiguracion
            {
                BaseDatos = sBaseDatos,
                Usuario = sUsuarioBD,
                Password = sPassword,
                Servidor = sServidor,
                Provider = sProvider
            };

            return pmConf;
        }


        public static ConfigConexionOC GetInstance(string sBaseDatos, string sUsuarioBD, string sPassword, string sServidor, string sProvider)
        {
            mMutex.WaitOne();
            if ((mInstancia == null))
            {
                mInstancia = new ConfigConexionOC(sBaseDatos, sUsuarioBD, sPassword, sServidor, sProvider);
            }
            mMutex.ReleaseMutex();
            return mInstancia;
        }

        public BDConfiguracion Parametros
        {
            get
            {
                return pmConf;
            }
        }

    }
}
