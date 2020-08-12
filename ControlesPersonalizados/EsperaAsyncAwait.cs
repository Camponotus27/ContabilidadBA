using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class EsperaAsyncAwait : Form
    {
        bool is_load = false;
        string action_realizar = string.Empty;

        public bool IsLoad { get => is_load; set => is_load = value; }

        public EsperaAsyncAwait(string action_realizar = "")
        {
            InitializeComponent();
            this.action_realizar = action_realizar;
        }

        private void EsperaAsyncAwait_Load(object sender, EventArgs e)
        {
            this.is_load = true;
            if (!string.IsNullOrEmpty(this.action_realizar))
            {
                this.txtMensaje.Text = action_realizar + "...";
            }
            
        }

        public void AñadirMensaje(string mensaje)
        {
            
            if (lbMensaje.InvokeRequired)
            {
                lbMensaje.Invoke(new MethodInvoker(delegate
                {
                    if (this.lbMensaje.Text != string.Empty)
                        mensaje = "\n" + mensaje;

                    this.lbMensaje.Text = this.lbMensaje.Text + mensaje;
                    this.Refresh();
                }));
            }
            else
            {
                if (this.lbMensaje.Text != string.Empty)
                    mensaje = "\n" + mensaje;

                this.lbMensaje.Text = this.lbMensaje.Text + mensaje;
                this.Refresh();
            }

            
        }

        public  void SetPadre(Control padre)
        {
            if (padre != null)
            {
                this.CenterToParent();
                //this.Location = new Point(padre.Location.X + padre.Width/2 - this.Width, padre.Location.Y + padre.Height/2 - this.Height);
            }
        }

        private void plMensaje_SizeChanged(object sender, EventArgs e)
        {

            HScrollProperties horizontal = this.plMensaje.HorizontalScroll;
            if(horizontal != null)
            {
                horizontal.Visible = false;
            }
            
            VScrollProperties vertical = this.plMensaje.VerticalScroll;

            if(vertical == null)
            {
                //vertical = new VScrollProperties(this.plMensaje);
            }
            else
            {
                //vertical.Minimum = 0;
                //vertical.Maximum = this.plMensaje.Size.Height;
                //vertical.Visible = true;
                //vertical.Value = vertical.Maximum;
            }

            
        }

        internal void InicializadorProgroso(int inicio, int final, string titulo)
        {

            if (this.pbPrincipal.InvokeRequired)
            {
                this.pbPrincipal.Invoke(new MethodInvoker(delegate
                {
                    this.pbPrincipal.Minimum = inicio;
                    this.pbPrincipal.Maximum = final;
                    //this.pbPrincipal.Value = inicio;

                    this.ActualizarLabel();

                    this.plProgreso.Visible = true;

                    this.pbPrincipal.Refresh();
                }));
            }
            else
            {
                this.pbPrincipal.Minimum = inicio;
                this.pbPrincipal.Maximum = final;
                this.pbPrincipal.Value = 0;

                this.ActualizarLabel();

                this.plProgreso.Visible = true;
                this.pbPrincipal.Refresh();
            }

            
        }

        private void ActualizarLabel()
        {
            this.lbProgreso.Text = this.pbPrincipal.Value + " / " + this.pbPrincipal.Maximum;
            this.lbProgreso.Refresh();
        }

        internal void NotificarProgreso()
        {

            if (this.pbPrincipal.InvokeRequired)
            {
                this.pbPrincipal.Invoke(new MethodInvoker(delegate
                {
                    if (this.pbPrincipal.Value + 1 < this.pbPrincipal.Maximum)
                    {
                        this.pbPrincipal.Value++;
                        this.ActualizarLabel();
                        this.pbPrincipal.Refresh();
                    }
                }));
            }
            else
            {
                if (this.pbPrincipal.Value + 1 < this.pbPrincipal.Maximum)
                {
                    this.pbPrincipal.Value++;
                    this.ActualizarLabel();
                    this.pbPrincipal.Refresh();
                }
            }

           
        }
    }
}
