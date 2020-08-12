using Herramientas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Herramietas
{
    public class EEmail
    {
        /// <summary>
        /// Envia un correo electronico usando los parametros de entrada
        /// </summary>
        /// <param name="email_origen">Es el email desde que se envia el correo, debe ser tipo EMae_Emails con el email y la contraseña</param>
        /// <param name="asunto">Es el asunto de Email</param>
        /// <param name="cuerpo">Es el cuerpo del Email</param>
        /// <param name="para">Es el email de destino o para quien esta dirigido el Email</param>
        /// <param name="adjuntos">Una lista con los documentos adjuntos, </param>
        /// <returns>Retorna un objeto tipo respuesta con el resultado del envio del Email</returns>
        public static Res Enviar(EMae_Emails email_origen , string asunto, string cuerpo, string para, List<string> adjuntos)
        {
            Res res = new Res("Enviar Email a " + para);

            if (email_origen == null)
                return res.ErrorContexto("No esta el objeto que contiene el email y clave de origen");

            if (string.IsNullOrEmpty(email_origen.Email))
                return res.ErrorContexto("No esta el email de origen");

            if (string.IsNullOrEmpty(email_origen.Clave))
                return res.ErrorContexto("No esya la clave del correo de origen");

            try
            {
                #region Armado Nottificacion
                Notificaciones Noti = new Notificaciones();
                Noti.SMTP_Servidor = "smtp.gmail.com";
                Noti.SMTP_Puerto = 587;
                Noti.SMTP_SSL = true;
                Noti.SMTP_Usuario = email_origen.Email;
                Noti.SMTP_Password = email_origen.Clave;
                #endregion

                #region Construye Email
                ////
                //// Construya la respuesta email
                EstructuraEmail email = new EstructuraEmail();
                email.asunto = asunto;
                email.desde = email_origen.Email;
                email.para = para;
                email.cuerpo = cuerpo;

                if (adjuntos != null)
                {
                    foreach (string url in adjuntos)
                    {
                        /// se verifica si existe cada documento que se esta agregando
                        if (!File.Exists(url))
                            return res.ErrorContexto("No se encontro la url: " + url);

                        email.adjuntos.Add(url);
                    }
                }
                #endregion

                ////
                //// paraenviar el email es de esta forma
                return Noti.NotificarRecepcionEnvioDte(email);
            }
            catch (Exception ex)
            {
                res.ErrorContexto(ex.Message);
            }

            return res;
        }
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
        public Res NotificarRecepcionEnvioDte(EstructuraEmail email)
        {

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

            return this.EnviarNoficicacion(mail);
        }

        /// <summary>
        /// Envia una notificacion al emisor 
        /// </summary>
        public Res EnviarNoficicacion(MailMessage mail)
        {

            ////
            //// cree la respuesta de procesamiento
            Res res = new Res();

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
                res.Correcto();
                res.Mensaje = "Respuesta enviada correctamente.";

            }
            catch (Exception ex)
            {
                ////
                //// Notifique el error
                res.Mensaje = "No fue posible enviar la respuesta.";
                res.Error(ex.Message);
            }


            ////
            //// Regrese el valor de retorno
            return res;

        }


    }
}
