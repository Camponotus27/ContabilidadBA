using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Herramientas
{
    public class Formateador
    {
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name);
            }

            return table;
        }

        public static string FormatearRut(string rut_param, string dv_param)
        { 
            string rutTemporal = "";
            char[] charArray = rut_param.ToString().ToCharArray();
            Array.Reverse(charArray);
            string rut = new string(charArray);

            for (int i = rut.Length - 1; i >= 0; i--)
            {
                rutTemporal += rut[i];
                if (i % 3 == 0)
                    rutTemporal += ".";
            }

            return rutTemporal.Substring(0, rutTemporal.Length - 1) + "-" + dv_param;
        }

        public static string BuscarErrorSignificativo(Exception ex)
        {
            Exception ex_temp = ex;

            while (ex_temp.Message == "Se han producido uno o varios errores." && ex_temp.InnerException != null)
            {
                ex_temp = ex_temp.InnerException;
            }

            return ex_temp.Message;
        }

        public static string NombreEquipo()
        {
            return Environment.MachineName;
        }

        public static string GenerarCodigoBarra(string codigo_producto, string prefijo)
        {
            if (codigo_producto == "")
            {
                return "0000000000000";
            }

            string ean13;
            int largo_ean_13 = 12; // sin codigo verificador

            int cantidad_relleno = largo_ean_13 - prefijo.Length;

            //// ean 13 sin codigo verificador
            ean13 = prefijo + codigo_producto.PadLeft(cantidad_relleno, '0');

            ean13 = ean13 + Convert.ToString(Formateador.NumeroVerificadorEAN13(ean13));

            return ean13;
        }

        public static string RootPath()
        {
            return Application.StartupPath;
        }

        public static string ToStringDB(DateTime? fecha)
        {
            if (fecha == null)
                return string.Empty;

            DateTime fecha_temporal = (DateTime)fecha;
            return fecha_temporal.ToString("yyyy-MM-dd");
        }

        public static string DateToTextDB(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd");
        }

        public static string DateToTextMostrar(DateTime fecha)
        {
            return fecha.ToString("dd-MM-yyyy");
        }

        /// <summary>
        /// Indica tiempo actual
        /// </summary>
        /// <returns></returns>
        public static DateTime Ahora()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// India el primer dia del mes, por defecto del mes actual, pero se pude suministrar una fecha para calcular el primero de esa fecha
        /// </summary>
        /// <param name="fecha">fecha para calcular del primer dia del mes de esa fecha, si no se suministra esa fecha es la actual</param>
        /// <returns>Primer dia del mes</returns>
        public static DateTime PrimeroMes(DateTime? fecha = null)
        {
            DateTime fecha_temp;

            if (fecha == null)
                fecha_temp = Formateador.Ahora();
            else
                fecha_temp = (DateTime)fecha;

            return new DateTime(fecha_temp.Year, fecha_temp.Month, 1);
        }

        public static string DateToTextMostrar(DateTime? fecha)
        {
            if (fecha == null)
                return string.Empty;

            DateTime fecha_anulacion = (DateTime)fecha;

            return DateToTextMostrar(fecha_anulacion);
        }

        public static string DateTimeToTextMostrar(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string DateTimeToTextMostrar(DateTime? fecha)
        {
            if (fecha == null)
                return string.Empty;

            DateTime fecha_anulacion = (DateTime)fecha;

            return DateTimeToTextMostrar(fecha_anulacion);
        }

        public static string DateToTextDB(DateTime? fecha)
        {
            if (fecha == null)
                return null;


            return DateToTextDB((DateTime)fecha);
        }

        /// <summary>
        /// Permite una clonación en profundidad de origen
        /// </summary>
        /// <param name="origen">Objeto serializable</param>
        /// <exception cref="ArgumentExcepcion">
        /// Se produce cuando el objeto no es serializable.
        /// </exception>
        /// <remarks>Extraido de 
        /// http://es.debugmodeon.com/articulo/clonar-objetos-de-estructura-compleja
        /// </remarks>
        public static T Copia<T>(T origen)
        {
            // Verificamos que sea serializable antes de hacer la copia            
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("La clase " + typeof(T).ToString() + " no es serializable");

            // En caso de ser nulo el objeto, se devuelve tal cual
            if (Object.ReferenceEquals(origen, null))
                return default(T);

            //Creamos un stream en memoria            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                try
                {
                    formatter.Serialize(stream, origen);
                    stream.Seek(0, SeekOrigin.Begin);
                    //Deserializamos la porcón de memoria en el nuevo objeto                
                    return (T)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                { throw new ArgumentException(ex.Message, ex); }
                catch { throw; }
            }
        }

        public static bool EsUnControlFocuseable(Control ctl)
        {
            if (!ctl.CanFocus)
                return false;
            else if (!ctl.Enabled)
                return false;
            else if (ctl is TextBox)
            {
                TextBox txt = (TextBox)ctl;
                if (txt.ReadOnly)
                    return false;

                if (!txt.Visible)
                    return false;
            }

            return true;
        }

        public static string Acortar(string texto, int largo_maximo)
        {
            if (texto.Length > largo_maximo)
                return texto.Substring(0, largo_maximo);

            return texto;
        }

        public static string NumeroAPesos(string numeros)
        {
            string numeroPesos = "";
            int contador = 1;
            bool isNegatico = false;

            if (numeros.Length > 0)
            {

                int numero_int = Convert.ToInt32(numeros);
                if (numero_int < 0)
                {
                    isNegatico = true;
                    numeros = (numero_int*-1).ToString();
                    numeros = numeros.ToString();
                }

                for (int i = numeros.Length - 1; i >= 0; i--)
                {
                    numeroPesos = numeros[i] + numeroPesos;
                    if (contador % 3 == 0 && contador != numeros.Length)
                        numeroPesos = "." + numeroPesos;
                    contador++;
                }

                
                if (isNegatico)
                    numeroPesos = "-" + numeroPesos;
                
            }else
                numeroPesos = "0";

            return "$" + numeroPesos;
        }

        public static string NumeroAPesos(long restantes)
        {
            return NumeroAPesos(restantes.ToString());
        }

        public static string GirarFechaConGuion(string fecha)
        {
            // "2015-06-24"

            string[] arrayFecha = fecha.Split('-');


            string temporal = "";
            foreach (string a in arrayFecha)
            {
                temporal = a + "-" + temporal;
            }

            return temporal.Remove(temporal.Length - 1);
        }
        public static decimal RedondeoMultiplo(decimal numero, int multiplo)
        {
            numero = numero / multiplo;
            numero = Math.Round(numero, 0);
            numero = numero * 10;
            return numero;
        }

        public static string PrepatarConvertNumerico(string stringToNumber)
        {
            if (stringToNumber == string.Empty || stringToNumber == "" || stringToNumber == null)
                return "0";
            else
                return stringToNumber;
        }

        public static int ToInt32(string stringNumero)
        {
    
            if (string.IsNullOrEmpty(stringNumero))
                return 0;

            stringNumero = stringNumero.Trim();
            stringNumero = stringNumero.Replace(".", "");

            if (stringNumero == string.Empty || stringNumero == "" || stringNumero == null)
                return 0;
            else
                return Convert.ToInt32(Math.Round(Convert.ToDecimal(stringNumero)));
        }

        public static string ToStringWordPress(object obj)
        {
            string input = Formateador.ToString(obj);

            string output = Regex.Replace(input, @"[^\w\s.!@$%&*()]+", "-");

            return output;
        }

        public static uint ToUInt32(string stringNumero)
        {
            stringNumero = stringNumero.Replace(".", "");

            if (stringNumero == string.Empty || stringNumero == "" || stringNumero == null)
                return 0;
            else
                return Convert.ToUInt32(Math.Round(Convert.ToDecimal(stringNumero)));
        }

        public static int ToInt32(object objNumero)
        {
            if (objNumero == null)
                return 0;
            else
                return Formateador.ToInt32(Convert.ToString(objNumero));
        }

        public static uint ToUInt32(object objNumero)
        {
            if (objNumero == null)
                return 0;
            else
                return Formateador.ToUInt32(Convert.ToString(objNumero));
        }

        public static decimal ToDecimalMayor(decimal primer_decimal, decimal segundo_decimal)
        {
            if (primer_decimal > segundo_decimal)
                return primer_decimal;

            return segundo_decimal;
        }

        public static int ToInt32(TextBox textBox)
        {
            if (textBox == null)
                return 0;

            return Formateador.ToInt32(textBox.Text);
        }

        public static object getBoolDB(object bool_dv)
        {
            string bool_string = Formateador.ToString(bool_dv);
            if (bool_string == "1")
                return true;
            else
                return false;
        }

        public static DateTime? ToDateTime(object date)
        {
            string date_str = Formateador.ToString(date);
            if(DateTime.TryParse(date_str, out DateTime result))
            {
                return result;
            }

            return null;
        }

        public static float ToSingle(object objNumero)
        {
            if (objNumero == null)
                return 0;
            else
                return Formateador.ToSigle(objNumero.ToString());
        }

        public static float ToSigle(string stringNumero)
        {
            if (stringNumero == string.Empty || stringNumero == "" || stringNumero == null)
                return 0;
            else
                return Convert.ToSingle(stringNumero);
        }

        /// <summary>
        /// Permite dividir dos valores sin riesgo a un error por que el denominador sea 0, si pasa ese caso el resultado es cero
        /// </summary>
        /// <param name="primer_decimal"></param>
        /// <param name="segundo_decimal"></param>
        /// <returns>resultado divicion si el segundo decimal es cero, el resultado tambien lo será</returns>
        public static decimal Dividir(decimal primer_decimal, decimal segundo_decimal)
        {
            if (segundo_decimal == 0)
                return 0;

            return primer_decimal / segundo_decimal;
        }

        public static decimal ToDecimal(string stringNumero)
        {
            if (stringNumero == string.Empty || stringNumero == "" || stringNumero == null)
                return 0;
            else
                return Convert.ToDecimal(stringNumero);
        }

        public static decimal ToDecimal(TextBox txt)
        {
            return Formateador.ToDecimal(txt.Text);
        }

        public static decimal ToDecimal(object objectNumero)
        {
            if (objectNumero == null)
                return 0;

            string stringNumero = Convert.ToString(objectNumero);

            if(stringNumero == string.Empty || stringNumero == "")
                return 0;
            
            return Convert.ToDecimal(objectNumero);
        }

        public static bool IsCaracterDigito(char c)
        {
            return (
                    c == '0'
                    || c == '1'
                    || c == '2'
                    || c == '3'
                    || c == '4'
                    || c == '5'
                    || c == '6'
                    || c == '7'
                    || c == '8'
                    || c == '9');
        }

        public static bool IsCaracterDigito(string c)
        {
            return (
                    c == "0"
                    || c == "1"
                    || c == "2"
                    || c == "3"
                    || c == "4"
                    || c == "5"
                    || c == "6"
                    || c == "7"
                    || c == "8"
                    || c == "9");
        }

        public static int actualizarSaldoRespectoACuentaContable(int saldo, int debe, int haber, int cuenta_contable)
        {
            string cuenta_contable_string = cuenta_contable.ToString();

            string inicio_cuenta_contable = cuenta_contable_string.Substring(0, 1);
            if (inicio_cuenta_contable == "1" || inicio_cuenta_contable == "3" || inicio_cuenta_contable == "2")
                return saldo + debe - haber;
            else
                return saldo + haber - debe;
        }

        /// <summary>
        /// devuelce el nombre del mes indicado
        /// </summary>
        /// <param name="mes_num"> 1 para enero 12 para diciembre</param>
        /// <returns></returns>
        public static string NombreMes(int mes_num)
        {
            if (mes_num < 1)
                mes_num = 1;

            if (mes_num > 12)
                mes_num = 12;

            string[] meses = Formateador.ArregloMeses();

            return meses[mes_num - 1];
        }

        public static string[] ArregloMeses()
        {
            return new string[] {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            }; 
        }

        public static string getOrigen(string origen)
        {
            if (origen == "V")
                return "Ventas";
            else if (origen == "C")
                return "Compras";

            return "Sin espesificar";    
        }

        public static bool IsValidGtin(string code)
        {
            if (code != (new Regex("[^0-9]")).Replace(code, ""))
            {
                // is not numeric
                return false;
            }
            // pad with zeros to lengthen to 14 digits
            switch (code.Length)
            {
                case 8:
                    code = "000000" + code;
                    break;
                case 12:
                    code = "00" + code;
                    break;
                case 13:
                    code = "0" + code;
                    break;
                case 14:
                    break;
                default:
                    // wrong number of digits
                    return false;
            }
            // calculate check digit
            int[] a = new int[13];
            a[0] = int.Parse(code[0].ToString()) * 3;
            a[1] = int.Parse(code[1].ToString());
            a[2] = int.Parse(code[2].ToString()) * 3;
            a[3] = int.Parse(code[3].ToString());
            a[4] = int.Parse(code[4].ToString()) * 3;
            a[5] = int.Parse(code[5].ToString());
            a[6] = int.Parse(code[6].ToString()) * 3;
            a[7] = int.Parse(code[7].ToString());
            a[8] = int.Parse(code[8].ToString()) * 3;
            a[9] = int.Parse(code[9].ToString());
            a[10] = int.Parse(code[10].ToString()) * 3;
            a[11] = int.Parse(code[11].ToString());
            a[12] = int.Parse(code[12].ToString()) * 3;
            int sum = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11] + a[12];
            int check = (10 - (sum % 10)) % 10;
            // evaluate check digit
            int last = int.Parse(code[13].ToString());
            return check == last;
        }

        public static T GetExcel<T>(Excel._Worksheet hoja, string indice_celda)
        {
            Excel.Range celda = hoja.Range[indice_celda, indice_celda];

            if(typeof(T) == typeof(string))
            {
                return Formateador.ToString(celda.Value);
            }else if (typeof(T) == typeof(int))
            {
                return (celda.Value == null) ? 0 : Formateador.ToInt32(celda.Value);
            }

            throw new Exception("La conversion espesificada no es configurada");
        }

        public static object FechaDBtoGrid(object fecha_obj)
        {
            if (fecha_obj is null)
                return null;

            string fecha_string = fecha_obj.ToString();

            if (fecha_string == "")
                return null;

            if(DateTime.TryParse(fecha_string, out DateTime fecha))
            {
                return fecha;
            }

            return null;
            
        }

        public static string getBoolGridString(DataGridViewCell cell)
        {
            if (cell.Value == null || cell.Value.ToString() == "")
                return "0";

            if (Convert.ToBoolean(cell.Value))
                return "1";
            else
                return "0";
        }

        public static bool BoolDesdeString(string bool_string)
        {
            if (bool_string == "1")
                return true;
            else if (bool_string == "0")
                return false;

            Interacciones.Ex();
            return false;
                
        }

        public static Dictionary<string, string> InsertarValorSuperiorSS( Dictionary<string, string> old_dic, string key, string value)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(key, value);

            foreach(KeyValuePair<string, string> registro in old_dic)
            {
                dic.Add(registro.Key, registro.Value);
            }

            return dic;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int NumeroVerificadorEAN13(string code)
        {
            if (code != (new Regex("[^0-9]")).Replace(code, ""))
            {
                // is not numeric
                throw new Exception("El codigo EAN 13 sumistrado no es un numero");
            }

            // calculate check digit
            int[] a = new int[12];
            a[0] = int.Parse(code[0].ToString());
            a[1] = int.Parse(code[1].ToString()) * 3;
            a[2] = int.Parse(code[2].ToString());
            a[3] = int.Parse(code[3].ToString()) * 3;
            a[4] = int.Parse(code[4].ToString());
            a[5] = int.Parse(code[5].ToString()) * 3;
            a[6] = int.Parse(code[6].ToString());
            a[7] = int.Parse(code[7].ToString()) * 3;
            a[8] = int.Parse(code[8].ToString());
            a[9] = int.Parse(code[9].ToString()) * 3;
            a[10] = int.Parse(code[10].ToString());
            a[11] = int.Parse(code[11].ToString()) * 3;
            int sum = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11];
            int digito_verificador = (10 - (sum % 10)) % 10;
            
            return digito_verificador;
        }

        public static string ToString(object value)
        {
            if (value == null)
                return "";
            else
                return value.ToString().Trim();
        }

        public static object getIntToGridComboString(object v)
        {
            if (v == null)
                return "";

            string str = v.ToString();

            if (str == "0")
                return "";
            else
                return str;
        }

        public static void CrearArchivoString(string path, string texto)
        {
            File.WriteAllText(path, texto);
        }

        /// <summary>
        /// Utiliza la funcion select para realizar un fintrado y devolver una DataTable nuevo con los datos resultado
        /// No falla si no hay concidencias
        /// A veces no funciona (no encuentra resultados), paso cuando se uso con una DT creado desde ConvertTo
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condicion"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        public static DataTable SelectDT(DataTable dt,string condicion, string orden)
        {

            DataRow[] resultado = dt.Select(condicion, orden);

            if(resultado.Length > 0)
            {
                return resultado.CopyToDataTable();
            }
            else
            {
                DataTable temp = dt.Clone();
                temp.Clear();

                return temp;
            }
            
        }

        public static int ContarConsidenciasDT(DataTable dt, string nombre_columna, object valor)
        {
            if (!dt.Columns.Contains(nombre_columna))
            {
                return -1;
            }

            int cuenta = 0;

            foreach(DataRow row in dt.Rows)
            {
                if (row[nombre_columna].ToString() == valor.ToString())
                    cuenta++;
            }


            return cuenta;
        }

        public static string RemoveAllXmlNamespace(string xmlData)
        {
            string xmlnsPattern = "\\s+xmlns\\s*(:\\w)?\\s*=\\s*\\\"(?<url>[^\\\"]*)\\\"";
            MatchCollection matchCol = Regex.Matches(xmlData, xmlnsPattern);

            foreach (Match m in matchCol)
            {
                xmlData = xmlData.Replace(m.ToString(), "");
            }
            return xmlData;
        }

        public static string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        public static string CodificarISO_8859_1(string xml)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(xml);
            return System.Text.Encoding.UTF8.GetString(tempBytes);
        }

        public static string ElementToString(XmlElement element)
        {
            return NodoToString(element);
        }

        public static string NodoToString(XmlNode nodo)
        {
            if (nodo == null)
                return string.Empty;

            return nodo.InnerXml;
        }

        public static uint ElementToUInt(XmlElement element)
        {
            return NodoToUint(element);
        }

        public static uint NodoToUint(XmlNode nodo)
        {
            return Formateador.ToUInt32(NodoToString(nodo));
        }

        public static string ToStringMasLargo(string palabra1, string palabra2)
        {
            if (palabra2.Length > palabra1.Length)
                return palabra2;

            return palabra1;
        }

        public static decimal ElementToDecimal(XmlElement element)
        {
            return NodoToDecimal(element);
        }

        public static decimal NodoToDecimal(XmlNode nodo)
        {
            string nodo_str = NodoToString(nodo);
            nodo_str = nodo_str.Replace('.', ',');
            return Formateador.ToDecimal(nodo_str);
        }

        public static bool ValidaEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsNull(DateTime fecha_despacho)
        {
            return fecha_despacho == Parametros.FechaNula;
        }
    }
}

