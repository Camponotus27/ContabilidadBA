using Herramientas;
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
    public enum Estados
    {
        INICIADO,
        CARGANDO,
        TERMINADO
    }

    public partial class EsperaAsyncAwait : Form
    {
        private Estados estado = Estados.INICIADO;
        string action_realizar = string.Empty;
        string texto_terminado = "Completado";

        public EsperaAsyncAwait(string action_realizar = "")
        {
            InitializeComponent();
            this.action_realizar = action_realizar;
        }

        private void EsperaAsyncAwait_Load(object sender, EventArgs e)
        {
            this.estado = Estados.CARGANDO;

            if (!string.IsNullOrEmpty(this.action_realizar))
            {
                this.lbMensajeSuperior.Text = action_realizar + "...";
            }
        }

        public void AñadirMensaje(string mensaje, bool salto_linea = true)
        {
            
            if (lbMensaje.InvokeRequired)
            {
                lbMensaje.Invoke(new MethodInvoker(delegate
                {
                    if (this.lbMensaje.Text != string.Empty && salto_linea)
                        mensaje = "\r\n" + mensaje;

                    if (!salto_linea)
                        mensaje = " " + mensaje;

                    this.lbMensaje.AppendText(mensaje);
                }));
            }
            else
            {
                if (this.lbMensaje.Text != string.Empty && salto_linea) 
                    mensaje = "\r\n" + mensaje;

                if (!salto_linea)
                    mensaje = " " + mensaje;

                this.lbMensaje.AppendText(mensaje);
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

        private void btnVerRegistro_Click(object sender, EventArgs e)
        {
            LogWriter logWriter = new LogWriter();
            logWriter.AbrirLog();
        }

        public void Cargado()
        {
            this.CrearLog();

            this.estado = Estados.TERMINADO;

            this.lbMensajeSuperior.Text = this.texto_terminado;
            this.pbCargando.Image = this.il.Images[0];



            this.AñadirBotonAceptar();
        }

        private void CrearLog()
        {
            if(this.estado != Estados.TERMINADO)
            {
                string log = this.lbMensajeSuperior.Text;
                log = log + "\r\n" + this.lbMensaje.Text;

                new LogWriter(log);
            }
        }

        private void AñadirBotonAceptar()
        {
            ButtonPitagoras btnAceptar = new ButtonPitagoras();
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += (sender, e) =>
            {
                this.Close();
            };

            this.flp.Controls.Add(btnAceptar);

            btnAceptar.Location = new Point(this.flp.Size.Width - btnAceptar.Size.Width - 3, btnAceptar.Location.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(Color.FromArgb(210, 210, 210), Parametros.anchoBorde), 0, 0, Width - 0, Height - 0);
        }

        private void EsperaAsyncAwait_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CrearLog();
        }
    }
}
