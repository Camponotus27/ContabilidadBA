using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class LogWriter
    {
        static string mac = string.Empty;
        public static string Mac {
            get
            {
                if(mac == string.Empty)
                {
                    mac = Herramientas.ControlMac.GetMACAddress();
                }

                return mac;
            }
        }

        public LogWriter(string logMessage)
        {
            this.LogWrite(logMessage);
        }

        public LogWriter(Exception ex)
        {
            string logMessage = ex.Message;
            this.LogWrite(logMessage);
        }

        public void LogWrite(string logMessage)
        {

            Console.WriteLine(logMessage);

            try
            {
                using (StreamWriter w = File.AppendText(DireccionLog))
                {
                    this.Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nEntrada : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());

                txtWriter.WriteLine("mac:{0}", Mac);
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-----------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

        public static string DireccionLog
        {
            get
            {
                DateTime hoy = DateTime.Now.Date;
                string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string carpeta = m_exePath + "\\logs";

                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                string nombre_archivo = "log" + hoy.ToString("dd-MM-yyyy") + ".txt";


                return carpeta + "\\" + nombre_archivo;
            }

        }

    }
}
