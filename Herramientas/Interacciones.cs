using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herramientas
{
    public class Interacciones
    {
        public static void CenterMouseOverControl(Control ctl)
        {
            // See where to put the mouse.
            Point target = new Point(
                (ctl.Left + ctl.Right) / 2,
                (ctl.Top + ctl.Bottom) / 2);

            // Convert to screen coordinates.
            Point screen_coords = ctl.Parent.PointToScreen(target);

            Cursor.Position = screen_coords;
        }

        public static void Notificacion(string texto)
        {
            NotifyIcon n = new NotifyIcon();
            n.Icon = SystemIcons.Application;
            n.BalloonTipText = texto;
            n.BalloonTipTitle = "Notificacion";
            n.ShowBalloonTip(3000);
        }

        public static void Decimales(TextBox textBox, KeyPressEventArgs e, int cantDecimales)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int ubicacion_coma = 0;
            int nroDec = 0;

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if (textBox.Text[i] == ',')
                {
                    IsDec = true;
                    ubicacion_coma = i;
                }

                if (IsDec && nroDec++ >= cantDecimales)
                {
                    if (textBox.SelectionStart > ubicacion_coma)
                    {
                        e.Handled = true;
                        return;
                    }
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == ',')
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        public static void Decimales(TextBox textBox, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int ubicacion_coma = 0;
            int nroDec = 0;

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if (textBox.Text[i] == ',')
                {
                    IsDec = true;
                    ubicacion_coma = i;
                }


                if (IsDec && nroDec++ >= 4)
                {
                    if (textBox.SelectionStart > ubicacion_coma)
                    {
                        e.Handled = true;
                        return;
                    }
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == ',')
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Finalzia la aplicacion con un aviso, esta penada para Aplicacion Contable
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static object FinAPlicacionConAviso(string v)
        {
            Interacciones.MessajeBoxAviso("v");
            Interacciones.FinAplicacion();

            return null;
        }

        public static void AjustarPantallaADosContenedoresVerticalmente(Panel panel_superior, Panel  panel_inferior, int distancia_entre_el_flow_y_panel_inferior)
        {
            // form de los controles, deberia ser dos controles del mismo form
            Form form = panel_inferior.FindForm();

            // Se guardara el anchor para cambiarlo posteriormente, es solo preventivo
            AnchorStyles anchir_panel_inferior = panel_inferior.Anchor;

            // distancia en la parte inferior del panel superior y la parte superior del panel inferior, en resumen es la disancia entre un cuadrado y otro del lado mas proximo
            int distancia_entre_panel_superior_inferior = panel_inferior.Top - panel_superior.Bottom;
            int diferencia_deladistancia_que_es_con_la_que_deberia = distancia_entre_panel_superior_inferior - distancia_entre_el_flow_y_panel_inferior;

            panel_inferior.Anchor = AnchorStyles.Bottom;
            form.Size = new Size(form.Size.Width, form.Height - diferencia_deladistancia_que_es_con_la_que_deberia);

            panel_inferior.Anchor = anchir_panel_inferior;
        }

        public static void Pausa(int v)
        {
            Thread.Sleep(v);
        }

        public static void CenterMouseOverControl(Control ctl, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // See where to put the mouse.
                Point target = new Point(
                (ctl.Left + ctl.Right) / 2,
                (ctl.Top + ctl.Bottom) / 2);

                // Convert to screen coordinates.
                Point screen_coords = ctl.Parent.PointToScreen(target);

                Cursor.Position = screen_coords;
            }
                
        }

        public static void FinAplicacion()
        {
            Application.Exit();
        }

        public static void SiguienteControlPresEnter(Form form, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                Control control = form.GetNextControl(form.ActiveControl, true);

                while (form.SelectNextControl(form.ActiveControl, true, true, true, false));

                control.Focus();
                control.Select();
            }
        }

        public static void SiguienteControlPresEnter(Control control, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                control.Focus();
                control.Select();
            }
        }

        public static void SiguienteControlPresEnter(Form form)
        {
            Control control = form.GetNextControl(form.ActiveControl, true);

            control.Focus();
            control.Select();
        }

        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static decimal GetDecimalTxt(TextBox txt)
        {
            if (txt.Text == "" || txt.Text == null || txt.Text == String.Empty)
            {
                return 0m;
            }
            else
            {
                return Convert.ToDecimal(txt.Text);
            }
        }




        /// <summary>
        /// Decuelve un numero decimal de un textBox
        /// </summary>
        /// <param name="txt">Control TextBox</param>
        /// <param name="redondeo">Redondeo del valor obtenido</param>
        /// <returns></returns>
        public static decimal GetDecimalTxt(TextBox txt, int redondeo)
        {
            if (txt.Text == "" || txt.Text == null || txt.Text == String.Empty)
            {
                return 0m;
            }
            else
            {
                return Math.Round(Convert.ToDecimal(txt.Text), redondeo);
            }
        }

        public static void SeleccionarConClick(object sender)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        public static void MessajeBoxAviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        public static void MessajeBoxAviso(IWin32Window win32Window, string aviso)
        {
            MessageBox.Show(win32Window, aviso, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MessajeBoxInfo(IWin32Window win32Window, string mensaje)
        {
            MessageBox.Show(win32Window, mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MessajeBoxInfo(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Message(IWin32Window win32Window, Res res)
        {
            if (res.IsCorrecto)
            {

            }
            else
            {
                MessageBox.Show(win32Window, res.DescripcionError, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void Ex()
        {
            throw new Exception();
        }

        public static void Ex(string mensaje)
        {
            throw new Exception(mensaje);
        }

        public static void MessajeBoxAviso(Res respuesta)
        {
            if (!string.IsNullOrEmpty(respuesta.Mensaje))
                Interacciones.MessajeBoxAviso(respuesta.Mensaje);
        }

        
    }
}
