using Herramientas.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herramientas
{
    public partial class ReporteadorSegundoPlano : Form
    {
        static ReporteadorSegundoPlano instance;

        public static ReporteadorSegundoPlano Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReporteadorSegundoPlano();

                return instance;
            }
        }

        public static void Reportar(string reporte)
        {
            //Instance.ReportarInterno(reporte);
        }

        private bool is_shows = false;

        public ReporteadorSegundoPlano()
        {
            InitializeComponent();

            this.AjustarLocacion();
        }

        private void AjustarLocacion()
        {
            int alto_barra_tareas = 40;
            int magen = 4;

            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
            int deskWidth = Screen.PrimaryScreen.Bounds.Width;

            this.Location = new Point(
                    deskWidth - this.Width - magen,
                    deskHeight - this.Height - alto_barra_tareas - magen);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.is_shows = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.AjustarLocacion();
        }

        private void ReportarInterno(string reporte)
        {
            if (!this.is_shows)
                this.Show();


            EItemLista elemento = new EItemLista(1, reporte);

            Timer timer_temp = new Timer();
            timer_temp.Tick += (sender, e) =>
            {
                this.bsList.Remove(elemento);
                timer_temp.Stop();
                timer_temp.Dispose();
            };
            timer_temp.Interval = 3000; // in miliseconds
            timer_temp.Start();

            this.bsList.Add(elemento);


        }

        private void bsList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if(this.bsList.Count == 0)
                {
                    this.timer.Start();
                    return;
                }
            }

            this.timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ReporteadorSegundoPlano_MouseHover(object sender, EventArgs e)
        {
            this.Opacity = 100;
        }

        private void ReporteadorSegundoPlano_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 90;
        }

        private void ReporteadorSegundoPlano_Load(object sender, EventArgs e)
        {
            this.is_shows = true;
        }
    }
}
