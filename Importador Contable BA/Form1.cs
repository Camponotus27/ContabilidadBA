using Herramientas;
using ControlesPersonalizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Entidades;

namespace Importador_Contable_BA
{
    public partial class Form1 : Form
    {
        #region Importacion funciones nativas
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string windowClass, string windowName);

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        #endregion
        
        IntPtr handle;

        public Form1()
        {
            InitializeComponent();

            this.Setting = new AppSettings();
        }

        AppSettings Setting;

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                this.Setting.Load();
                this.Tabla.DataSource = this.Setting.Path_excel;

            }catch(Exception ex)
            {
                Interacciones.FinAPlicacionConAviso("Ocurrio un error en la carga de la configuracion" + Formateador.BuscarErrorSignificativo(ex));
                return;
            }

        }


        private void AsignarLabel(Label label, string path, string texto_si_vacio)
        {
            string path_aplicacion = path;

            string label_aplicacion = texto_si_vacio;

            if (!string.IsNullOrEmpty(path_aplicacion))
                label_aplicacion = path_aplicacion;

            label.Text = label_aplicacion;
        }

        #region Getter Propuedades
        object GetPropiedad(string key)
        {
            SettingsPropertyCollection propiedades = Properties.Settings.Default.Properties;

            if (propiedades == null)
            {
                return Interacciones.FinAPlicacionConAviso("Las propiedades estan nulas");
            }

            SettingsProperty propiedad = propiedades[key];

            if (propiedad == null)
            {
                return Interacciones.FinAPlicacionConAviso("No se encontro la propiedad " + key);
            }

            return propiedad.DefaultValue;
        }

        void SetPropiedad(string key, object value)
        {
            SettingsPropertyCollection propiedades = Properties.Settings.Default.Properties;

            if (propiedades == null)
            {
                Interacciones.FinAPlicacionConAviso("Las propiedades estan nulas");
                return;
            }

            SettingsProperty propiedad = propiedades[key];

            if (propiedad == null)
            {
                Interacciones.FinAPlicacionConAviso("No se encontro la propiedad " + key);
                return;
            }

            if (propiedad.Name == key)
            {
                propiedad.DefaultValue = value;
                Properties.Settings.Default.Save();
                return;
            }

            Interacciones.FinAPlicacionConAviso("No se pudo asignar la propiedad " + key);
        } 
        #endregion

        /// <summary>
        /// Envia pulsaciones de teclado simuladas, trae la ventana al frente y las envia
        /// </summary>
        /// <param name="texto"></param>
        private void Send(string texto)
        {
            if (handle == null)
                this.BuscarAplicacionYTraerlaAlFrente();
            else
                this.TraerAlFrente();

            SendKeys.SendWait(texto);
        }

        private void BuscarAplicacionYTraerlaAlFrente()
        {
            this.BuscarAplicacion();
            this.TraerAlFrente();
        }

        private void TraerAlFrente()
        {
            SetForegroundWindow(handle);
        }

        private void BuscarAplicacion()
        {
            handle = FindWindow("ConsoleWindowClass", "asd");

            if (handle == null)
            {
                Interacciones.MessajeBoxAviso("No se encontro la aplicacion Contable abierta, abrela para iniciar la operacion y situate en la creacion del comprobante, en la primera casilla");
                return;
            }
        }

        private void btnAsignarAplicacion_Click(object sender, EventArgs e)
        {
            
        }


        #region Brujeria
        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "First Name";
                oSheet.Cells[1, 2] = "Last Name";
                oSheet.Cells[1, 3] = "Full Name";
                oSheet.Cells[1, 4] = "Salary";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").VerticalAlignment =
                Excel.XlVAlign.xlVAlignCenter;

                // Create an array to multiple values at once.
                string[,] saNames = new string[5, 2];

                saNames[0, 0] = "John";
                saNames[0, 1] = "Smith";
                saNames[1, 0] = "Tom";
                saNames[1, 1] = "Brown";
                saNames[2, 0] = "Sue";
                saNames[2, 1] = "Thomas";
                saNames[3, 0] = "Jane";
                saNames[3, 1] = "Jones";
                saNames[4, 0] = "Adam";
                saNames[4, 1] = "Johnson";

                //Fill A2:B6 with an array of values (First and Last Names).
                oSheet.get_Range("A2", "B6").Value2 = saNames;

                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                oRng = oSheet.get_Range("C2", "C6");
                oRng.Formula = "=A2 & \" \" & B2";

                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("D2", "D6");
                oRng.Formula = "=RAND()*100000";
                oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                //Manipulate a variable number of columns for Quarterly Sales Data.
                DisplayQuarterlySales(oSheet);

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }

        private void DisplayQuarterlySales(Excel._Worksheet oWS)
        {
            Excel._Workbook oWB;
            Excel.Series oSeries;
            Excel.Range oResizeRange;
            Excel._Chart oChart;
            String sMsg;
            int iNumQtrs;

            //Determine how many quarters to display data for.
            for (iNumQtrs = 4; iNumQtrs >= 2; iNumQtrs--)
            {
                sMsg = "Enter sales data for ";
                sMsg = String.Concat(sMsg, iNumQtrs);
                sMsg = String.Concat(sMsg, " quarter(s)?");

                DialogResult iRet = MessageBox.Show(sMsg, "Quarterly Sales?",
                MessageBoxButtons.YesNo);
                if (iRet == DialogResult.Yes)
                    break;
            }

            sMsg = "Displaying data for ";
            sMsg = String.Concat(sMsg, iNumQtrs);
            sMsg = String.Concat(sMsg, " quarter(s).");

            MessageBox.Show(sMsg, "Quarterly Sales");

            //Starting at E1, fill headers for the number of columns selected.
            oResizeRange = oWS.get_Range("E1", "E1").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=\"Q\" & COLUMN()-4 & CHAR(10) & \"Sales\"";

            //Change the Orientation and WrapText properties for the headers.
            oResizeRange.Orientation = 38;
            oResizeRange.WrapText = true;

            //Fill the interior color of the headers.
            oResizeRange.Interior.ColorIndex = 36;

            //Fill the columns with a formula and apply a number format.
            oResizeRange = oWS.get_Range("E2", "E6").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=RAND()*100";
            oResizeRange.NumberFormat = "$0.00";

            //Apply borders to the Sales data and headers.
            oResizeRange = oWS.get_Range("E1", "E6").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            //Add a Totals formula for the sales data and apply a border.
            oResizeRange = oWS.get_Range("E8", "E8").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=SUM(E2:E6)";
            oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
            = Excel.XlLineStyle.xlDouble;
            oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight
            = Excel.XlBorderWeight.xlThick;

            //Add a Chart for the selected data.
            oWB = (Excel._Workbook)oWS.Parent;
            oChart = (Excel._Chart)oWB.Charts.Add(Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);

            //Use the ChartWizard to create a new chart from the selected data.
            oResizeRange = oWS.get_Range("E2:E6", Missing.Value).get_Resize(
            Missing.Value, iNumQtrs);
            oChart.ChartWizard(oResizeRange, Excel.XlChartType.xl3DColumn, Missing.Value,
            Excel.XlRowCol.xlColumns, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            oSeries = (Excel.Series)oChart.SeriesCollection(1);
            oSeries.XValues = oWS.get_Range("A2", "A6");
            for (int iRet = 1; iRet <= iNumQtrs; iRet++)
            {
                oSeries = (Excel.Series)oChart.SeriesCollection(iRet);
                String seriesName;
                seriesName = "=\"Q";
                seriesName = String.Concat(seriesName, iRet);
                seriesName = String.Concat(seriesName, "\"");
                oSeries.Name = seriesName;
            }

            oChart.Location(Excel.XlChartLocation.xlLocationAsObject, oWS.Name);

            //Move the chart so as not to cover your data.
            oResizeRange = (Excel.Range)oWS.Rows.get_Item(10, Missing.Value);
            oWS.Shapes.Item("Chart 1").Top = (float)(double)oResizeRange.Top;
            oResizeRange = (Excel.Range)oWS.Columns.get_Item(2, Missing.Value);
            oWS.Shapes.Item("Chart 1").Left = (float)(double)oResizeRange.Left;
        } 
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Res res = new Res();

                try
                {
                    string[] files = openFileDialog.FileNames;

                    foreach(string file in files)
                    {
                        EPath_Excel excel = new EPath_Excel()
                        {
                            Path_excel = file,
                            Nombre = Path.GetFileName(file)
                        };

                        if (this.YaEstaEnTabla(excel))
                        {
                            Interacciones.MessajeBoxInfo("No se añadio el excel " + excel.Nombre + " porque ya esta en la lista");
                        }
                        else
                        {
                            this.Tabla.Add(excel);
                        }
                    }

                    this.GuardarTabla();

                    res.Correcto();
                }
                catch (Exception ex)
                {
                    res.Error("No se pudo obtener la imagen: " + ex.Message);
                }

            }
        }

        private bool YaEstaEnTabla(EPath_Excel excel)
        {
            System.Collections.IList lista = this.Tabla.List;

            if (lista.Count > 0)
            {
                List<EPath_Excel> lista_path = new List<EPath_Excel>();

                foreach (EPath_Excel path in lista)
                {
                    if(path.Nombre == excel.Nombre)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void GuardarTabla()
        {
            System.Collections.IList lista = this.Tabla.List;

            if (lista.Count > 0)
            {
                List<EPath_Excel> lista_path = new List<EPath_Excel>();

                foreach (EPath_Excel path in lista)
                {
                    lista_path.Add(path);
                }

                this.Setting.Path_excel = lista_path;
                this.Setting.Save();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Tabla.RemoveCurrent();

            this.GuardarTabla();
        }

        private void btnVerificarFormato_Click(object sender, EventArgs e)
        {
            System.Collections.IList lista = this.Tabla.List;

            if (lista.Count > 0)
            {
                foreach (EPath_Excel path in lista)
                {

                    string path_excel = path.Path_excel;

                    Excel.Application excel_Aplicacion = new Excel.Application();
                    Excel.Workbook libro_excel = excel_Aplicacion.Workbooks.Open(path_excel);

                    Excel.Sheets hojas = libro_excel.Sheets;

                    foreach(Excel._Worksheet hoja in hojas)
                    {
                        Excel.Range celda_parcela = hoja.Range["B1", "B1"];
                        Excel.Range celda_sector = hoja.Range["B2", "B2"];
                        Excel.Range celda_propietario = hoja.Range["B3", "B3"];

                        string valor_parcela = Formateador.ToString(celda_parcela.Value);
                        string valor_sector = Formateador.ToString(celda_sector.Value);
                        string valor_propietario = Formateador.ToString(celda_propietario.Value);
                        

                        if (
                            valor_parcela.Trim() == "PARCELA"
                            && valor_sector.Trim() == "SECTOR"
                            && valor_propietario.Trim() == "PROPIETARIO"
                            )
                        {
                            path.Numero_hojas_validas++;
                        }
                        
                    }

                };
            }
            else
            {
                Interacciones.MessajeBoxAviso("No hay excel en la tabla para verificar");
            }


            
        }
    }
}
