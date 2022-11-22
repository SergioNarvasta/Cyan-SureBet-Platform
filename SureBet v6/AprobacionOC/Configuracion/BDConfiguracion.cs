using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion
{
    public class BDConfiguracion : IBDConfiguracion
    {
        public string Servidor { get; set; }
        public string BaseDatos { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Provider { get; set; }
        public string Idioma { get; set; }
        public string Sistema { get; set; }
        public string MaxPoolSize { get; set; }
        public string MinPoolSize { get; set; }
        public string ConnectionLifetime { get; set; }
        public string Pooling { get; set; }
        public string CadenaConexion
        {
            get
            {
                string cadena = string.Empty;
                if (Pooling == null) Pooling = string.Empty;
                if (MaxPoolSize == null) MaxPoolSize = string.Empty;
                if (MinPoolSize == null) MinPoolSize = string.Empty;
                if (ConnectionLifetime == null) ConnectionLifetime = string.Empty;
                if (Pooling == null) Pooling = string.Empty;

                if (Provider.IndexOf("ORA") > 0 || Provider.Equals(string.Empty))
                {
                    //Para conexion a ORACLE
                    cadena = "User Id=" + ((Usuario == null) ? string.Empty : Usuario) + ";Data Source=" + ((BaseDatos == null) ? string.Empty : BaseDatos) + ";password=" + ((Password == null) ? string.Empty : Password);
                    cadena += ((Pooling == "") ? string.Empty : string.Format(";Pooling='{0}';", Pooling));
                    cadena += ((MaxPoolSize == "") ? string.Empty : string.Format("Max Pool Size={0};", MaxPoolSize));
                    cadena += ((MinPoolSize == "") ? string.Empty : string.Format("Min Pool Size={0};", MinPoolSize));
                    cadena += ((ConnectionLifetime == string.Empty ? string.Empty : string.Format("Connection Lifetime={0};", ConnectionLifetime)));
                    return cadena;
                }
                else
                {
                    cadena = "User Id=" + ((Usuario == null) ? string.Empty : Usuario) + ";Data Source=" + ((Servidor == null) ? string.Empty : Servidor) + ";password=" + ((Password == null) ? string.Empty : Password) + ";Initial Catalog=" + ((BaseDatos == null) ? string.Empty : BaseDatos);
                    return cadena;
                }
            }
        }

    }
}
