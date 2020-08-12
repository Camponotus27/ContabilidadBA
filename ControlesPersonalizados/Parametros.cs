using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlesPersonalizados
{
    // http://pildorasdotnet.blogspot.com/2015/04/datagridview-columna-solo-numeros.html
    // http://pildorasdotnet.blogspot.com/2015/04/datagridview-columna-fechas.html
    // http://pildorasdotnet.blogspot.com/2015/11/datagridview-columna-numeros-decimales.html

    public class Parametros
    {
        #region Carpeta Date

        public static readonly DateTime FechaNula = Herramientas.Parametros.FechaNula;

        #endregion


        #region Espesificos

        public static readonly Color ColorPictureBoxControl = Color.Orange;

        #endregion

        #region Generales

        public static int anchoBorde = 4;
        public static Color colorBorde = Color.Navy;
        #endregion
    }
}
