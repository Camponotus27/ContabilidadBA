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
using System.Text.RegularExpressions;

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
                this.txtPathMovSys.Text = path;


                this.lbPathMovSys.ForeColor = Color.Black;
            }
            else
            {
                this.ErrorPathMovSys("No se encontro el MovSys en la direccion construida a partir de los datos ingresados");
            }
        }

        private void ErrorPathMovSys(string error)
        {
            this.path_mov_sys = string.Empty;
            this.txtPathMovSys.Text = error;
            this.lbPathMovSys.ForeColor = Color.Red;


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
                this.txtPathAplicacion.Text = this.Setting.Path_aplicacion_contable;


                this.CalcularPathMovSys();

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
                        this.txtPathAplicacion.Text = file;
                        this.Setting.Save();

                        this.CalcularPathMovSys();
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

            List<EPath_Excel> lista_path = new List<EPath_Excel>();

            foreach (EPath_Excel path in lista)
            {
                lista_path.Add(path);
            }

            this.Setting.Path_excel = lista_path;
            this.Setting.Save();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(this.bindingExcel.Current != null)
            {
                this.bindingExcel.RemoveCurrent();

                this.GuardarTabla();
            }
        }

        private async void btnVerificarFormato_Click(object sender, EventArgs e)
        {
            string path_mov_sys = this.path_mov_sys;

            if (string.IsNullOrEmpty(path_mov_sys))
            {
                this.Aviso("No esta signada la varialble de la direccion del fichero MovSys");
                return;
            }
            else if(!File.Exists(path_mov_sys))
            {
                this.Aviso("No se encontro el fichero MovSys");
                return;
            }

            if(this.Pregunta("Quieres calcular el numero de comprobante automaticamente? actualmente es " + this.GetNumeroComprobanteActual().ToString().PadLeft(7, '0'), RespuestaPregunta.Si))
            {
                if (!this.VerificarMomSysExiste())
                return;

                Reportador rep1 = new Reportador();
                Res res_consulta_ultimo_numero = this.GetSigueinteNumeroComprobante(this.path_mov_sys, rep1);

                if (res_consulta_ultimo_numero.IsCorrecto)
                {
                    if (res_consulta_ultimo_numero.Respuesta is decimal)
                    {
                        this.txtNComprobante.Value = ((decimal)res_consulta_ultimo_numero.Respuesta) % 100;
                    }
                    else
                    {
                        this.Aviso("La respuesta no es un numero");
                        return;
                    }
                }
                else
                {
                    this.Aviso("No se pudo obtener el siguiente numero");
                    return;
                }
            }


            EMes e_mes = (EMes)this.bindingCmbMeses.Current;
            EAnio e_anio = (EAnio)this.bindingCmbAnio.Current;

            int numero_comprobante_inicial = this.GetNumeroComprobanteActual();

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
            Res res = await this.EjecutarAsyncAwait(() => { return this.ExtraerDatos(e_mes, e_anio, numero_comprobante_inicial, rep); }, "Recopilando Datos", rep, false);


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
            else
            {
                rep.ForzarFinalizacion();
            }

            this.dgvComprobantes.Refresh();
            this.dgvExcels.Refresh();

            this.Message(res);
        }

        private int GetNumeroComprobanteActual()
        {
            int numero_comprobante_inicial_prefijo = Formateador.ToInt32(this.lbPrefijoNComprobante.Text);

            numero_comprobante_inicial_prefijo *= 1000;

            return numero_comprobante_inicial_prefijo + this.txtNComprobante.ValueInt;
        }

        private Res ExtraerDatos(EMes e_mes, EAnio e_anio, int numero_comprobante_inicial, Reportador rep)
        {
            Res res = new Res();
            Excel.Application excel_Aplicacion = null;
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
                EComprobante comprobante_gasto_comun = new EComprobante("GASTO COMUN", nombre_mes, numero_comprobante_inicial, fecha_ultimo_dia_mes, 1600101, 9100101);
                EComprobante comprobante_energia = new EComprobante("LUZ", nombre_mes, numero_comprobante_inicial + 1, fecha_ultimo_dia_mes, 1600102, 9100103);
                EComprobante comprobante_agua = new EComprobante("AGUA", nombre_mes, numero_comprobante_inicial + 2, fecha_ultimo_dia_mes, 1600103, 9100102);
                EComprobante comprobante_cargo_fijo_agua = new EComprobante("CARGO FIJO", nombre_mes, numero_comprobante_inicial + 3, fecha_ultimo_dia_mes, 1600113, 9100108);
                EComprobante comprobante_cuota_asoc = new EComprobante("CUOTA ASOCIACION", nombre_mes, numero_comprobante_inicial + 4, fecha_ultimo_dia_mes, 1600110, 4500101);

                // este no se dice pero aparece en el comprobante final
                EComprobante comprobante_otros_ingresos = new EComprobante("OTROS INGRESOS", nombre_mes, numero_comprobante_inicial + 5, fecha_ultimo_dia_mes, 1600112, 9100107);
                EComprobante comprobante_multa_e_intereses = new EComprobante("MULTAS E INTERESES", nombre_mes, numero_comprobante_inicial + 6, fecha_ultimo_dia_mes, 1600106, 9100104);


                EComprobante comprobante_cobranza_judicial = new EComprobante("COBRANZA JUDICIAL", nombre_mes, numero_comprobante_inicial + 7, fecha_ultimo_dia_mes, 1610101);

                List<EComprobante> lista_comprobantes_reemplazo_otros = new List<EComprobante>()
                {
                    comprobante_gasto_comun,
                    comprobante_energia,
                    comprobante_agua
                };

                System.Collections.IList lista = this.bindingExcel.List;

                if (lista.Count > 0)
                {
                    rep.Reportar("Iniciando aplicacion Excel");
                    excel_Aplicacion = new Excel.Application();
                    excel_Aplicacion.Visible = false;

                    Excel.Workbooks libros_excel = excel_Aplicacion.Workbooks;

                    foreach (EPath_Excel path in lista)
                    {
                        Excel.Workbook libro_excel = libros_excel.Open(path.Path_excel, null, true);
                        rep.Reportar("Abriendo documento " + libro_excel.Name);

                        rep.Reportar("Iniciando hojas Excel");
                        Excel.Sheets hojas = libro_excel.Sheets;

                        // Las hojas validas deven estar entre el Inicio y el final por lo que se manejaran estados
                        bool pasando_por_inicio = false;
                        bool paso_por_inicio = false;
                        bool pasando_por_final = false;


                        foreach (Excel._Worksheet hoja in hojas)
                        {
                            if (!string.IsNullOrEmpty(hoja.Name))
                            {
                                string nombre_hoja_formateado = hoja.Name.Trim().ToUpper();

                                switch (nombre_hoja_formateado)
                                {
                                    case "INICIO":
                                        pasando_por_inicio = true;
                                        break;
                                    case "FINAL":
                                        pasando_por_final = true;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            // si encuentra el final se saldrá del ciclo foreach
                            if (pasando_por_final)
                                break;

                            if (paso_por_inicio && !pasando_por_final)
                            {
                                rep.Reportar("Abriendo hoja " + hoja.Name);
                                // en cabezado hoja
                                string valor_parcela = Formateador.GetExcel<string>(hoja, "B1");
                                string valor_sector = Formateador.GetExcel<string>(hoja, "B2");
                                string valor_propietario = Formateador.GetExcel<string>(hoja, "B3");

                                // valores hoja
                                string valor_parcela_value = Formateador.GetExcel<string>(hoja, "D1");
                                string valor_sector_value = Formateador.GetExcel<string>(hoja, "D2");

                                string glosa_personalizada = Formateador.GetExcel<string>(hoja, "A2");
                                string rut = Formateador.GetExcel<string>(hoja, "A3");

                                string valor_cobranza_judicial_value = Formateador.GetExcel<string>(hoja, "F3");

                                bool en_cobranza_judicial = valor_cobranza_judicial_value == "EN COBRANZA JUDICIAL";

                                // aca se valida si la pagina es valida

                                bool es_una_pagina_valida = true;
                                string mensaje_de_no_valida = string.Empty;

                                // si la D esta vacia prueba con la M
                                if (string.IsNullOrWhiteSpace(valor_parcela_value) && string.IsNullOrWhiteSpace(valor_sector_value))
                                {
                                    valor_parcela_value = Formateador.GetExcel<string>(hoja, "M1");
                                    valor_sector_value = Formateador.GetExcel<string>(hoja, "M2");
                                }

                                /*
                                if (valor_parcela != "PARCELA")
                                {
                                    es_una_pagina_valida = false;
                                    mensaje_de_no_valida += " B1 no contiene 'PARCELA'";
                                }
                                else if (string.IsNullOrWhiteSpace(valor_parcela_value))
                                {
                                    es_una_pagina_valida = false;
                                    mensaje_de_no_valida += " D1 la parcela esta vacia";
                                }
                                else */
                                
                                if (valor_sector != "SECTOR")
                                {
                                    es_una_pagina_valida = false;
                                    mensaje_de_no_valida += " B2 no contiene 'SECTOR'";
                                }
                                else if (string.IsNullOrWhiteSpace(valor_sector_value))
                                {
                                    es_una_pagina_valida = false;
                                    mensaje_de_no_valida += " D2 el sector esta vacio";
                                }
                                else if (valor_propietario != "PROPIETARIO")
                                {
                                    es_una_pagina_valida = false;
                                    mensaje_de_no_valida += " B3 no contiene 'PROPIETARIO'";
                                }
                                else if (string.IsNullOrWhiteSpace(rut))
                                {
                                    es_una_pagina_valida = false;
                                    mensaje_de_no_valida += " A3 no contiene el Rut";
                                }


                                if (es_una_pagina_valida)
                                {
                                    if(hoja.Name == "LBA-P6")
                                        rep.Reportar("VALIDA (caso especial todo menos luz)", false);
                                    else if (hoja.Name == "LBA-P6 (2)")
                                        rep.Reportar("VALIDA (caso especial solo luz)", false);
                                    else
                                        rep.Reportar("VALIDA", false);
                                    
                                    path.Numero_hojas_validas++;

                                    // 1 Q gastos comunes
                                    // 2 G Energia
                                    // 3 L Agua
                                    // 4 M Cargo fijo agua
                                    // 5 N Cuota asoc

                                    // 6 Otros Ingresos
                                    // 7 R multa e intereses

                                    int gastos_comunes = Formateador.GetExcel<int>(hoja, "Q" + fila);
                                    int energia = Formateador.GetExcel<int>(hoja, "G" + fila);
                                    int agua = Formateador.GetExcel<int>(hoja, "L" + fila);
                                    int cargo_fijo_agua = Formateador.GetExcel<int>(hoja, "M" + fila);
                                    int cuota_asoc = Formateador.GetExcel<int>(hoja, "N" + fila);
                                    int otros_ingresos = Formateador.GetExcel<int>(hoja, "O" + fila);
                                    int multa_e_intereses = Formateador.GetExcel<int>(hoja, "R" + (fila - 1));

                                    string nota_otros_ingresos = Formateador.GetNotaExcel(hoja, "O" + fila);

                                    #region Validacion de valores negativos
                                    if (gastos_comunes < 0
                                        || energia < 0
                                        || agua < 0
                                        || cargo_fijo_agua < 0
                                        || cuota_asoc < 0
                                        || otros_ingresos < 0
                                        || multa_e_intereses < 0)
                                        return res.Error("Se recopilo un valor negativo en la hoja " + hoja.Name + " fila " + fila + " verifiquelo puesto el sistema no esta preparado para esta codicion");
                                    #endregion

                                    string glosa = string.Empty;

                                    if (!string.IsNullOrWhiteSpace(glosa_personalizada))
                                        glosa = glosa_personalizada;
                                    else if (string.IsNullOrWhiteSpace(valor_parcela_value))
                                        glosa = valor_sector_value;
                                    else
                                        glosa = "P" + valor_parcela_value + valor_sector_value;


                                    glosa = this.LimpiarGlosa(glosa);
                                    glosa = this.Abreviaciones(glosa);


                                    if (en_cobranza_judicial)
                                    {

                                        if (hoja.Name != "LBA-P6")
                                            comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                 comprobante_energia.Cuenta_abono,
                                                 rut,
                                                 glosa,
                                                 energia
                                             ));

                                        if (hoja.Name != "LBA-P6 (2)")
                                        {
                                            comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                comprobante_gasto_comun.Cuenta_abono,
                                                rut,
                                                glosa,
                                                gastos_comunes
                                            ));

                                            comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                    comprobante_agua.Cuenta_abono,
                                                    rut,
                                                    glosa,
                                                    agua
                                                ));
                                            comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                    comprobante_cargo_fijo_agua.Cuenta_abono,
                                                    rut,
                                                    glosa,
                                                    cargo_fijo_agua
                                                ));
                                            comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                    comprobante_cuota_asoc.Cuenta_abono,
                                                    rut,
                                                    glosa,
                                                    cuota_asoc
                                                ));

                                            bool se_intercambio_el_comprobante_otro = false;
                                            foreach (EComprobante comp_temp in lista_comprobantes_reemplazo_otros)
                                            {
                                                if (nota_otros_ingresos.Contains("'" + comp_temp.Nombre_comprobante + "'"))
                                                {
                                                    comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                        comp_temp.Cuenta_abono,
                                                        rut,
                                                        glosa,
                                                        otros_ingresos
                                                    ));

                                                    se_intercambio_el_comprobante_otro = true;
                                                    break;
                                                }
                                            }

                                            if (!se_intercambio_el_comprobante_otro)
                                            {
                                                comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                        comprobante_otros_ingresos.Cuenta_abono,
                                                        rut,
                                                        glosa,
                                                        otros_ingresos
                                                   ));
                                            }

                                            comprobante_cobranza_judicial.Add(new EComprobante_Detalle(
                                                    comprobante_multa_e_intereses.Cuenta_abono,
                                                    rut,
                                                    glosa,
                                                    multa_e_intereses
                                                ));
                                        }
                                    }
                                    else
                                    {
                                        if (hoja.Name != "LBA-P6")
                                            comprobante_energia.Add(new EComprobante_Detalle(
                                                rut,
                                                glosa,
                                                energia
                                            ));

                                        if (hoja.Name != "LBA-P6 (2)")
                                        {
                                            comprobante_gasto_comun.Add(new EComprobante_Detalle(
                                                rut,
                                                glosa,
                                                gastos_comunes
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

                                            bool se_intercambio_el_comprobante_otro = false;
                                            foreach(EComprobante comp_temp in lista_comprobantes_reemplazo_otros)
                                            {
                                                if (nota_otros_ingresos.Contains("'" + comp_temp.Nombre_comprobante + "'"))
                                                {
                                                    comp_temp.Add(new EComprobante_Detalle(
                                                        rut,
                                                        glosa,
                                                        otros_ingresos
                                                    ));

                                                    se_intercambio_el_comprobante_otro = true;
                                                    break;
                                                }
                                            }
                                            
                                            if(!se_intercambio_el_comprobante_otro)
                                            {
                                                comprobante_otros_ingresos.Add(new EComprobante_Detalle(
                                                       rut,
                                                       glosa,
                                                       otros_ingresos
                                                   ));
                                            }


                                            comprobante_multa_e_intereses.Add(new EComprobante_Detalle(
                                                    rut,
                                                    glosa,
                                                    multa_e_intereses
                                                ));
                                        }
                                    }


                                }
                                else
                                {
                                    rep.Reportar("NO VALIDA " + mensaje_de_no_valida, false);
                                }
                            }


                            if (pasando_por_inicio)
                                paso_por_inicio = true;
                        }

                        libro_excel.Close();
                        
                    }

                    libros_excel.Close();
                    excel_Aplicacion.Quit();

                    // una vez encontrado los datos
                    List<EComprobante_Detalle> detalles = new List<EComprobante_Detalle>();

                    detalles.AddRange(comprobante_gasto_comun.ExtraerComprobantes());
                    detalles.AddRange(comprobante_energia.ExtraerComprobantes());
                    detalles.AddRange(comprobante_agua.ExtraerComprobantes());
                    detalles.AddRange(comprobante_cargo_fijo_agua.ExtraerComprobantes());
                    detalles.AddRange(comprobante_cuota_asoc.ExtraerComprobantes());
                    detalles.AddRange(comprobante_otros_ingresos.ExtraerComprobantes());
                    detalles.AddRange(comprobante_multa_e_intereses.ExtraerComprobantes());
                    detalles.AddRange(comprobante_cobranza_judicial.ExtraerComprobantes());

                    res.Correcto();
                    res.Respuesta = detalles;
                }
                else
                {
                    return res.Error("No hay excel en la tabla para verificar");
                }

            }
            catch (Exception ex)
            {
                return res.Error(ex);
            }
            finally {
                if (excel_Aplicacion != null && excel_Aplicacion.Workbooks != null)
                {
                    excel_Aplicacion.Workbooks.Close();
                    excel_Aplicacion.Quit();
                }
            }

            /*
             * Private Sub releaseObject(ByVal obj As Object)
               Try
                   System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                   obj = Nothing
               Catch ex As Exception
                   obj = Nothing
               Finally
                   GC.Collect()
               End Try
            End Sub
            */

            return res;
        }

        private string LimpiarGlosa(string glosa)
        {
            if (!string.IsNullOrWhiteSpace(glosa))
            {
                return Regex.Replace(glosa.Replace(" ", ""), @"[^\w\s]+", "");
            }
            return string.Empty;
        }

        private string Abreviaciones(string glosa)
        {
            if (!string.IsNullOrEmpty(glosa))
                glosa = glosa.ToUpper();


            Dictionary<string, string> abreviaciones = new Dictionary<string, string>()
            {
                ["SUMINISTRO"] = "SUMIN",

                ["AGRICOLA"] = "AGRI",
                ["BOLDOS"] = "BOL",
                ["BOSQUES"] = "BOSQ",
                ["QUILLAYES"] = "QUI",


                ["PEUMOSII"] = "PII",

                ["PEUMOS"] = "PEU",
            };

            foreach (KeyValuePair<string, string> abreviacion in abreviaciones)
            {
                glosa = glosa.Replace(abreviacion.Key, abreviacion.Value);
            }

            return glosa;
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
            if (!this.VerificarMomSysExiste())
                return;


            System.Collections.IList lista = this.ComprobantesContables.List;

            if (lista.Count == 0 || !(lista is List<EComprobante_Detalle>))
            {
                this.Aviso("No se encontraron datos para impotar o no tienen el formato correcto");
                return;
            }

            List<EComprobante_Detalle> lista_comprobantes = (List<EComprobante_Detalle>)lista;

            Reportador rep = new Reportador();
            Res res = await this.EjecutarAsyncAwait(() => { return this.InsertarDatos(lista_comprobantes, this.path_mov_sys, rep); }, "Insertando", rep, false);


            this.dgvExcels.Refresh();

            if (res.IsCorrecto)
            {
                this.grInsertarDatos.Enabled = false;
                this.grExtraerDatos.Enabled = true;
            }

            this.Message(res);
        }

        private bool VerificarMomSysExiste()
        {
            if (string.IsNullOrEmpty(this.path_mov_sys))
            {
                this.Aviso("No esta signada la variable de la direccion del fichero MovSys");
                return false;
            }
            else if (!File.Exists(this.path_mov_sys))
            {
                this.Aviso("No se encontro el fichero MovSys");
                return false;
            }

            return true;
        }

        private Res InsertarDatos(List<EComprobante_Detalle > detalle_a_insertar, string path_mov_sys, Reportador rep)
        {
            Res res = new Res();

            rep.Reportar("Creando copia de seguridad");
            Res res_copia_seguridad = this.CrearCopiaDeSeguridad(path_mov_sys);

            if (res_copia_seguridad.IsError)
            {
                DialogResult d = MessageBox.Show("No se pudo crear la copia de segurdad, desea continaur de todas maneras?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                
                if(d == DialogResult.No)
                {
                    return res.Error("Detenido por el usuario");
                }
            }

            string nombre_carpeta = Path.GetDirectoryName(path_mov_sys);
            string nombre_db = Path.GetFileName(path_mov_sys);


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

        private Res CrearCopiaDeSeguridad(string path_mov_sys)
        {
            Res res = new Res();
            string path_respaldos = @"respaldos";

            if (File.Exists(path_mov_sys))
            {
                ManejoArchivos.CrearCarpetaSiNoExiste(path_respaldos);

                ManejoArchivos.Copiar(path_mov_sys, Path.Combine(path_respaldos, "MovSys" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + Path.GetExtension(path_mov_sys)));

                res.Correcto();
            }
            else
            {
                return res.Error("No existe el archivo " + path_mov_sys);
            }

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

            this.CalcularPathMovSys();

            this.Informacion("Se ha salvado el rut");
        }

        private void cmbAnio2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcularPathMovSys();
        }

        private void CalcularPathMovSys()
        {
            int rut_empresa = this.txtRutEmpresa.ValueInt;


            if(this.Setting.Rut_empresa != rut_empresa)
            {
                this.ErrorPathMovSys("Guarda el Rut de Empresa antes de continuar");
                return;
            }

            if (rut_empresa == 0)
            {
                this.ErrorPathMovSys("El Rut de Empresa esta vacio");
                return;
            }


            EAnio e_anio = (EAnio)this.bindingCmbAnio.Current;

            if (e_anio == null)
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

        private void tstbNuevaImportacion_Click(object sender, EventArgs e)
        {
            this.NuevaImportacion();
        }

        private void NuevaImportacion()
        {
            this.grExtraerDatos.Enabled = true;
            this.grInsertarDatos.Enabled = false;

            this.ComprobantesContables.Clear();
        }

        private async void buscarSiguienteNDisponibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.VerificarMomSysExiste())
                return;

            Reportador rep = new Reportador();
            Res res = await this.EjecutarAsyncAwait(() => { return this.GetSigueinteNumeroComprobante(this.path_mov_sys, rep); }, "Insertando", rep);

            if (res.IsCorrecto)
            {
                if(res.Respuesta is decimal)
                {
                    this.txtNComprobante.Value = (decimal)res.Respuesta;
                }
                else
                {
                    res.Error("La respuesta no es un numero");
                }
                
            }

            this.Message(res);
        }

        private Res GetSigueinteNumeroComprobante(string path_mov_sys, Reportador rep)
        {
            Res res = new Res();

            string nombre_carpeta = Path.GetDirectoryName(path_mov_sys);
            string nombre_db = Path.GetFileName(path_mov_sys);


            rep.Reportar("Conectando con la base de datos");
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + nombre_carpeta + "; Extended Properties = dBase IV; User ID=; Password=";
            con.Open();

            try
            {
                string consulta = "select MAX(NUM) AS MAXNUM, COUNT(NUM) AS COUNTNUM from " + nombre_db + " WHERE NUM LIKE '" + this.lbPrefijoNComprobante.Text + "%'";

                OleDbCommand oCmd = con.CreateCommand();
                // Read the table
                oCmd.CommandText = consulta;

                DataTable dt = new DataTable();
                dt.Load(oCmd.ExecuteReader());

                // columna numero comprobante NUM
                if(dt.Rows.Count > 0 && dt.Columns.Contains("MAXNUM") && dt.Columns.Contains("COUNTNUM"))
                {
                    res.Correcto();

                    decimal count_filas = Formateador.ToDecimal(dt.Rows[0]["COUNTNUM"]);

                    if (count_filas == 0)
                        res.Respuesta = 0M;
                    else
                        res.Respuesta = Formateador.ToDecimal(dt.Rows[0]["MAXNUM"]) + 1;

                }
                else
                {
                    return res.Error("No se obtubo el numero de comprobante");
                }
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
            return res;
        }
    }
}
