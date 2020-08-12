using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;

namespace ControlesPersonalizados
{
    /// <summary>
    /// Es una barra para navegar entre los datos de un data Binding.
    /// Pra su funcionamiento se debe asginar el Binding en las propiedades y siempre que sea posible un DataGrid
    /// </summary>
    public partial class BindingNavigatorPitagoras : UserControl
    {
        BindingSource binding;
        DataGridView dataGridView;
        bool permitirAgregar = false;

        public BindingNavigatorPitagoras()
        {
            InitializeComponent();
        }

        [
            TypeConverter(typeof(BindingSource)),
            Description("Binging hacia los datos que este control manejara"),
            Category("Datos")
        ]
        public BindingSource Binding { get => binding; set => binding = value; }

        [
            TypeConverter(typeof(BindingSource)),
            Description("Solo si esta opcion esta activada se puede agregar datos, se usa para que no permita añadir datos cuando no esta el padre EJ: solo cuando hay un producto cargado se podran añadir codigos de barra a el"),
            Category("Datos")
        ]
        public bool PermitirAgregar { get => permitirAgregar; set => permitirAgregar = value; }

        [
            TypeConverter(typeof(DataGridView)),
            Description("Grid conectada al navegador"),
            Category("Datos")
        ]
        public DataGridView DataGridView { get => dataGridView; set => dataGridView = value; }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.binding == null)
            {
                Interacciones.MessajeBoxAviso("Binding vacio");
                return;
            }

            if(permitirAgregar)
            {
                this.binding.AddNew();
                if (this.DataGridView != null)
                    this.DataGridView.Focus();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.binding == null)
            {
                Interacciones.MessajeBoxAviso("Binding vacio");
                return;
            }

            object current = this.binding.Current;
            if(current != null)
            {
                this.binding.RemoveCurrent();
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (this.binding == null)
            {
                Interacciones.MessajeBoxAviso("Binding vacio");
                return;
            }

            this.binding.MovePrevious();
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if (this.binding == null)
            {
                Interacciones.MessajeBoxAviso("Binding vacio");
                return;
            }

            this.binding.MoveNext();
        }
    }
}
