using Herramientas;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class ParametroEmpresaEventArgs : EventArgs
    {
        EEmp_Parametros parametros;

        public EEmp_Parametros Parametros { get => parametros; set => parametros = value; }
    }

    public class Sesion
    {
        static Sesion miSesion;

        /// <summary>
        /// Singleton a MiSesion
        /// </summary>
        public static Sesion MiSesion
        {
            get
            {
                if (miSesion == null)
                    miSesion = new Sesion();
                return miSesion;
            }

            set => miSesion = value;
        }

        bool estaAutenticado = false;
        bool pasoPorElLogin = false;

        /// Usuario
        ///
        EMae_Usuarios usuario;

        /// Equipo
        ///
        EMae_Equipos equipo;

        /// Local
        ///
        EMae_Locales_Comuna_Lista_Precio local;

        /// Bodega
        /// 
        EMae_Bodegas bodega;

        /// Caja
        /// 
        EMae_Cajas caja;

        /// rol
        /// 
        EMae_Roles rol;

        // Empresas disponibles, sale desde el archivo de parametros al crear la sesion
        List<EMae_Empresas> empresas_Disponibles;

        //Empresa actual selecionada
        EMae_Empresas_Comuna_Ciudad empresa;

        /// medios de pagos disponibles en la venta
        /// 
        List<EMae_Medios_De_Pagos> medios_Pagos;


        private DataTable documentos_Tributarios_dt;

        /// docuemtnos tributarios, no importa si estan activos pero tienen que ser de la empresa
        List<EMae_Doc_Tributarios> documentos_Tributarios;

        /// Lista de direcciones de los locales, es una clase especial para mostrar direcciones a secas
        List<EMae_Locales_Direcciones_Comuna_Ciudad> direcciones_locales;

        // Apertura CAja
        EMae_Aperturas_Caja aperturas_caja;

        // Lista de las impresoras con los tipos de documento y traslado de bienes
        List<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado> impresoras;

        public uint getIdLocal()
        {
            if (this.local == null)
                return 0;

            return this.local.Id;
        }

        public uint getIdCaja()
        {
            if (!this.ExisteCaja())
                return 0;

            return this.caja.Id;
        }

        public uint getIdBodega()
        {
            if (!this.ExistenBodega())
                return 0;

            return this.bodega.Id;
        }

        public uint getIdAperturaCaja()
        {
            if (!this.ExisteCajaAbierta())
                return 0;

            return this.aperturas_caja.Id;
        }

        public uint getCodAperturaCaja()
        {
            if (!this.ExisteCajaAbierta())
                return 0;

            return this.aperturas_caja.Cod_apertura;
        }

        public EMae_Cajas getEMae_Cajas()
        {
            if (this.ExisteCaja())
                return this.caja;

            return null;
        }
        public bool ExisteCaja()
        {
            return this.caja != null && this.caja.Id != 0;
        }
        public bool ExistenLocal()
        {
            return this.local != null && this.local.Id != 0;
        }
        public bool ExistenBodega()
        {
            return this.bodega != null && this.bodega.Id != 0;
        }
        public bool ExistenEquipo()
        {
            return this.equipo != null && this.equipo.Id != 0;
        }
        public bool ExistenRol()
        {
            return this.rol != null && this.rol.Id != 0;
        }
        public bool ExistenUsuario()
        {
            return this.usuario != null && this.usuario.Id != 0;
        }
        public bool ExistenMediosPago()
        {
            return this.medios_Pagos != null && this.medios_Pagos.Count > 0;
        }
        public bool ExistenDocumentosTributarios()
        {
            return this.documentos_Tributarios != null && this.documentos_Tributarios.Count > 0;
        }
        public bool ExistenDireccionesLocales()
        {
            return this.direcciones_locales != null && this.direcciones_locales.Count > 0;
        }
        public bool ExistenDireccionesLocalesSinActual()
        {
            if (!this.ExistenDireccionesLocales())
                return false;

            List<EMae_Locales_Direcciones_Comuna_Ciudad> dir = this.Direcciones_locales_sin_actual;

            return dir != null && dir.Count > 0;
        }
        
        public bool ExistenImpresoras()
        {
            return this.impresoras != null && this.impresoras.Count > 0;
        }

        public bool ExisteCajaAbierta()
        {
            bool existe_apertura_caja = this.aperturas_caja != null && this.aperturas_caja.Id != 0 && this.aperturas_caja.Fecha_cierre == null;

            if (existe_apertura_caja && !this.ExisteCaja())
            {
                // no deberia no tener caja y tenerla abierta
            }

            return existe_apertura_caja;
        }

        public EMae_Aperturas_Caja getAperturaCaja()
        {
            if (this.ExisteCajaAbierta())
                return this.aperturas_caja;
            return null;
        }

        public EMae_Cajas getCaja()
        {
            if (this.ExisteCaja())
                return this.caja;
            return null;
        }

        public uint getNumeroCaja()
        {
            if (this.ExisteCaja())
                return this.caja.Cod_caja;
            return 0;
        }

        private string urlParametro = @"Parametos\Parametos.xml";

        private Sesion()
        {
            this.InicializarSesion();
        }

        public Sesion(string nombre_form)
        {
            if (nombre_form == "Frm_New_login")
                this.pasoPorElLogin = true;

            this.InicializarSesion();
        }

        private void InicializarSesion()
        {
            this.ObtenerEquipoZeroParaMac();
            this.ObtenerUsuarioZeroParaUsoEnLaDB();
            this.ObtenerDesdeParametrosArchivo();

            miSesion = this;
        }

        private void ObtenerUsuarioZeroParaUsoEnLaDB()
        {
            this.usuario = new EMae_Usuarios();
        }

        private void ObtenerEquipoZeroParaMac()
        {
            EMae_Equipos equipo = new EMae_Equipos();
            equipo.Id = 0;
            equipo.Id_emp = 0;
            equipo.Mac = LogWriter.Mac;

            this.equipo = equipo;
        }

        public bool EstaAutenticado { get => estaAutenticado; }
        [XmlIgnoreAttribute]
        public bool NacioEnElLogin { get => pasoPorElLogin; set => pasoPorElLogin = value; }
        [XmlIgnoreAttribute]
        public EMae_Locales_Comuna_Lista_Precio Local { get => local; set => local = value; }
        public EMae_Bodegas Bodega { get => bodega; set => bodega = value; }
        [XmlIgnoreAttribute]
        public EMae_Cajas Caja { get => caja; set => caja = value; }
        public EMae_Roles Rol { get => rol; set => rol = value; }
        public EMae_Empresas_Comuna_Ciudad Empresa { get => empresa; set => empresa = value; }
        public EMae_Usuarios Usuario { get => usuario;
            set
            {
                usuario = value;
                this.estaAutenticado = true;
            }
        }
        public EMae_Equipos Equipo { get => equipo; set => equipo = value; }
        public string root_path;
        [XmlIgnoreAttribute]
        public string RootPath { get => root_path; }
        [XmlIgnoreAttribute]
        public List<EMae_Medios_De_Pagos> Medios_Pagos { get => medios_Pagos;}
        [XmlIgnoreAttribute]
        public List<EMae_Doc_Tributarios> Documentos_Tributarios { get => documentos_Tributarios;}
        [XmlIgnoreAttribute]
        public List<EMae_Locales_Direcciones_Comuna_Ciudad> Direcciones_locales { get => direcciones_locales; }
        [XmlIgnoreAttribute]
        public List<EMae_Locales_Direcciones_Comuna_Ciudad> Direcciones_locales_sin_actual {
            get
            {
                if(this.local == null || this.local.Id == 0)
                {
                    Interacciones.Ex("Para llamar esta funcion se necesita un local en la sesion con una id valida");
                }

                List<EMae_Locales_Direcciones_Comuna_Ciudad> list = new List<EMae_Locales_Direcciones_Comuna_Ciudad>();

                foreach( EMae_Locales_Direcciones_Comuna_Ciudad dir in this.direcciones_locales)
                {
                    if (dir.Id_local != this.local.Id)
                        list.Add(dir);
                }

                return list;
            }
        }

        #region Actulziacion de la Sesion desde la DB
        delegate Res EjecutarActualziarValoresDesdeDB();
        /// <summary>
        /// Una vez asignado el evento para reobtener los varoes de ls DB actualzados (esto debe ocurrir al crear la sesion)
        /// Con este metodo se puede reobtenerla o tenerla actualizada con los datos reales al ser llamada
        /// </summary>
        public void ActualizarValoresDesdeDB()
        {
            if(obtenerSesionDB == null)
            {
                Interacciones.Ex("No esta asignada la funcion que bsucara los valores de la sesion en la DB");
            }
            else
            {
                Res res = obtenerSesionDB();
                this.CargarDatosSesion(res, true);
            }
        }

        Func<Res> obtenerSesionDB;
        public void SetFuncionActualizarDesdeDB(Func<Res> obtenerSesionDB)
        {
            this.obtenerSesionDB = obtenerSesionDB;
        }

        public event EventHandler CambioParametrosEmpresa;
        protected virtual void OnCambioParametrosEmpresa(ParametroEmpresaEventArgs e)
        {
            EventHandler handler = CambioParametrosEmpresa;
            e.Parametros = Sesion.miSesion.empresa.Parametros;
            handler?.Invoke(this, e);
        }
        public delegate void CambioParametrosEmpresaEventHandler(object sender, ParametroEmpresaEventArgs e);

        /// <summary>
        /// Evento que se dispara al actualizar la sesion
        /// </summary>
        public event EventHandler CambioSesion;
        protected virtual void OnCambioSesion(EventArgs e)
        {
            EventHandler handler = CambioSesion;
            handler?.Invoke(this, e);
        }
        public delegate void CambioSesionEventHandler(object sender, EventArgs e);
        #endregion

        /// <summary>
        /// Revuelve los documentos tributarios vigentes en formato que se pueda cargar en un combo
        /// </summary>
        public DataTable Documentos_Tributarios_dt_vigentes {
            get
            {
                // solo devolver los vigentes
                return Formateador.SelectDT(this.documentos_Tributarios_dt, "vigente = 'S'", "orden");
            }
        }

        /// <summary>
        /// Revuelve los documentos tributarios en formato que se pueda cargar en un combo
        /// </summary>
        public DataTable Documentos_Tributarios_dt
        {
            get
            {
                // solo devolver los vigentes
                return documentos_Tributarios_dt;
            }
        }

        public EMae_Aperturas_Caja Aperturas_caja { get => aperturas_caja; set => aperturas_caja = value; }
        [XmlIgnoreAttribute]
        internal List<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado> Impresoras { get => impresoras; set => impresoras = value; }
        public EMae_Equipos_Cajas Equipo_Cajas {
            get
            {
                EMae_Equipos_Cajas equipo = Entidad.PoblarDesdeUnObjeto<EMae_Equipos_Cajas, EMae_Equipos>(this.equipo);
                if (this.ExisteCaja())
                    equipo.Id_caja = this.caja.Id;

                return equipo;
            }
        }

        public string MostrarLocal()
        {
            EMae_Locales_Comuna_Lista_Precio local = this.local;
            if(local != null)
            {
                return local.Mostrar();
            }

            return "Desconocido";
        }

        public string MostrarBodega()
        {
            EMae_Bodegas bodega = this.bodega;
            if (bodega != null)
            {
                return bodega.Mostrar();
            }

            return "Desconocida";
        }

        public string MostrarCaja()
        {
            if (this.isCaja())
            {
                EMae_Cajas caja = this.caja;

                return caja.Mostrar();
            }
            else
            {
                return "NO ERES CAJA";
            }

        }

        public bool isCaja()
        {
            if (this.caja == null || this.caja.Id == 0)
                return false;
            else
                return true;
        }

        public List<EMae_Empresas> Empresas_Disponibles()
        {
            return this.empresas_Disponibles;
        }

        public void ObtenerDesdeParametrosArchivo()
        {
            if (File.Exists(this.urlParametro))
            {
                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(this.urlParametro);

                    string sub_fijo = "Parametros";

                    //XmlNode nodo = xml.SelectSingleNode( sub_fijo + "/Usuario");

                    #region Empresas Disponibles
                    this.empresas_Disponibles = new List<EMae_Empresas>();
                    XmlNodeList empresas_disponibles = xml.SelectNodes(sub_fijo + "/EmpresasDisponibles/Empresa");

                    foreach (XmlNode nodo in empresas_disponibles)
                    {
                        EMae_Empresas empresa_disponible = new EMae_Empresas();

                        XmlNode nodo_id = nodo.SelectSingleNode("Id");
                        if (nodo_id != null)
                        {
                            empresa_disponible.Id = Formateador.ToUInt32(nodo_id.InnerText);
                        }

                        XmlNode nodo_rut = nodo.SelectSingleNode("Rut");
                        if (nodo_rut != null)
                        {
                            empresa_disponible.Rut = Formateador.ToUInt32(nodo_rut.InnerText);
                        }

                        XmlNode nodo_dv = nodo.SelectSingleNode("Dv");
                        if (nodo_dv != null)
                        {
                            empresa_disponible.Dv = Formateador.ToString(nodo_dv.InnerText);
                        }

                        XmlNode nodo_razon_social = nodo.SelectSingleNode("Razon_social");
                        if (nodo_razon_social != null)
                        {
                            empresa_disponible.Razon_social = Formateador.ToString(nodo_razon_social.InnerText);
                        }

                        this.empresas_Disponibles.Add(empresa_disponible);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    new LogWriter(ex);
                }
            }

            
        }

        public Ambiente getAmbiente()
        {
            if (this.empresa == null || this.empresa.Sii == null)
                return Ambiente.CERTIFICACION;

            if(this.empresa.Sii.Ambiente == Ambiente.PRODUCCION)
            {

            }

            return this.empresa.Sii.Ambiente;
        }

        public string getEmailUsuarioAdministradorSegunAmbiente()
        {
            if (this.empresa == null || this.empresa.Sii == null)
                return string.Empty;

            if (this.getAmbiente() == Ambiente.PRODUCCION)
                return this.empresa.Sii.Email_usuario_administrador_produccion;
            else
                return this.empresa.Sii.Email_usuario_administrador_certificacion;
        }

        /// <summary>
        /// Convierte la clase en un string XML
        /// </summary>
        /// <returns>string de XML</returns>
        public string XML()
        {
            XmlSerializer x = new XmlSerializer(this.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }

        public static void Borrar()
        {
            miSesion = new Sesion();
        }

        public Res ValidaSiEsUnaSesionAptaParaElCorrectoFuncionamientoDeLaAplicacion()
        {
            Res res = new Res("Sesion inválida");

            if (this.empresa == null)
                return res.ErrorContexto("No tiene empresa");
            else if (this.empresa.Sii == null)
                return res.ErrorContexto("No tiene datos del SII");
            else if (this.empresa.Parametros == null)
                return res.ErrorContexto("Empresa no tiene parametros");
            else if (!this.ExistenLocal())
                return res.ErrorContexto("No tiene local");
            else if (!this.ExistenBodega())
                return res.ErrorContexto("No tiene local");
            else if (!this.ExistenEquipo())
                return res.ErrorContexto("No tiene equipo");
            else if (!this.ExistenRol())
                return res.ErrorContexto("No tiene rol");
            else if (!this.ExistenUsuario())
                return res.ErrorContexto("No tiene usuario");



            res.Correcto();
            return res;
        }

        public static string NombrePago(uint id_pagos)
        {
            string nombre_pago = "Desconocido";

            List<EMae_Medios_De_Pagos> medios_pago = Sesion.MiSesion.medios_Pagos;

            if(medios_pago != null)
            {
                foreach(EMae_Medios_De_Pagos medio_pago in medios_pago)
                {
                    if (medio_pago.Id == id_pagos)
                        return medio_pago.Nombre_forma_pago;
                }
            }

            return nombre_pago;
        }

        public EMae_Emails getEMae_EmailsUsuarioAdministradorSegunAmbiente()
        {
            EMae_Emails email = new EMae_Emails();

            // si no esta la seccion que contiene los mails, retorna nulo inmediatamente
            if (this.empresa == null || this.empresa.Sii == null)
                return null;

            EEmp_SII emp_sii = this.empresa.Sii;

            if (emp_sii.Ambiente == Ambiente.PRODUCCION)
            {
                email.Email = emp_sii.Email_usuario_administrador_produccion;
                email.Clave = emp_sii.Clave_usuario_administrador_produccion;
            }
            else
            {
                email.Email = emp_sii.Email_usuario_administrador_certificacion;
                email.Clave = emp_sii.Clave_usuario_administrador_certificacion;
            }

            // solo si el email tiene valores validos lo devuelve
            if(!string.IsNullOrEmpty(email.Email) && !string.IsNullOrEmpty(email.Clave))
                return email;

            return null;
        }

        public static string NombreDTE(uint tipo)
        {
            string nombre_pago = "Desconocido";

            List<EMae_Doc_Tributarios> tipos_dtes = Sesion.MiSesion.documentos_Tributarios;

            if (tipos_dtes != null)
            {
                foreach (EMae_Doc_Tributarios tipo_dte in tipos_dtes)
                {
                    if (tipo_dte.Cod == tipo)
                        return tipo_dte.Nom_docsii;
                }
            }

            return nombre_pago;
        }

        /*
        // se comento porque los maeils ya no estan en un mantnedor por separado, son parte de emp_sii
        // se dejo porque es un metodo que busca por id, su estructura será reutilizada
        public static EMae_Emails ObtenerEmailDesdeId(uint id)
        {
            List<EMae_Emails> emails = Sesion.miSesion.emails;

            if (emails != null)
            {
                foreach (EMae_Emails email in emails)
                {
                    if (email.Id == id)
                        return email;
                }
            }

            return null;
        }
        */


        /// <summary>
        /// Se obtiene la impresora como cadena desde la sesion imgresando el tipo de dte y el tipo_traspado_bienes
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="tipo_traslado_bienes"></param>
        /// <returns></returns>
        public static string ObtenerImpresoraDedeTipoYTrasladoBienes(uint tipo, uint tipo_traslado_bienes)
        {
            List<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado> impresoras = Sesion.miSesion.impresoras;

            if (impresoras != null)
            {
                foreach (ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado impresora in impresoras)
                {
                    if (impresora.Cod == tipo && impresora.Tipo_traslado_bienes == tipo_traslado_bienes)
                        return impresora.Impresora;
                }
            }

            return string.Empty;
        }

        public void CargarTodosLosDatosSesion(EMae_Usuarios usuario, Res res)
        {
            Sesion.MiSesion.Usuario = usuario;

            this.CargarDatosSesion(res);
        }

        private void CargarDatosSesion(Res res, bool recargar_sesion = false)
        {
            int indice_base = 0;

            if (recargar_sesion)
            {
                indice_base--;
                if (Sesion.miSesion.usuario.Id == 0)
                    Interacciones.Ex("Para recargar la sesion primero debes haber inciado una, no se reconoce el usuario que se debio cargar en un inicio");
            }

            Sesion.MiSesion.Empresa = Entidad.PoblarUnoDesdeDataDataTable<EMae_Empresas_Comuna_Ciudad>(res.ObtenerResultadoDT(indice_base + 1));

            #region Parametros empresa
            Sesion.MiSesion.Empresa.Parametros = Entidad.PoblarUnoDesdeDataDataTable<EEmp_Parametros>(res.ObtenerResultadoDT(indice_base + 7));
            ParametroEmpresaEventArgs param_e = new ParametroEmpresaEventArgs();
            Sesion.MiSesion.OnCambioParametrosEmpresa(param_e); 
            #endregion

            Sesion.MiSesion.Empresa.Sii = Entidad.PoblarUnoDesdeDataDataTable<EEmp_SII>(res.ObtenerResultadoDT(indice_base + 8));
            Sesion.MiSesion.Local = Entidad.PoblarUnoDesdeDataDataTable<EMae_Locales_Comuna_Lista_Precio>(res.ObtenerResultadoDT(indice_base + 2));
            Sesion.MiSesion.Local.Lista_precios = Entidad.PoblarUnoDesdeDataDataTable<EMae_Lista_Precios>(res.ObtenerResultadoDT(indice_base + 9));
            Sesion.MiSesion.Bodega = Entidad.PoblarUnoDesdeDataDataTable<EMae_Bodegas>(res.ObtenerResultadoDT(indice_base + 3));
            Sesion.MiSesion.Caja = Entidad.PoblarUnoDesdeDataDataTable<EMae_Cajas>(res.ObtenerResultadoDT(indice_base + 4));
            Sesion.MiSesion.Equipo = Entidad.PoblarUnoDesdeDataDataTable<EMae_Equipos>(res.ObtenerResultadoDT(indice_base + 5));
            Sesion.MiSesion.Rol = Entidad.PoblarUnoDesdeDataDataTable<EMae_Roles>(res.ObtenerResultadoDT(indice_base + 6));
            Sesion.MiSesion.medios_Pagos = new List<EMae_Medios_De_Pagos>(Entidad.PoblarDesdeDataDataTable<EMae_Medios_De_Pagos>(res.ObtenerResultadoDT(indice_base + 10)));

            // en este caso se guarda como dt para poder usarlo mas tarde
            Sesion.MiSesion.documentos_Tributarios_dt = res.ObtenerResultadoDT(indice_base + 11);
            Sesion.MiSesion.documentos_Tributarios = new List<EMae_Doc_Tributarios>(Entidad.PoblarDesdeDataDataTable<EMae_Doc_Tributarios>(Sesion.MiSesion.documentos_Tributarios_dt));

            Sesion.MiSesion.direcciones_locales = new List<EMae_Locales_Direcciones_Comuna_Ciudad>(Entidad.PoblarDesdeDataDataTable<EMae_Locales_Direcciones_Comuna_Ciudad>(res.ObtenerResultadoDT(indice_base + 12)));
            Sesion.MiSesion.aperturas_caja = Entidad.PoblarUnoDesdeDataDataTable<EMae_Aperturas_Caja>(res.ObtenerResultadoDT(indice_base + 13));
            Sesion.MiSesion.impresoras = new List<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado>(Entidad.PoblarDesdeDataDataTable<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado>(res.ObtenerResultadoDT(indice_base + 14)));


            this.OnCambioSesion(new EventArgs());
        }

        public string NumeroAnioResImprecion()
        {
            if (this.empresa == null)
                Interacciones.Ex("Empresa Vacia");
            else if (this.empresa.Sii == null)
                Interacciones.Ex("Datos del SII en empresa vacios");

            return this.empresa.Sii.Numero_resolucion_segun_ambiente + " del " + this.empresa.Sii.Fecha_resolucion_segun_ambiente.ToString("yyyy");
        }
    }
}
