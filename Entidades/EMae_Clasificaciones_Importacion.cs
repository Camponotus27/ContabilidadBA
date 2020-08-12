using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class EMae_Clasificaciones_Importacion : EMae_Clasificaciones
    {
        EstadoImportacion estado;
        int id_word_press_desde_word_press;

        public EstadoImportacion Estado { get => estado; set => estado = value; }
        /// <summary>
        /// Es el id que viene directamente desde la web, es para compararlo con el que ya esta guardado
        /// </summary>
        public int Id_word_press_desde_word_press { get => id_word_press_desde_word_press; set => id_word_press_desde_word_press = value; }
    }
}
