using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herramientas
{
    public class Combo
    {
        /// <summary>
        /// Asigna un diccionario a un combo, devuelve si el dicionario esta vacio
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static bool AsingDic(ComboBox cmb, Dictionary<string, string> dic)
        {
            if(dic == null || dic.Count == 0)
            {
                return false;
            }

            cmb.DataSource = new BindingSource(dic, null);
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Key";

            return true;
        }

        public static KeyValuePair<string, string> getSS(ComboBox cmb)
        {
            return (KeyValuePair<string, string>)cmb.SelectedItem;
        }

        public static void CargarAños(ComboBox cmbAño)
        {
            int AñoInicio = 2017;

            int AñoTermino = DateTime.Now.Year;

            for (int i = AñoInicio; i <= AñoTermino; i++)
            {
                cmbAño.Items.Add(i);
            }

            if (cmbAño.Items.Count == 0)
            {
                throw new Exception("No se pudo cargar el año");
            }

            SelecionarAñoMayor(cmbAño);
        }

        private static void SelecionarAñoMayor(ComboBox cmbAño)
        {
            try
            {
                cmbAño.SelectedIndex = cmbAño.Items.Count - 1;
            }
            catch (Exception ex)
            {
                Interacciones.MessajeBoxAviso("No se puedo selecionar el año actual: " + ex.Message);
            }
        }
    }
}
