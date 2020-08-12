using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaGenerarPDF : Res
    {
        private string _urlPDF;

        public string UrlPDF { get => _urlPDF; set => _urlPDF = value; }
    }
}
