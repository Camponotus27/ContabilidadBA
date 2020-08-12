using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Herramientas.Email;

namespace Herramientas
{

    public class Email
    {

        public Email()
        {

        }

        /// <summary>
        /// Envia un Correo con el correo principal
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="cuerpo"></param>
        /// <param name="para"></param>
        /// <param name="adjuntos"></param>
        /// <returns></returns>
        public static Res enviarEmail(string asunto, string cuerpo, string para, string[] adjuntos)
        {
            Res res = new Res();
            try
            {
                Notificaciones Noti = new Notificaciones();
                Noti.SMTP_Servidor = "smtp.gmail.com";
                Noti.SMTP_Puerto = 587;
                Noti.SMTP_SSL = true;
                Noti.SMTP_Usuario = "libreria.bunick@gmail.com";
                Noti.SMTP_Password = "clip100%";

                ////
                //// Construya la respuesta email
                EstructuraEmail email = new EstructuraEmail();
                email.asunto = asunto;
                email.desde = "libreria.bunick@gmail.com";
                email.para = para;
                email.cuerpo = cuerpo;

                foreach (string url in adjuntos)
                {
                    email.adjuntos.Add(url);
                }

                ////
                //// paraenviar el email es de esta forma
                bool fueEnviado = Noti.NotificarRecepcionEnvioDte(email);


                if (fueEnviado)
                    res.Correcto();
                else
                    res.Error();
            }
            catch (Exception ex)
            {
                res.Error(ex.Message);
            }
            
            return res;
        }

        public static EntRespueta RecuperarEmail(string RutConsultante, string Cn, string RutContribuyente)
        {

            ////
            //// Inciciar la respuesta
            EntRespueta resp = new EntRespueta();


            ////
            //// Iniciar la consulta
            try
            {

                #region CREAR CONNECTION

                ////
                //// cual es la fullpath de la ultima conección
                string conn = "Connections\\" + RutConsultante;
                Directory.CreateDirectory(conn);
                conn = Path.Combine(conn, "Last_Connection.txt");

                #endregion

                #region RECUPERAR EL CERTIFICADO

                ////
                //// Iniciar recuperación de certificado desde colección interna del equipo.
                //// en el caso que se trate de un servidor es necesario que se recupere 
                //// en los contenedores del servidor y lo extraiga desde allí.
                X509Certificate2 certificado = RecuperarCertificado(Cn);
                if (certificado == null)
                    throw new Exception("No fue posible reconstruír el certificado solicitado.");

                #endregion

                #region RECUPERAR TOKEN PARA LA OPERACIÓN ACTUAL

                ////
                //// Cookies necesarias para el proceso
                string MyCookies = string.Empty;

                ////
                //// Pregunte al sistema si ya existe una ultima conección y sí aun esta activa?
                if (File.Exists(conn))
                {
                    ////
                    //// Lea todo el archivo y determine sí la cookie esta viva o no.
                    MyCookies = File.ReadAllText(conn, Encoding.GetEncoding("ISO-8859-1"));

                    ////
                    //// Recupere la fecha limite de supervivencia de la cookie
                    Match match = Regex.Match(MyCookies, @"NETSCAPE_LIVEWIRE.exp=([\d]{14});");
                    if (match.Success)
                    {
                        ////
                        //// Recupere la vida maxima de la cookie
                        string maxima_vida = match.Groups[1].Value;

                        ////
                        //// Recuperar los elementos de la fecha
                        int a = Convert.ToInt32(maxima_vida.Substring(0, 4));
                        int m = Convert.ToInt32(maxima_vida.Substring(4, 2));
                        int d = Convert.ToInt32(maxima_vida.Substring(6, 2));
                        int h = Convert.ToInt32(maxima_vida.Substring(8, 2));
                        int M = Convert.ToInt32(maxima_vida.Substring(10, 2));
                        int s = Convert.ToInt32(maxima_vida.Substring(12, 2));

                        ////
                        //// Cree la fecha de expiración 
                        DateTime Fecha_Expiracion_Cookie = new DateTime(a, m, d, h, m, s);

                        ////
                        //// Ahora restele a la fecha de expiración 30 minutos,
                        //// esto es para ajustar las solicitudes multiples 
                        Fecha_Expiracion_Cookie = Fecha_Expiracion_Cookie.AddMinutes(-30);

                        ////
                        //// Ahora bien si en este moemento estamos bajo la fecha de expiración
                        //// dejaremos las mismas cookies que recuperamos del archivo , de lo contrario
                        //// generaremos unas nuevas cookies.
                        if (DateTime.Now > Fecha_Expiracion_Cookie)
                            MyCookies = RecuperarCookies(certificado);

                    }

                }
                else
                {
                    ////
                    //// Si no se encontró ninguna conexion antigua, cree una nueva 
                    //// y posteriormente guardela para su re procesamiento en el }
                    //// futuro.
                    MyCookies = RecuperarCookies(certificado);

                }

                ////
                //// Antes de salir guarde las cookies en disco para ser utilizadas
                //// durante el periodo que esten activas.
                File.WriteAllText(conn, MyCookies);

                #endregion

                #region RECUPERAR EL EMAIL DE INTERCAMBIO DEL CONTRIBUYENTE

                ////
                //// Variables globales del proceso
                HttpWebRequest req = null;
                HttpWebResponse response = null;

                ////
                //// Inicie la respuesta
                resp.EsCorrecto = false;

                ////
                //// Identifique la url donde recuperar la información
                string uriSIITarget = "https://palena.sii.cl/cvc_cgi/dte/ce_consulta_e";

                ////
                //// Cree la referencia
                string uriSIIRefere = "https://palena.sii.cl/cvc_cgi/dte/ce_consulta_rut";

                ////
                //// Documento recuperado
                string sDocumento = string.Empty;

                ////
                //// Recupere los datos de la session
                string cookies = MyCookies;

                ////
                //// Genera la consulta al SII
                req = (HttpWebRequest)WebRequest.Create(uriSIITarget);
                req.Method = "POST";
                req.ContentType = "text/html, application/xhtml+xml";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";
                req.Referer = uriSIIRefere;
                req.Headers.Add("Cookie", cookies);

                ////
                //// Escriba la consulta ( POST ) y su largo en bytes
                //// RUT_EMP=60703000&DV_EMP=6&ACEPTAR=Consultar
                string sRutBody = RutContribuyente.Split('-')[0];
                string sRutDigi = RutContribuyente.Split('-')[1].ToUpper();
                string postData =
                    string.Format("RUT_EMP={0}&DV_EMP={1}&ACEPTAR=Consultar",
                    sRutBody,
                    sRutDigi
                    );
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                req.ContentLength = postBytes.Length;

                ////
                //// Escriba los bytes en el request stream
                Stream postStream = req.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);
                postStream.Flush();
                postStream.Close();

                ////
                //// Recupere la respuesta de la consulta ( response )
                response = (HttpWebResponse)req.GetResponse();

                ////
                //// Recupere la respuesta del SII
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("No fue posible comunicarse con el servidor remoto.");

                ////
                //// Recupere el documento que nos entrega el SII
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                ////
                //// Si el documento no tiene definido el set de caracteres
                if (response.CharacterSet == null || string.IsNullOrEmpty(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                ////
                //// Escriba el resultado en disco
                sDocumento = readStream.ReadToEnd();

                ////
                //// Cierre objetos
                response.Close();
                readStream.Close();
                req = null;

                #endregion

                #region RECUPERACION DE LA DATA RESPUESTA

                ////
                //// Compruebe que existen datos de respuesta validos
                string pattern_target = "Los antecedentes del Contribuyente son :";
                if (!Regex.IsMatch(sDocumento, pattern_target))
                    throw new Exception("Consulta ejecutada correctamente, pero el SII no regresó ningun dato.");

                ////
                //// Si hay respuesta inicie el rescate de toda la información
                string pattern_table = "<table(.+?)</table>";
                MatchCollection mc = Regex.Matches(sDocumento, pattern_table, RegexOptions.Singleline);

                ////
                //// Recuperar la Tabla
                string tabla = mc[2].Value;

                ////
                //// Eliminar los attributos que sobran
                string pattern_attr = @"<table(.+?)>";
                tabla = Regex.Replace(tabla, pattern_attr, "<table>");

                pattern_attr = @"<td(.+?)>";
                tabla = Regex.Replace(tabla, pattern_attr, "<td>");

                pattern_attr = @"<font(.+?)>";
                tabla = Regex.Replace(tabla, pattern_attr, "");

                pattern_attr = @"</font>";
                tabla = Regex.Replace(tabla, pattern_attr, "");

                pattern_attr = @"&nbsp;";
                tabla = Regex.Replace(tabla, pattern_attr, "");

                pattern_attr = @"<TR>";
                tabla = Regex.Replace(tabla, pattern_attr, "<tr>");

                pattern_attr = @"Raz&oacute;n";
                tabla = Regex.Replace(tabla, pattern_attr, "Razon");

                pattern_attr = @"Resoluci&oacute;n";
                tabla = Regex.Replace(tabla, pattern_attr, "");

                ////
                //// Recupere la información como un documento xml
                XmlDocument xData = new XmlDocument();
                xData.PreserveWhitespace = false;
                xData.LoadXml(tabla);

                ////
                //// Recuperar los datos
                XmlElement nRut = (XmlElement)xData.SelectSingleNode("table/tr[1]/td[2]");
                XmlElement nNom = (XmlElement)xData.SelectSingleNode("table/tr[2]/td[2]");
                XmlElement nNr = (XmlElement)xData.SelectSingleNode("table/tr[3]/td[2]");
                XmlElement nFr = (XmlElement)xData.SelectSingleNode("table/tr[4]/td[2]");
                XmlElement nEm = (XmlElement)xData.SelectSingleNode("table/tr[5]/td[2]");

                ////
                //// Normalice eldocumento
                nRut.InnerText = nRut.InnerText.Replace("\r\n", "");
                nNom.InnerText = nNom.InnerText.Replace("\r\n", "");
                nNr.InnerText = nNr.InnerText.Replace("\r\n", "");
                nFr.InnerText = nFr.InnerText.Replace("\r\n", "");
                nEm.InnerText = nEm.InnerText.Replace("\r\n", "");

                ////
                //// Normalice eldocumento
                nRut.InnerText = nRut.InnerText.Replace("\n", "").Trim();
                nNom.InnerText = nNom.InnerText.Replace("\n", "").Trim();
                nNr.InnerText = nNr.InnerText.Replace("\n", "").Trim();
                nFr.InnerText = nFr.InnerText.Replace("\n", "").Trim();
                nEm.InnerText = nEm.InnerText.Replace("\n", "").Trim();

                ////
                //// Indicar al usuario que la operación fue correcta
                resp.EsCorrecto = true;
                resp.Mensaje = "Operación de recuperación de email correcta.";
                resp.Detalle = "Se recuperó correctamente la información del contribuyente.";
                resp.Rut = nRut.InnerText;
                resp.Nombre = nNom.InnerText;
                resp.NroResol = nNr.InnerText;
                resp.FchResol = nFr.InnerText;
                resp.Email = nEm.InnerText;

                #endregion

            }
            catch (Exception ex)
            {
                resp.EsCorrecto = false;
                resp.Mensaje = "Operación de recuperación de email in-correcta.";
                resp.Detalle = ex.Message;
                resp.Email = null;
            }

            ////
            //// Regrese el valor de retorno
            return resp;

        }

        #region Obtener correo SII

        public class EntRespueta
        {
            public bool EsCorrecto { get; set; }
            public string Mensaje { get; set; }
            public string Detalle { get; set; }
            public object Resultado { get; set; }

            public string Rut { get; set; }
            public string Nombre { get; set; }
            public string NroResol { get; set; }
            public string FchResol { get; set; }
            public string Email { get; set; }

            /// <summary>
            /// Serialización del documento respuesta actual
            /// </summary>
            /// <returns></returns>
            internal string Serializar()
            {
                ////
                //// Objeto xmlwriter
                XmlWriter xmlwriter;

                ////
                //// Aquí dejaremos el resultado para no guardar 
                //// en disco.
                StringBuilder sb = new StringBuilder();

                ////
                //// Prepare el espacio de nombres a utilizar para la serializacion
                //// En nuestro caso en null
                var xns = new XmlSerializerNamespaces();
                xns.Add(string.Empty, string.Empty);

                ////
                //// Setee el resultado de la declaracion del documento xml
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.Encoding = Encoding.GetEncoding("ISO-8859-1");
                xws.Indent = true;

                ////
                //// Serialice la clase 
                XmlSerializer x = new XmlSerializer(this.GetType());

                ////
                //// Cree temporalmente un archivo xml para guardar el resultado
                using (XmlWriter xw = XmlWriter.Create(sb, xws))
                {
                    xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"ISO-8859-1\" ");
                    x.Serialize(xw, this, xns);
                    xmlwriter = xw;
                }

                ////
                //// Regrese el resultado de la operación
                return sb.ToString();

            }
        }

        public static X509Certificate2 RecuperarCertificado(string CN)
        {



            ////
            //// Respuesta
            X509Certificate2 certificado = null;

            ////
            //// Certificado que se esta buscando
            if (string.IsNullOrEmpty(CN) || CN.Length == 0)
                return null;

            ////
            //// Inicie la busqueda del certificado
            try
            {

                ////
                //// Abra el repositorio de certificados para buscar el indicado
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection Certificados1 = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection Certificados2 = Certificados1.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection Certificados3 = Certificados2.Find(X509FindType.FindBySubjectName, CN, false);

                ////
                //// Si hay certificado disponible envíe el primero
                if (Certificados3 != null && Certificados3.Count != 0)
                    certificado = Certificados3[0];

                ////
                //// Cierre el almacen de sertificados
                store.Close();


            }
            catch (Exception)
            {
                certificado = null;
            }

            return certificado;

        }

        public static string RecuperarCookies(X509Certificate Certificado)
        {

            ////
            //// Target donde apunta la autenticación del SII
            string uriSIITarget = "";
            uriSIITarget += "https://herculesr.sii.cl/cgi_AUT2000/CAutInicio.cgi?";
            uriSIITarget += "https://www4.sii.cl/consdcvinternetui/";

            ////
            //// Cual es la referencia al servicio
            string uriReference = "";
            uriReference += "https://zeusr.sii.cl/AUT2000/InicioAutenticacion/IngresoCertificado.html?";
            uriReference += "https://www4.sii.cl/consdcvinternetui/";

            ////
            //// Consulta al SII para autenticar al cliente actual ( certificado )
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uriSIITarget);
            req.Method = "POST";
            req.PreAuthenticate = true;
            req.AllowAutoRedirect = true;
            req.ClientCertificates.Add(Certificado);
            req.Referer = uriReference;
            req.ContentType = "application/x-www-form-urlencoded";

            ////
            //// Escriba la consulta ( POST ) y su largo en bytes
            string postData = "referencia=https%3A%2F%2Fwww4.sii.cl%2Fconsdcvinternetui%2F";
            byte[] postBytes = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = postBytes.Length;

            ////
            //// Escriba los bytes en el request stream
            Stream postStream = req.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Flush();
            postStream.Close();

            ////
            //// Recupere la respuesta de la consulta ( response )
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            ////
            //// Recupere la respuesta del SII
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("No fue posible comunicarse con el servidor remoto.");

            ////
            //// Recupere las cookies generadas por el SII
            bool HasCookies = response.Headers.AllKeys.Contains("Set-Cookie");
            if (!HasCookies)
                throw new Exception("La consulta actual no regresó cookies.");

            ////
            //// Recupere las cookies del proceso
            string cookies = response.Headers["Set-Cookie"];
            if (string.IsNullOrEmpty(cookies))
                throw new Exception("La consulta actual no regresó ninguna cookies. ( cookies= null )");

            ////
            //// Cree el arreglo de cookies
            string[] Items = cookies.Split(',');

            ////
            //// Por cada item del arreglo solo recupere el value de la cookie
            string sCookies = string.Empty;
            foreach (string Item in Items)
            {
                sCookies += Item.Split(';')[0] + "; ";
            }

            ////
            //// Limpie la cadena de los caracteres no validos
            sCookies = sCookies.Substring(0, sCookies.Length - 2);

            ////
            //// regrese el valor de retorno
            return sCookies;



        }

        #endregion
    }

    #region Enviar correo

    public class EstructuraEmail
    {

        /// <summary>
        /// Email del emisor de la respuesta
        /// </summary>
        public string desde { get; set; }

        /// <summary>
        /// Destinatarios 
        /// </summary>
        public string para { get; set; }

        /// <summary>
        /// Representa el asunto del email
        /// </summary>
        public string asunto { get; set; }

        /// <summary>
        /// Cuerpoe del mensaje
        /// </summary>
        public string cuerpo { get; set; }

        /// <summary>
        /// Representa los archivos adjuntos del email de tipo xml
        /// que se encuentran fisicamente en el pc actual.
        /// </summary>
        public List<string> adjuntos = new List<string>();

        #region PROPIEDADES EXTENDIDAS

        public long IdRegistro { get; set; }

        #endregion



    }

    public class Notificaciones
    {

        #region PROPIEDADES SERVIDOR SMTP

        /// <summary>
        /// IP del Servidor SMTP
        /// </summary>
        public string SMTP_Servidor { get; set; }

        /// <summary>
        /// Numero del Puerto SMTP
        /// </summary>
        public int SMTP_Puerto { get; set; }

        /// <summary>
        /// Habilita o no el SSl del servidor SMTP
        /// </summary>
        public bool SMTP_SSL { get; set; }

        /// <summary>
        /// Define el usuario sel servidor SMTP
        /// </summary>
        public string SMTP_Usuario { get; set; }

        /// <summary>
        /// Password del usuario del servidor SMTP
        /// </summary>
        public string SMTP_Password { get; set; }



        #endregion


        ////
        //// Notificar al emisor del email de la recepcion de los documentos adjuntos
        public bool NotificarRecepcionEnvioDte(EstructuraEmail email)
        {

            ////
            //// Fue enviado?
            bool fueEnviado = false;

            ////
            //// Cree el objeto mail contestando que no existe un documento adjunto
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(email.para));
            mail.From = new MailAddress(email.desde);
            mail.Subject = email.asunto;
            mail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            mail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            mail.Body = email.cuerpo;
            mail.IsBodyHtml = true;

            ///
            //// Agregar los documentos Adjuntos
            if (email.adjuntos.Count > 0)
            {
                ////
                //// Agregar todo los archivos 
                foreach (string fullpath in email.adjuntos)
                {
                    Attachment data = new Attachment(fullpath, MediaTypeNames.Application.Octet);
                    mail.Attachments.Add(data);
                }
            }

            ////
            //// Envie el mail
            EntRespueta resp = EnviarNoficicacion(mail);
            if (resp.EsCorrecto)
                fueEnviado = true;

            ////
            //// Regrese el valor de retorno
            return fueEnviado;

        }

        /// <summary>
        /// Envia una notificacion al emisor 
        /// </summary>
        public EntRespueta EnviarNoficicacion(MailMessage mail)
        {

            ////
            //// cree la respuesta de procesamiento
            EntRespueta resp = new EntRespueta();

            ////
            //// Inicie el proceso
            try
            {
                ////
                //// Inicie proceso de envio de notificacion
                SmtpClient smtp = new SmtpClient(this.SMTP_Servidor, this.SMTP_Puerto);
                NetworkCredential credenciales = new NetworkCredential(this.SMTP_Usuario, this.SMTP_Password);

                ////
                //// Enviee la notificacion
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credenciales;
                smtp.EnableSsl = true;// this.SMTP_SSL;

                ////
                //// TODO: ENVIE EL EMAIL
                smtp.Send(mail);


                ////
                //// Cierre los objetos
                mail.Dispose();
                smtp.Dispose();
                smtp = null;

                ////
                //// Notifique el error
                resp.EsCorrecto = true;
                resp.Mensaje = "Respuesta enviada correctamente.";

            }
            catch (Exception ex)
            {
                ////
                //// Notifique el error
                resp.EsCorrecto = false;
                resp.Mensaje = "No fue posible enviar la respuesta.";
                resp.Detalle = ex.Message;
                resp.Resultado = null;

            }


            ////
            //// Regrese el valor de retorno
            return resp;

        }


    }

    #endregion
}
