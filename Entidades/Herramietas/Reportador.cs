using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Herramietas
{
    public class ReportandorEventArgs : EventArgs
    {
        string reporte;
        bool salto_linea;

        public string Reporte { get => reporte; set => reporte = value; }
        public bool Salto_linea { get => salto_linea; set => salto_linea = value; }
    }

    public class InicializarProgresoEventArgs : EventArgs
    {
        int inicio = 0;
        int termino = 0;
        string titulo = "";

        public int Inicio { get => inicio; set => inicio = value; }
        public int Final { get => termino; set => termino = value; }
        public string Titulo { get => titulo; set => titulo = value; }
    }

    /// <summary>
    /// Esta clase se encarga de reportar y notificar al formulario de los reportes
    /// </summary>
    public class Reportador
    {
        #region Reportador
        /// <summary>
        /// Se envia una cadena de texto que es notificada al reportador y mostrada, es el reporte visible
        /// </summary>
        /// <param name="reporte"></param>
        public void Reportar(string reporte, bool salto_linea = true)
        {
            ReportandorEventArgs repArg = new ReportandorEventArgs();
            repArg.Reporte = reporte;
            repArg.Salto_linea = salto_linea;
            this.OnReportador(repArg);
        }

        public event ReportadorEventHandler Reportando;

        protected virtual void OnReportador(ReportandorEventArgs e)
        {
            ReportadorEventHandler handler = this.Reportando;
            handler?.Invoke(this, e);

            new LogWriter(e.Reporte);
        }

        public delegate void ReportadorEventHandler(object sender, ReportandorEventArgs e);
        #endregion

        #region Iniciar Progreso
        public void InicializarProgreso(int inicio, int final, string titulo = "")
        {
            InicializarProgresoEventArgs arg = new InicializarProgresoEventArgs();
            arg.Inicio = inicio;
            arg.Final = final;
            arg.Titulo = titulo;
            this.OnReportador(arg);
        }

        public event IniciadorProgresoEventHandler InicializadorProgreso;

        protected virtual void OnReportador(InicializarProgresoEventArgs e)
        {
            IniciadorProgresoEventHandler handler = this.InicializadorProgreso;
            handler?.Invoke(this, e);
        }

        public delegate void IniciadorProgresoEventHandler(object sender, InicializarProgresoEventArgs e);
        #endregion

        #region Notificar Progreso
        public void NotificarProcreso()
        {
            this.OnNotificarProgreso(new EventArgs());
        }

        public event NotificarProgresoEventHandler NotificarProgreso;

        protected virtual void OnNotificarProgreso(EventArgs e)
        {
            NotificarProgresoEventHandler handler = this.NotificarProgreso;
            handler?.Invoke(this, e);
        }

        public delegate void NotificarProgresoEventHandler(object sender, EventArgs e);
        #endregion

        public void NotificarProcreso(int count)
        {
            //throw new NotImplementedException();
        }
    }
}
