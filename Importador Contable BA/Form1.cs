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
using Entidades.Herramietas;
using System.Data.Odbc;
using System.Data.OleDb;

namespace Importador_Contable_BA
{
    public partial class Form1 : FormPitagoras
    {

        string path_mov_sys = string.Empty;

        private void SetPathMovSys(string path)
        {
            if (File.Exists(path))
            {
                this.path_mov_sys = path;
                this.lpPathMovSys.Text = path;
            }
            else
            {
                this.ErrorPathMovSys("No se encontro el MovSys en la direccion construida a partid de los datos ingresados");
            }
        }

        private void ErrorPathMovSys(string error)
        {
            this.path_mov_sys = string.Empty;
            this.lpPathMovSys.Text = error;
        }

        public Form1()
        {
            InitializeComponent();

            this.Setting = new AppSettings();

            this.InicializarMeses();
            this.InicializarAnio();
        }

        private void InicializarAnio()
        {
            int anio_inicio = 2000;

            List<EAnio> lista_anios = new List<EAnio>();

            int anio_actual = DateTime.Now.Year;


            while (anio_actual >= anio_inicio)
            {
                lista_anios.Add(new EAnio(anio_actual));

                anio_actual--;
            }

            this.bindingCmbAnio.DataSource = lista_anios;
        }

        private void InicializarMeses()
        {
            List<EMes> meses = new List<EMes>()
            {
                new EMes(){Id = 1, Nombre = "Enero"},
                new EMes(){Id = 2, Nombre = "Febrero"},
                new EMes(){Id = 3, Nombre = "Marzo"},
                new EMes(){Id = 4, Nombre = "Abril"},
                new EMes(){Id = 5, Nombre = "Mayo"},
                new EMes(){Id = 6, Nombre = "Junio"},
                new EMes(){Id = 7, Nombre = "Julio"},
                new EMes(){Id = 8, Nombre = "Agosto"},
                new EMes(){Id = 9, Nombre = "Septiembre"},
                new EMes(){Id = 10, Nombre = "Octubre"},
                new EMes(){Id = 11, Nombre = "Noviembre"},
                new EMes(){Id = 12, Nombre = "Diciembre"},
            };


            this.bindingCmbMeses.DataSource = meses;

            try
            {
                this.bindingCmbMeses.Position = DateTime.Now.Month - 1;
            }catch(Exception ex)
            {
                this.Informacion("No se pudo selecionar el mes actual: " + ex.Message);
            }
            
        }

        AppSettings Setting;

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                this.Setting.Load();

                this.bindingExcel.DataSource = this.Setting.Path_excel;
                this.txtRutEmpresa.Value = this.Setting.Rut_empresa;
                this.lbPathAplicacion.Text = this.Setting.Path_aplicacion_contable;

            }
            catch(Exception ex)
            {
                this.CerrarConMensaje("Ocurrio un error en la carga de la configuracion" + Formateador.BuscarErrorSignificativo(ex));
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

        private void btnAsignarAplicacion_Click(object sender, EventArgs e)
        {
           
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(this.Setting.Path_aplicacion_contable))
            {
                fbd.SelectedPath = this.Setting.Path_aplicacion_contable;
            }

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = fbd.SelectedPath;

                    if (string.IsNullOrWhiteSpace(file))
                    {
                        this.Aviso("No se pudo obtener la path, viene vacia");
                    }
                    else
                    {
                        this.Setting.Path_aplicacion_contable = file;
                        this.lbPathAplicacion.Text = file;
                        this.Setting.Save();

                        this.Informacion("Se guardo la path correctamente");
                    }
                }
                catch (Exception ex)
                {
                    this.Aviso("No se pudo obtener la imagen: " + ex.Message);
                }
                finally
                {
                    fbd.Dispose();
                }

            }
        }

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
                            this.bindingExcel.Add(excel);
                        }
                    }

                    this.GuardarTabla();

                    res.Correcto();
                }
                catch (Exception ex)
                {
                    res.Error("No se pudo obtener las direcciones: " + ex.Message);
                }

            }
        }

        private bool YaEstaEnTabla(EPath_Excel excel)
        {
            System.Collections.IList lista = this.bindingExcel.List;

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
            System.Collections.IList lista = this.bindingExcel.List;

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
            this.bindingExcel.RemoveCurrent();

            this.GuardarTabla();
        }

        private async void btnVerificarFormato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path_mov_sys))
            {
                this.Aviso("No se encontro el fichero MovSys");
                return;
            }


            EMes e_mes = (EMes)this.bindingCmbMeses.Current;
            EAnio e_anio = (EAnio)this.bindingCmbAnio.Current;

            int numero_comprobante_inicial_prefijo = Formateador.ToInt32(this.lbPrefijoNComprobante.Text);

            numero_comprobante_inicial_prefijo *= 1000;

            int numero_comprobante_inicial = numero_comprobante_inicial_prefijo + this.txtNComprobante.ValueInt;

            if(e_mes == null)
            {
                this.Aviso("No se detecto el mes");
                return;
            }

            if (e_anio == null)
            {
                this.Aviso("No se detecto el año");
                return;
            }

            if(numero_comprobante_inicial == 0)
            {
                this.Aviso("El numero de comprobante inicial es 0");
                return;
            }

            Reportador rep = new Reportador();
            Res res = await this.EjecutarAsyncAwait(() => { return this.ExtraerDatos(e_mes, e_anio, numero_comprobante_inicial, rep); }, "Cargando", rep, false);


            this.dgvExcels.Refresh();

            if (res.IsCorrecto)
            {
                if(res.Respuesta is List <EComprobante_Detalle>)
                {
                    this.ComprobantesContables.DataSource = res.Respuesta;

                    this.grExtraerDatos.Enabled = false;
                    this.grInsertarDatos.Enabled = true;
                }
                else
                {
                    res.Error("El tipo de dato en la respuesta no es valido");
                }

                
            }

            this.dgvComprobantes.Refresh();
            this.dgvExcels.Refresh();

            this.Message(res);
        }

        private Res ExtraerDatos(EMes e_mes, EAnio e_anio, int numero_comprobante_inicial, Reportador rep)
        {
            Res res = new Res();

            try
            {
                int mes = e_mes.Id;
                int anio = e_anio.Id;

                int fila = (anio - 2000) * 12 + 1 - 30 + mes - 1;

                // obtencion de la fecha del comprobante, ultimo dia del mes
                DateTime fechatemp = new DateTime(anio, mes, 1);
                DateTime fecha_ultimo_dia_mes = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);

                // nombre de mes para cada comprobante
                string nombre_mes = e_mes.Nombre.ToUpper();

                rep.Reportar("Iniciando estructura comprobantes");
                EComprobante comprobante_gasto_comun = new EComprobante("GASTO COMUN " + nombre_mes, numero_comprobante_inicial, fecha_ultimo_dia_mes, 1600101, 9100101);
                EComprobante comprobante_energia = new EComprobante("LUZ " + nombre_mes, numero_comprobante_inicial + 1, fecha_ultimo_dia_mes, 1600102, 9100103);
                EComprobante comprobante_agua = new EComprobante("AGUA " + nombre_mes, numero_comprobante_inicial + 2, fecha_ultimo_dia_mes, 1600103, 9100102);
                EComprobante comprobante_cargo_fijo_agua = new EComprobante("CARGO FIJO " + nombre_mes, numero_comprobante_inicial + 3, fecha_ultimo_dia_mes, 1600113, 9100108);
                EComprobante comprobante_cuota_asoc = new EComprobante("CUOTA ASOCIACION " + nombre_mes, numero_comprobante_inicial + 4, fecha_ultimo_dia_mes, 1600110, 4500101);

                // este no se dice pero aparece en el comprobante final
                EComprobante comprobante_otros_ingresos = new EComprobante("OTROS INGRESOS " + nombre_mes, numero_comprobante_inicial + 5, fecha_ultimo_dia_mes, 1600112, 9100107);
                EComprobante comprobante_multa_e_intereses = new EComprobante("MULTAS E INTERESES " + nombre_mes, numero_comprobante_inicial + 6, fecha_ultimo_dia_mes, 1600106, 9100104);
                //EComprobante comprobante_salud = new EComprobante("SALUD " + nombre_mes);


                System.Collections.IList lista = this.bindingExcel.List;

                if (lista.Count > 0)
                {
                    foreach (EPath_Excel path in lista)
                    {

                        string path_excel = path.Path_excel;

                        rep.Reportar("Iniciando aplicacion Excel");
                        Excel.Application excel_Aplicacion = new Excel.Application();
                        excel_Aplicacion.Visible = false;

                        
                        Excel.Workbook libro_excel = excel_Aplicacion.Workbooks.Open(path_excel);
                        rep.Reportar("Abriendo documento " + libro_excel.Name);

                        rep.Reportar("Iniciando hojas Excel");
                        Excel.Sheets hojas = libro_excel.Sheets;
                        

                        foreach (Excel._Worksheet hoja in hojas)
                        {

                            rep.Reportar("Abriendo hoja " + hoja.Name);
                            // en cabezado hoja
                            string valor_parcela = Formateador.GetExcel<string>(hoja, "B1");
                            string valor_sector = Formateador.GetExcel<string>(hoja, "B2");
                            string valor_propietario = Formateador.GetExcel<string>(hoja, "B3");

                            // valores hoja
                            string valor_parcela_value = Formateador.GetExcel<string>(hoja, "D1");
                            string valor_sector_value = Formateador.GetExcel<string>(hoja, "D2");

                            // aca se valida si la pagina es valida
                            if (
                                valor_parcela == "PARCELA"
                                && valor_sector == "SECTOR"
                                && valor_propietario == "PROPIETARIO"
                                )
                            {
                                rep.Reportar("VALIDA", false);
                                path.Numero_hojas_validas++;


                                // 1 Q gastos comunes
                                // 2 G Energia
                                // 3 L Agua
                                // 4 M Cargo fijo agua
                                // 5 N Cuota asoc

                                // 6 Otros Ingresos
                                // 7 R multa e intereses

                                int gasos_comunes = Formateador.GetExcel<int>(hoja, "Q" + fila);
                                int energia = Formateador.GetExcel<int>(hoja, "G" + fila);
                                int agua = Formateador.GetExcel<int>(hoja, "L" + fila);
                                int cargo_fijo_agua = Formateador.GetExcel<int>(hoja, "M" + fila);
                                int cuota_asoc = Formateador.GetExcel<int>(hoja, "N" + fila);
                                int otros_ingresos = Formateador.GetExcel<int>(hoja, "O" + fila);
                                int multa_e_intereses = Formateador.GetExcel<int>(hoja, "R" + fila);

                                string glosa = "P" + valor_parcela_value + valor_sector_value;
                                string rut = "11.111.111-1";


                                comprobante_gasto_comun.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        gasos_comunes
                                    ));
                                comprobante_energia.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        energia
                                    ));
                                comprobante_agua.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        agua
                                    ));
                                comprobante_cargo_fijo_agua.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        cargo_fijo_agua
                                    ));
                                comprobante_cuota_asoc.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        cuota_asoc
                                    ));

                                comprobante_otros_ingresos.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        otros_ingresos
                                    ));
                                comprobante_multa_e_intereses.Add(new EComprobante_Detalle(
                                        rut,
                                        glosa,
                                        multa_e_intereses
                                    ));

                            }
                            else
                            {
                                rep.Reportar("NO VALIDA", false);
                            }

                        }

                    }

                    // una vez encontrado los datos
                    List<EComprobante_Detalle> detalles = new List<EComprobante_Detalle>();

                    detalles.AddRange(comprobante_gasto_comun.ExtraerComprobantes());
                    detalles.AddRange(comprobante_energia.ExtraerComprobantes());
                    detalles.AddRange(comprobante_agua.ExtraerComprobantes());
                    detalles.AddRange(comprobante_cargo_fijo_agua.ExtraerComprobantes());
                    detalles.AddRange(comprobante_cuota_asoc.ExtraerComprobantes());
                    detalles.AddRange(comprobante_otros_ingresos.ExtraerComprobantes());
                    detalles.AddRange(comprobante_multa_e_intereses.ExtraerComprobantes());


                    res.Correcto();
                    res.Respuesta = detalles;

                }
                else
                {
                    return res.Error("No hay excel en la tabla para verificar");
                }

            }catch(Exception ex)
            {
                return res.Error(ex);
            }

            return res;
        }

        private void comboBoxPitagoras1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPitagoras1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void cmbMeses_PositionChanged(object sender, EventArgs e)
        {
            EMes mes = (EMes)this.bindingCmbMeses.Current;

            if (mes != null)
                this.lbPrefijoNComprobante.Text = mes.Id.ToString().PadLeft(2, '0') + mes.Id.ToString().PadLeft(2, '0');
            else
                this.lbPrefijoNComprobante.Text = "0000";

        }

        private async void btnInsertarDatos_Click(object sender, EventArgs e)
        {
            System.Collections.IList lista = this.ComprobantesContables.List;

            if (lista.Count == 0 || !(lista is List<EComprobante_Detalle>))
            {
                this.Aviso("No se encontraron datos para impotar o no tienen el formato correcto");
                return;
            }

            List<EComprobante_Detalle> lista_comprobantes = (List<EComprobante_Detalle>)lista;

            Reportador rep = new Reportador();
            Res res = await this.EjecutarAsyncAwait(() => { return this.InsertarDatos(lista_comprobantes, rep); }, "Insertando", rep, false);


            this.dgvExcels.Refresh();

            if (res.IsCorrecto)
            {
                this.grInsertarDatos.Enabled = false;
                this.grExtraerDatos.Enabled = true;
            }

            this.Message(res);
        }

        private Res InsertarDatos(List<EComprobante_Detalle > detalle_a_insertar, Reportador rep)
        {
            Res res = new Res();

            string nombre_carpeta = @"C:\Users\Seba\source\repos\Importador Contable BA\Datos Git\contajvh\A2020\75941710";
            string nombre_db = @"MovSys";


            rep.Reportar("Conectando con la base de datos");
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + nombre_carpeta + "; Extended Properties = dBase IV; User ID=; Password=";
            con.Open();

            try
            {
                string consulta = "select * from " + nombre_db;

                foreach (EComprobante_Detalle detalle in detalle_a_insertar)
                {
                    OleDbCommand oCmd = con.CreateCommand();
                    // Insert the row
                    oCmd.CommandText = "INSERT INTO " + nombre_db + " (A, FEC, NUM, GLO, C, D, LINEA, PTO1) VALUES " + "(" + detalle.SQLValues() + ");";

                    int result = oCmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        rep.Reportar("Se inserto correctamente el registro " + detalle.Glosa_Formateada);
                    }
                    else
                    {
                        return res.Error("No se pudo insertar la fila");
                    }
                }

                // Read the table
                //oCmd.CommandText = consulta;

                //DataTable dt = new DataTable();
                //dt.Load(oCmd.ExecuteReader());

                //this.dgvTest.DataSource = dt;
            }
            catch (Exception ex)
            {
                return res.Error(ex.Message);
            }
            finally
            {
                rep.Reportar("Se cierra la conexion con la base de datos");
                con.Close();
            }

            res.Correcto();
            return res;
        }

        private void lbPathAplicacion_Click(object sender, EventArgs e)
        {

        }

        private void txtDv_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRutEmpresa_Leave(object sender, EventArgs e)
        {
            //this.txtRutEmpresa.Value = this.Setting.Rut_empresa;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvarRutEmpresa_Click(object sender, EventArgs e)
        {
            int rut_empresa = this.txtRutEmpresa.ValueInt;

            if(rut_empresa == 0)
            {
                this.Aviso("Estas intentado guardar un rut vacio?");
                return;
            }

            this.Setting.Rut_empresa = rut_empresa;
            this.Setting.Save();

            this.Informacion("Se ha salvado el rut");
        }

        private void cmbAnio2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rut_empresa = this.txtRutEmpresa.ValueInt;

            if(rut_empresa == 0)
            {
                this.ErrorPathMovSys("El Rut de Empresa esta vacio");
                return;
            }


            EAnio e_anio = (EAnio)this.bindingCmbAnio.Current;

            if(e_anio == null)
            {
                this.ErrorPathMovSys("No se pudo obtener el año del combo año");
                return;
            }

            int anio = e_anio.Id;
            string path_aplicacion_contable = this.Setting.Path_aplicacion_contable;

            if (string.IsNullOrEmpty(path_aplicacion_contable))
            {
                this.ErrorPathMovSys("No se ha indicado el direcctorio de la aplicacion contable");
                return;
            }

            if (!Directory.Exists(path_aplicacion_contable))
            {
                this.ErrorPathMovSys("El direcctorio de la aplicacion contable indicado no existe");
                return;
            }

            this.SetPathMovSys(Path.Combine(path_aplicacion_contable, "A" + anio.ToString(), rut_empresa.ToString(), "MovSys.dbf"));
        }
    }
}
