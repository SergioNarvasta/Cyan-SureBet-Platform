using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.Mail;
using System.Globalization;

namespace Comunes
{
    public class Funciones
    {
        public Funciones()
        {
        }
        public static Nullable<T> DbValueToNullable<T>(object dbValue) where T : struct
        {
            Nullable<T> returnValue = null;

            if ((dbValue != null) && (dbValue != DBNull.Value))
            {
                returnValue = (T)dbValue;
            }

            return returnValue;
        }

        public static T DbValueToDefault<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value) return default(T);
            else { return (T)obj; }
        }

        static public bool isNumeric(object value)
        {
            bool resultado;
            double numero;

            resultado = Double.TryParse(Convert.ToString(value), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numero);
            return resultado;

        }
        //funcion adicionada para validar
        static public string ConvertSoles(object value)
        {
            string salida = "0";
            if (value == null || value == System.DBNull.Value)
            {
                salida = "0";
            }
            else
            {
                if (Convert.ToString(value) == "")
                    salida = "0";
                else
                    salida = Convert.ToString((Convert.ToDouble(value) / 100));
            }
            return salida;
        }

        static public bool IsNumeric(string input)
        {
            bool flag = true;
            //Valid user input 
            string pattern = @"^[0-9]*$";
            Regex validate = new Regex(pattern);
            //Check the user input format 
            if (!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }
        bool IsNumeric2(string inputString)
        {
            return Regex.IsMatch(inputString, "^[0-9]+$");
        }


        static public string CheckStr(object value)
        {
            string salida = "";
            if (value == null || value == System.DBNull.Value)
                salida = "";
            else
                salida = value.ToString();
            return salida.Trim();
        }

        static public Int64 CheckInt64(object value)
        {
            Int64 salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == "")
                    salida = 0;
                else
                    salida = Convert.ToInt64(value);
            }
            return salida;
        }

        static public float CheckFloat(object value)
        {
            float salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == "")
                    salida = 0;
                else
                    salida = float.Parse(value.ToString());//.ToString("#,##0.00");
            }
            return salida;
        }


        static public int CheckInt(object value)
        {
            int salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
                    salida = 0;
                else
                    salida = Convert.ToInt32(value);
            }
            return salida;
        }

        static public double CheckDbl(object value)
        {
            double salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
                    salida = 0;
                else
                    salida = Convert.ToDouble(value);
            }
            return salida;
        }

        static public double CheckDbl(object value, int nroDecimales)
        {
            double salida = CheckDbl(value);
            if (salida == 0) return salida;
            return redondearMontos(salida, nroDecimales);
        }

        static public decimal CheckDecimal(object value)
        {
            decimal salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
                    salida = 0;
                else
                    salida = Convert.ToDecimal(value);
            }
            return salida;
        }

        static public double redondearMontos(double value, int nroDecimales)
        {
            return Math.Round(value, nroDecimales);
        }

        static public DateTime CheckDate(object value)
        {
            if (value == null || value == System.DBNull.Value)
                return new DateTime(1, 1, 1);

            if (value.ToString() == "")
                return new DateTime(1, 1, 1);

            if (value.ToString() == "00000000")
                return new DateTime(1, 1, 1);

            return Convert.ToDateTime(value);
        }

        public static System.Data.DataTable dtParams()
        {
            System.Data.DbType tipo = new System.Data.DbType();
            System.Data.ParameterDirection direccion = new System.Data.ParameterDirection();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Nombre", System.Type.GetType("System.String"));
            dt.Columns.Add("Tipo", tipo.GetType());
            dt.Columns.Add("Size", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Direccion", direccion.GetType());
            dt.Columns.Add("Valor", System.Type.GetType("System.Object"));

            return dt;
        }

        public static bool InsertarParam(System.Data.DataTable vdtParams,
            string vName,
            System.Data.DbType vType,
            int vSize,
            System.Data.ParameterDirection vDirection,
            object vValue)
        {

            System.Data.DataRow dr = vdtParams.NewRow();
            dr["Nombre"] = vName;
            dr["Tipo"] = vType;
            if (vSize == 0)
                dr["Size"] = 0;
            else
                dr["Size"] = vSize;

            dr["Direccion"] = vDirection;

            if (vValue == null)
                dr["Valor"] = DBNull.Value;
            else
                dr["Valor"] = vValue;

            vdtParams.Rows.Add(dr);
            return true;
        }

        public static double ConvertSolesToCentimos(double vMonto)
        {
            return (vMonto * 100);
        }

        public static DataTable TablaActividad()
        {
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("eventColor", typeof(string));

            return dt;
        }
        public static int UltimoDiaMes(int mes, int anno)
        {
            int dia = 0;
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 10 || mes == 12)
            {
                dia = 31;
            }
            else if (mes == 4 || mes == 6 || mes == 8 || mes == 9 || mes == 11)
            {
                dia = 30;
            }
            else if (mes == 2)
            {
                if ((anno % 4) == 0 & (anno % 100) == 0)
                {
                    dia = 29;
                }
                else
                {
                    dia = 28;
                }
            }
            return dia;
        }
        public static string NVLString(string valor1, string valor2)
        {
            string v1 = CheckStr(valor1);
            string v2 = CheckStr(valor2);
            if (v1 != "")
                return v1;
            else
                return v2;
        }
        public static DateTime NVLDate(DateTime valor1, DateTime valor2)
        {
            DateTime v1 = CheckDate(valor1);
            DateTime v2 = CheckDate(valor2);
            if (v1 != new DateTime(1, 1, 1))
                return v1;
            else
                return v2;
        }


        public static string FormarNroDocumentoIdentidad(string nro)
        {
            string salida = nro;
            if (salida.Equals("")) return "";
            salida = nro.PadLeft(16, '0');
            return salida;
        }

        public static string ReemplazarCaracterInvalido(string valor)
        {
            if (valor == null) return "";
            if (valor.Trim() == "") return "";
            int intPos = 0;
            string strCadenaInvalida = "ñ,Ñ,á,é,í,ó,ú,Á,É,Í,Ó,Ú,ä,ë,ï,ö,ü,Ä,Ë,Ï,Ö,Ü";
            string strCadenaValida = "n,N,a,e,i,o,u,A,E,I,O,U,a,e,i,o,u,A,E,I,O,U";
            string[] ArrInvalida = strCadenaInvalida.Split(',');
            string[] ArrValida = strCadenaValida.Split(',');
            int i = 0;
            for (i = 0; i < ArrInvalida.Length; i++)
            {
                intPos = valor.IndexOf(ArrInvalida[i]);
                if (intPos != -1)
                {
                    valor = valor.Replace(ArrInvalida[i], ArrValida[i]);
                }
            }
            return valor;
        }


        static public Int16 CheckInt16(object value)
        {
            Int16 salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == "")
                    salida = 0;
                else
                    salida = Convert.ToInt16(value);
            }
            return salida;
        }

        public static string validarvacio(string cadena)
        {
            string newvalor;
            if (cadena.Equals(string.Empty) || cadena.Equals("0") || cadena.Equals("-1"))
            {
                newvalor = null;
            }
            else
            {
                newvalor = cadena;
            }
            return newvalor;
        }

        public static DateTime DevuelveFormatoFecha(string cadena)
        {
            DateTime fecha;
            if (cadena.Equals(string.Empty) || cadena.Equals("0"))
            {
                fecha = new DateTime(1900, 1, 1);
            }
            else
            {
                string nuevacad = cadena.Substring(6, 2) + "/" + cadena.Substring(4, 2) + "/" + cadena.Substring(0, 4);
                fecha = Convert.ToDateTime(nuevacad);
            }
            return fecha;
        }

        public static string DevuelveFormatoFechaStr(string cadena)
        {
            String fecha;
            if (cadena.Equals(string.Empty) || cadena.Equals("0"))
            {
                fecha = "";
            }
            else
            {
                String nuevacad = cadena.Substring(0, 2) + "/" + cadena.Substring(2, 2) + "/" + cadena.Substring(4, 4);
                fecha = nuevacad;
            }

            try
            {
                DateTime dt = Convert.ToDateTime(fecha);
                if (Convert.ToInt16(cadena.Substring(4, 4)) <= 1913)
                {
                    String nuevacad = cadena.Substring(6, 2) + "/" + cadena.Substring(4, 2) + "/" + cadena.Substring(0, 4);
                    fecha = nuevacad;
                }

            }
            catch (Exception)
            {

                String nuevacad = cadena.Substring(6, 2) + "/" + cadena.Substring(4, 2) + "/" + cadena.Substring(0, 4);
                fecha = nuevacad;
            }



            return fecha;
        }

        public static string ConvertirFecha(string vFecha)
        {
            string fecha = "";
            if (vFecha == "00000000")
            {
                return "";
            }
            if (vFecha.Length >= 6)
            {
                fecha = String.Format("{0}/{1}/{2}", vFecha.Substring(6, 2), vFecha.Substring(4, 2), vFecha.Substring(0, 4));
                fecha = Convert.ToDateTime(fecha).ToShortDateString();
            }
            return fecha;

        }

        static public bool IsContratoVacio(string sNroContrato)
        {
            sNroContrato = sNroContrato.Replace("0", "");
            return (sNroContrato.Trim().Equals(""));
        }

        public static string FormatoFecha(string Fecha)
        {
            if (Fecha.Length > 0)
                return Fecha.Substring(0, 4) + "/" + Fecha.Substring(5, 2) + "/" + Fecha.Substring(8, 2);
            else
                return "0000/00/00";
        }

        public static decimal FormatoDec(string valor)
        {
            decimal res = 0;
            if (valor.Trim() != "")
            {
                res = Convert.ToDecimal(valor);
            }
            return res;
        }

        public static string FormatoDecStr(string valor)
        {
            string res = "0";
            if (valor.Trim() != "")
            {
                res = valor;
            }
            return res;
        }

        public static string FormatoFechaSap(string fecha)
        {
            if (fecha.Length > 0)
                return fecha.Substring(6, 4) + "/" + fecha.Substring(3, 2) + "/" + fecha.Substring(0, 2);
            else
                return "0000/00/00";
        }


        public static string obtenerParametro(string cadena, int lenght)
        {
            int index = cadena.Length - lenght;
            string subcadena = cadena.Substring(index, lenght);
            return subcadena;
        }


        public static string ObtenerContentType(string strExtArchivo)
        {
            strExtArchivo = strExtArchivo.ToLower();

            if (strExtArchivo == ".htm" | strExtArchivo == ".html")
            {
                return "text/html";
            }
            else if (strExtArchivo == ".xls")
            {
                return "application/vnd.ms-excel";
            }
            else if (strExtArchivo == ".txt")
            {
                return "text/plain";
            }
            else if (strExtArchivo == ".pdf")
            {
                return "application/pdf";
            }
            else if (strExtArchivo == ".xml")
            {
                return "text/xml";
            }
            else if (strExtArchivo == ".doc" || strExtArchivo == ".docx")
            {
                return "application/msword";
            }
            else if (strExtArchivo == ".rtf")
            {
                return "application/rtf";
            }
            else if (strExtArchivo == ".odt")
            {
                return "application/vnd.oasis.opendocument.text";
            }
            else if (strExtArchivo == ".ods")
            {
                return "application/vnd.oasis.opendocument.spreadsheet";
            }
            else if (strExtArchivo == ".png")
            {
                return "image/png";
            }
            else if (strExtArchivo == ".jpg" | strExtArchivo == ".jpeg")
            {
                return "image/jpeg";
            }
            else if (strExtArchivo == ".gif")
            {
                return "image/gif";
            }
            else if (strExtArchivo == ".bmp")
            {
                return "image/bmp";
            }
            else if (strExtArchivo == ".tif" | strExtArchivo == ".tiff")
            {
                return "image/tiff";
            }
            else if (strExtArchivo == ".zip")
            {
                return "application/zip";
            }
            else if (strExtArchivo == ".rar")
            {
                return "application/x-rar-compressed";
            }
            else if (strExtArchivo == ".ppt")
            {
                return "application/mspowerpoint";
            }
            else if (strExtArchivo == ".swf")
            {
                return "application/x-shockwave-flash";
            }
            else
            {
                return "application/octet-stream";
            }
        }

        public static string Right(string param, int length)
        {
            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        public static string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }



        public static double CalculodeMb(int tamanio)
        {
            double tamanioMb = (tamanio / 1048576);
            return tamanioMb;
        }

        public static int CalculodeKb(int tamanio)
        {
            int tamanioKb = (tamanio / 1024);
            return tamanioKb;
        }
    }
}
