using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class Impresora
    {
        public static bool AdmiteHojaGrande(string nombre_impresora)
        {
            string str = "";

            if (nombre_impresora == string.Empty)
                return false;

            UInt16[] papel;

            //Consulta para obtener las impresoras, en la API Win32
            ManagementClass m = new ManagementClass("Win32_Printer");


            //Obtenemos cada instancia del objeto ManagementObjectSearcher
            using (ManagementObjectCollection printers = m.GetInstances())
                foreach (ManagementObject printer in printers)
                {
                    if (printer != null)
                    {
                        try
                        {
                            //Obtenemos la primera impresora en el bucle
                            str = printer["Name"].ToString().ToLower();

                            if(str == nombre_impresora)
                            {
                                papel = (UInt16[])printer["PaperSizesSupported"];

                                foreach (UInt16 tipo_tamaño in papel)
                                {
                                    if (
                                        tipo_tamaño == 7
                                        || tipo_tamaño == 8
                                        || tipo_tamaño == 22
                                        )
                                        return true;
                                    #region tipos papeles 

                                    /*
                                     Unknown (0)
                                    Other (1)
                                    A (2)
                                    B (3)
                                    C (4)
                                    D (5)
                                    E (6)
                                    Letter (7)
                                    Legal (8)
                                    NA-10x13-Envelope (9)
                                    NA-9x12-Envelope (10)
                                    NA-Number-10-Envelope (11)
                                    NA-7x9-Envelope (12)
                                    NA-9x11-Envelope (13)
                                    NA-10x14-Envelope (14)
                                    NA-Number-9-Envelope (15)
                                    NA-6x9-Envelope (16)
                                    NA-10x15-Envelope (17)
                                    A0 (18)
                                    A1 (19)
                                    A2 (20)
                                    A3 (21)
                                    A4 (22)
                                    A5 (23)
                                    A6 (24)
                                    A7 (25)
                                    A8 (26)
                                    A9A10 (27)
                                    B0 (28)
                                    B1 (29)
                                    B2 (30)
                                    B3 (31)
                                    B4 (32)
                                    B5 (33)
                                    B6 (34)
                                    B7 (35)
                                    B8 (36)
                                    B9 (37)
                                    B10 (38)
                                    C0 (39)
                                    C1 (40)
                                    C2C3 (41)
                                    C2
                                    C4 (42)
                                    C3
                                    C5 (43)
                                    C4
                                    C6 (44)
                                    C5
                                    C7 (45)
                                    C6
                                    C8 (46)
                                    C7
                                    etc...

                                    */
                                    #endregion
                                }
                            }

                            /*
                             * foreach (string tipo_papel in (string[])printer["PrinterPaperNames"])
                            {
                                if (tipo_papel == "Roll Paper 80 x 297 mm" && !(printer["WorkOffline"].ToString().ToLower().Equals("true") || printer["PrinterStatus"].Equals(7)))
                                {
                                    Console.WriteLine("sirve la impresora " + str);
                                }
                            }*/


                        }
                        catch (Exception ex)
                        {
                            new LogWriter(ex);
                        }


                        /*if (str.Equals(printerName.ToLower()))
                        {
                            //Una vez encontrada verificamos en estado de ésta
                            if (printer["WorkOffline"].ToString().ToLower().Equals("true") || printer["PrinterStatus"].Equals(7))
                                //Fuera de línea
                                online = false;
                            else
                                //En línea
                                online = true;
                        }*/
                        }
                    else
                        throw new Exception("No fueron encontradas impresoras instaladas en el equipo");
                }

            return false;
        }

        public static string GetPredeterminada()
        {
            string str = "";

            UInt16[] papel;

            //Consulta para obtener las impresoras, en la API Win32
            ManagementClass m = new ManagementClass("Win32_Printer");


            //Obtenemos cada instancia del objeto ManagementObjectSearcher
            using (ManagementObjectCollection printers = m.GetInstances())
                foreach (ManagementObject printer in printers)
                {
                    if (printer != null)
                    {
                        try
                        {
                            //Obtenemos la primera impresora en el bucle
                            str = printer["Name"].ToString().ToLower();

                            bool es_predeterminada = (bool)printer["Default"];

                            if (es_predeterminada)
                                return str;
                        }
                        catch (Exception ex)
                        {
                            new LogWriter(ex);
                        }
                    }
                    else
                        throw new Exception("No fueron encontradas impresoras instaladas en el equipo");
                }

            return "";
        }

        public static Dictionary<string, string> GetImpresorasDisponibls()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("", "");

            ManagementClass m = new ManagementClass("Win32_Printer");
            //Obtenemos cada instancia del objeto ManagementObjectSearcher
            using (ManagementObjectCollection printers = m.GetInstances())
                foreach (ManagementObject printer in printers)
                {
                    if (printer != null)
                    {

                        string nombre = printer["Name"].ToString().ToLower();
                        dic.Add(nombre, nombre);
                    }
                    else
                        throw new Exception("No fueron encontradas impresoras instaladas en el equipo");
                }

            return dic;
        }

        public static void ImprimirHojaGrande(string url, string nombre_impresora = "")
        {
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(url);
            pdf.PrintSettings.PrinterName = (!string.IsNullOrEmpty(nombre_impresora)) ? nombre_impresora : Impresora.GetPredeterminada();
            pdf.Print();


            return;
            Process P = new Process();
            P.StartInfo.FileName = url; // FileName(.pdf) to print.    

            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //Hide the window. 

            //!! Since the file name involves a nonexecutable file(.pdf file), including a verb to specify what action to take on the file. //The action in our case is to "Print" a file in a selected printer.

            //!! Print the document in the printer selected in the PrintDialog !!//
            P.StartInfo.Verb = "PrintTo";

            P.StartInfo.Arguments = nombre_impresora;
            P.StartInfo.CreateNoWindow = true;        

            //!! Start the process !!//      

            P.Start();

            //!! P.WaitForExit(4000);     

            P.CloseMainWindow();
        }
    }
}
