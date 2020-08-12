using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Productos_DTE_Importacion : EMae_Productos_DTE
    {
        EstadoImportacion estado;
        public EstadoImportacion Estado { get => estado; set => estado = value; }

        public bool ValidarSiEsAptoParaWordPress(out string error_validacion, bool creando = false)
        {
            error_validacion = string.Empty;

            if (creando && this.Id_word_press == 0)
            {
                error_validacion = "No esta el id de word press";
                return false;
            }

            if (this.Id_clasificacion_word_press == 0)
            {
                error_validacion = "No esta el id de la clasificacion de word press";
                return false;
            }

            return true;
        }
    }
}
