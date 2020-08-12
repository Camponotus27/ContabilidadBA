using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDetalle_Word_Press : Entidad
    {
        uint id_word_press;
        decimal stock_gral;
        decimal precio_base;
        decimal margen_base;

        public uint Id_word_press { get => id_word_press; set => id_word_press = value; }
        public decimal Stock_gral { get => stock_gral; set => stock_gral = value; }

        public int Id_word_press_int
        {
            get
            {
                return Formateador.ToInt32(id_word_press);
            }
        }

        public int Stock_gral_int
        {
            get
            {
                if (int.TryParse(Math.Round(this.stock_gral).ToString(), out int stock_general))
                {
                    return stock_general;
                }

                return 0;
            }
        }

        public decimal Precio_base { get => precio_base; set => precio_base = value; }
        public decimal Margen_base { get => margen_base; set => margen_base = value; }

        public bool ValidarSiEsAptoParaWordPress()
        {
            if (this.id_word_press == 0)
                return false;

            return true;
        }
    }
}
