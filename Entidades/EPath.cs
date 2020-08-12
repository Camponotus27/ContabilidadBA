using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EPath
    {
        #region Carpeta
        public static string CarpetaCAF = @"CAFS";
        public static string CarpetaTimbres = @"Timbres";
        public static string CarpetaDTEFacturas = @"DTE\\Facturas";
        public static string CarpetaDTEBoletas = @"DTE\\Boletas";
        public static string CarpetaDTECotizaciones = @"DTE\\Cotizaciones";
        public static string CarpetaDTEFacturasFirmadas = @"DTE\\FacturasFirmadas";
        public static string CarpetaDTEBoletasFirmadas = @"DTE\\BoletasFirmadas";

        public static string CarpetaPDFFacturas = @"PDF\\Facturas";
        public static string CarpetaPDFBoletas = @"PDF\\Boletas";
        public static string CarpetaPDFCotizaciones = @"PDF\\Cotizaciones";

        public static string CarpetaPDFCompraFacturas = @"PDF\\Compras";

        public static string CarpetaTemporalGeneracionPDF = @"PDF\\TemporalCrearPDF";

        public static string CarpetaImagenesTemporales = @"Imagen\Temp\";

        /// <summary>
        /// Ojo esta carpeta debiera ser elimindada en cada uso
        /// </summary>
        public static string CarpetaTemporal = @"ArchivosTemp\";
        #endregion

        #region archivos
        public static string EnvioDTE = @"Documentos\\EnvioDte.Xml";
        public static string DTE_xsd = @"Schemas\\DTE_v10.xsd";
        public static string DTE_Sf_xsd = @"Schemas\\DTE_v10_Sf.xsd";
        public static string EnvioDTE_Sf_xsd = @"Schemas\\EnvioDTE_v10_Sf.xsd";
        public static string EnvioDTE_xsd = @"Schemas\\EnvioDTE_v10.xsd";

       /// <summary>
       /// Para los archicos DTE
       /// </summary>
        public static string Impresion_xsl = @"Recursos\\Impresion.xsl";
        public static string Impresion_compra_xsl = @"Recursos\\ImpresionCompra.xsl";
        public static string Impresion_cotizacion_xsl = @"Recursos\\ImpresionCotizacion.xsl";

        public static string ImpresionFacturaConGuias_xsl = @"Recursos\\ImpresionFacturaGuias.xsl";

        
        #endregion
    }
}
