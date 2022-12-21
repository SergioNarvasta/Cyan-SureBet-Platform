using System;
using System.Text;

namespace Configuracion
{
    public interface IBDConfiguracion
    {

        string Servidor
        {
            get;
            set;

        }

        string BaseDatos
        {
            get;
            set;

        }

        string Usuario
        {
            get;
            set;

        }

        string Password
        {
            get;
            set;

        }

        string Provider
        {
            get;
            set;

        }

        string Idioma
        {
            get;
            set;

        }


        string Sistema
        {
            get;
            set;

        }

        string MaxPoolSize
        {
            get;
            set;
        }

        string MinPoolSize
        {
            get;
            set;
        }

        string ConnectionLifetime
        {
            get;
            set;
        }

        string Pooling
        {
            get;
            set;
        }

        string CadenaConexion
        {
            get;

        }

    
    }
}
