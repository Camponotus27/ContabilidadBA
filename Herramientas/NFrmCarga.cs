using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public partial class NFrmCarga : Form
    {
        bool formulario_cerrado = true;

        public NFrmCarga()
        {
            this.InicializarForm();
        }

        public NFrmCarga(int maximo)
        {
            this.InicializarForm();

            this.progress.Maximum = maximo;
        }

        public NFrmCarga(int minimo, int maximo)
        {
            this.InicializarForm();

            this.Min = minimo;
            this.progress.Maximum = maximo;
        }

        private void InicializarForm()
        {
            if (this.progress == null)
                this.progress = new ProgressBar();
            this.progress.Minimum = 0;
            this.progress.Maximum = 100;
            this.progress.Value = 0;
            InitializeComponent();
        }

        public int Min { get => this.progress.Minimum;
            set
            {
                this.progress.Minimum = value;
            }
        }
        public int Max { get => this.progress.Maximum;
            set {
                this.progress.Maximum = value;
            }
        }

        public int Progreso { get => this.progress.Value;
            set
            {
                this.progress.Value = value;
            }
        }

        public void ReportarProgreso(int progreso)
        {
            this.Progreso = progreso;
            this.Refresh();

            if(!this.formulario_cerrado && this.Progreso >= this.Max)
            {
                this.Close();
            }
        }

        private void NFrmCarga_Load(object sender, EventArgs e)
        {
            this.formulario_cerrado = false;
        }

        private void NFrmCarga_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.formulario_cerrado = true;
        }
    }
}
