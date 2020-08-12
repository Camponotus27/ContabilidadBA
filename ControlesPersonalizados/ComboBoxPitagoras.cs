using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class ComboBoxPitagoras : ComboBox
    {

        public ComboBoxPitagoras()
        {
            InitializeComponent();
        }

        public uint Value{
            get
            {
                if (this.SelectedItem == null)
                    return 0;

                KeyValuePair<string, string> seleccion = (KeyValuePair<string, string>)this.SelectedItem;
                return Formateador.ToUInt32(seleccion.Key);
            }
            
            set
            {
                string value_str = value.ToString();

                try
                {
                    this.SelectedValue = value_str;
                }catch(Exception ex)
                {
                    Interacciones.MessajeBoxAviso("No se pudo asignar el combo: " + ex.Message);
                }
            }
        }
        private bool es_Buscador = false;
        private bool buscador_deja_avanzar = false;


        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            object frm_ob = this.FindForm();

            Type tipo = frm_ob.GetType().BaseType;

            if (tipo == typeof(FormPitagoras))
            {
                FormPitagoras frmP = (FormPitagoras)frm_ob;

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (!this.es_Buscador || this.buscador_deja_avanzar)
                    {
                        this.buscador_deja_avanzar = false;
                        frmP.Flujo.SiguienteControl();
                    }
                }
            }
        }


     
    }
}
