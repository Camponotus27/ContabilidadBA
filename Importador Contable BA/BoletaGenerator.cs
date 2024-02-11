using iText.Html2pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importador_Contable_BA
{
    public class BoletaGenerator
    {
        public string ReadTemplate(string path)
        {
            return File.ReadAllText(path);
        }

        public string ReplaceVariables(string template, string numeroComprobante, string fecha,
                                       string nombreCliente, string detallePago, string numeroParcela,
                                       string itemsHtml, string total, string montoLetras)
        {
            return template.Replace("{{numero_comprobante}}", numeroComprobante)
                           .Replace("{{fecha}}", fecha)
                           .Replace("{{nombre_cliente}}", nombreCliente)
                           .Replace("{{detalle_pago}}", detallePago)
                           .Replace("{{numero_parcela}}", numeroParcela)
                           .Replace("{{items}}", itemsHtml)
                           .Replace("{{total}}", total)
                           .Replace("{{monto_letras}}", montoLetras);
        }

        public void GeneratePDF(string html, string outputPath)
        {
            HtmlConverter.ConvertToPdf(html, new FileStream(outputPath, FileMode.Create));
        }
    }
}
