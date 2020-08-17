using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.ControlesFrecuentes
{
    public partial class CMSTextBoxTexto : ToolStripTextBox
    {
        public CMSTextBoxTexto()
        {
            InitializeComponent();
        }

        private bool seleccionaTodoConClick = true;
        private bool seleccionoTodoPorLoMenosUnaVez = false;
        private bool es_Buscador = false;
        private bool buscador_deja_avanzar = false;


        public bool EsBuscador { get => es_Buscador; set => es_Buscador = value; }
        /// <summary>
        /// Si esta activado seleccionara todo el contenido del textBox al Entrar en el 
        /// </summary>
        public bool SeleccionaTodoConClick { get => seleccionaTodoConClick; set => seleccionaTodoConClick = value; }

        #region Metodos
        public void BusquedaCorrecta()
        {
            this.buscador_deja_avanzar = true;
        }
        public void DejarAvanzarSiguiente()
        {
            this.buscador_deja_avanzar = true;
        }
        #endregion

        #region Eventos
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.seleccionaTodoConClick && !this.seleccionoTodoPorLoMenosUnaVez)
            {
                this.SelectAll();
                this.seleccionoTodoPorLoMenosUnaVez = true;
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            this.seleccionoTodoPorLoMenosUnaVez = false;
            base.OnLeave(e);
        }
        #endregion
    }
}
