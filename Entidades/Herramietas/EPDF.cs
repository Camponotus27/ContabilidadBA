using Herramientas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using Winnovative;

namespace Entidades.Herramietas
{
    public class EPDF
    {
        public EPDF()
        {

        }


        /// <summary>
        /// Genera documento Pdf Cedible
        /// </summary>
        public static Res GenerarDocumentoPdfDteC(string uriXMLFirmado, string uriDestinoPDF, string uriPngOrigen, string numero_anio_res, string glosa, EDTE_Transportistas transportista)
        {
            /// direccion del xsl
            string UrlXSL = EPath.Impresion_xsl;

            ////
            //// Iniciar el retorno de valor
            Res res = new Res();

            ////
            //// Iniciar el proceso de generación
            try
            {
                ObtenerUris(out string uriHtml, out string uriPng, uriPngOrigen, uriXMLFirmado);

                Dictionary<string, string> parametros = new Dictionary<string, string>()
                {
                    ["SIIDireccionRegional"] = ObtencionSucursalSII(),
                    ["numero_anio_res"] = numero_anio_res,
                    ["glosa"] = ((string.IsNullOrEmpty(glosa)? "SIN GLOSA": glosa)),
                    ["transportista"] = ((transportista == null)? "SIN DATOS" : transportista.ConjuntoImpresionXSL()),
                    ["transportista_fecha"] = ((transportista == null) ? "NO INDICADA" : Formateador.DateToTextMostrar(transportista.Fecha_despacho)),              
                };

                CopiarPngADondeSeUtilizara(uriPngOrigen, uriPng);

                GenerarHTML(UrlXSL, uriHtml, uriXMLFirmado, parametros);

                GenerarPDF(uriDestinoPDF, uriHtml);

                EliminarCarpetaTemporal();
                
                res.Correcto();

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);
            }

            return res;

        }

        public static Res GenerarDocumentoPdfCotizacion(string uriXML, string uriPDF)
        {
            /// direccion del xsl
            string UrlXSL = EPath.Impresion_compra_xsl;

            ////
            //// Iniciar el retorno de valor
            Res res = new Res();

            ////
            //// Iniciar el proceso de generación
            try
            {
                ObtenerUrisMismaCarpeta(out string uriHtml, uriXML);

                GenerarHTML(UrlXSL, uriHtml, uriXML);

                GenerarPDF(uriPDF, uriHtml);

                ManejoArchivos.EliminarArchivoSiExiste(uriHtml);
                ManejoArchivos.EliminarArchivoSiExiste(uriXML);

                res.Correcto();

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);
            }

            return res;
        }

        public static Res GenerarDocumentoPdfCompra(string url_xml_temporal, string url_pdf)
        {
            /// direccion del xsl
            string UrlXSL = EPath.Impresion_compra_xsl;

            ////
            //// Iniciar el retorno de valor
            Res res = new Res();

            ////
            //// Iniciar el proceso de generación
            try
            {
                ObtenerUrisMismaCarpeta(out string uriHtml, url_xml_temporal);

                GenerarHTML(UrlXSL, uriHtml, url_xml_temporal);

                GenerarPDF(url_pdf, uriHtml);

                ManejoArchivos.EliminarArchivoSiExiste(uriHtml);
                ManejoArchivos.EliminarArchivoSiExiste(url_xml_temporal);

                res.Correcto();

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);
            }

            return res;
        }

        public static Res GenerarDocumentoPdfDteEspecialFacturaGuias(string uriXMLFirmado, string uriDestinoPDF, string uriPngOrigen)
        {

            /// direccion del xsl
            string UrlXSL = EPath.ImpresionFacturaConGuias_xsl;

            //// Iniciar el retorno de valor
            Res res = new Res();

            ////
            //// Iniciar el proceso de generación
            try
            {
                ObtenerUris(out string uriHtml, out string uriPng, uriPngOrigen, uriXMLFirmado);

                Dictionary<string, string> parametros = new Dictionary<string, string>()
                {
                    ["SIIDireccionRegional"] = ObtencionSucursalSII(),
                    //["esCedible"] = "True"
                };

                CopiarPngADondeSeUtilizara(uriPngOrigen, uriPng);

                GenerarHTML(UrlXSL, uriHtml, uriXMLFirmado, parametros);

                GenerarPDF(uriDestinoPDF, uriHtml);

                EliminarCarpetaTemporal();

                res.Correcto();

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);
            }

            return res;
        }

        private static void EliminarCarpetaTemporal()
        {
            Directory.Delete(EPath.CarpetaTemporalGeneracionPDF, true);
        }

        private static void CopiarPngADondeSeUtilizara(string uriPngOrigen, string uriPng)
        {
            ManejoArchivos.Copiar(uriPngOrigen, uriPng);
        }

        private static void ObtenerUris(out string uriHtml, out string uriPng, string uriPngOrigen, string uri_XML)
        {

            /// se obtiene la url de la carpeta temporal
            string path_temporal = EPath.CarpetaTemporalGeneracionPDF;

            /// valicacion si esta vacia la cadena de la url
            if (string.IsNullOrEmpty(path_temporal))
                Interacciones.Ex("No se encontro la url temporal para crear pdf");

            // se obtiene el nombre del xml firmado
            string nombre_xml = Path.GetFileName(uri_XML);

            string url_dentro_carpeta = Path.Combine(path_temporal, nombre_xml);

            // con la cadena creada anteriormente se crean las dos direcciones temporales con las extenciones Html y Png
            uriHtml = Path.ChangeExtension(url_dentro_carpeta, ".Html");
            uriPng = Path.Combine(path_temporal, Path.GetFileName(uriPngOrigen));

        }

        private static void ObtenerUrisMismaCarpeta(out string uriHtml, string uri_XML)
        {
            // con la cadena creada anteriormente se crean las dos direcciones temporales con las extenciones Html y Png
            uriHtml = Path.ChangeExtension(uri_XML, ".Html");

        }

        private static void ObtenerUris(out string uriHtml, string uriXMLFirmado)
        {
            string url_dentro_carpeta = ObtenerUrlArchivosTemporalesDentroCarpeta(uriXMLFirmado);

            // con la cadena creada anteriormente se crean las dos direcciones temporales con las extenciones Html y Png
            uriHtml = Path.ChangeExtension(url_dentro_carpeta, ".Html");

        }

        private static string ObtenerUrlArchivosTemporalesDentroCarpeta(string uriXMLFirmado)
        {
            /// se obtiene la url de la carpeta temporal
            string path_temporal = EPath.CarpetaTemporalGeneracionPDF;

            /// valicacion si esta vacia la cadena de la url
            if (string.IsNullOrEmpty(path_temporal))
                Interacciones.Ex("No se encontro la url temporal para crear pdf");

            // se obtiene el nombre del xml firmado
            string nombre_xml = Path.GetFileName(uriXMLFirmado);

            // con el nombre y la carpeta se crea un url dentro de la carpeta temporal, este deberia tener extencion .xml
            return Path.Combine(path_temporal, nombre_xml);
        }

        private static void GenerarPDF(string uriDestinoPDF, string uriHtml)
        {

            ////
            //// Crear el converto de gtml a pdf
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
            htmlToPdfConverter.LicenseKey = "oy0+LD0sOz45LD09IjwsPz0iPT4iNTU1NQ==";
            htmlToPdfConverter.HtmlViewerWidth = 1024;
            htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
            htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
            htmlToPdfConverter.NavigationTimeout = 60;

            ////
            //// Cree la fullpath del documento
            byte[] arrPdf = htmlToPdfConverter.ConvertHtmlFile(Path.Combine(Formateador.RootPath(), uriHtml));

            ManejoArchivos.CrearCarpetaSiNoExiste(uriDestinoPDF, false);
            ManejoArchivos.EliminarArchivoSiExiste(uriDestinoPDF);

            ////
            //// Guarde el documento en disco
            File.WriteAllBytes(uriDestinoPDF, arrPdf);
        }

        private static string ObtencionSucursalSII()
        {
            string sucursal = Sesion.MiSesion.Empresa.Sii.Sucursal;

            if (string.IsNullOrEmpty(sucursal))
                Interacciones.Ex("Se necesita la sucursal del Sii y no esta en la sesion");

            return "S.I.I. - " + sucursal;
        }

        private static void GenerarHTML(string url_XSL, string uri_html, string uri_xml, Dictionary<string, string> parametros = null)
        {

            if (parametros == null)
                parametros = new Dictionary<string, string>();

            ////
            //// Setee la lectura del documento xslt para aceptar secuencias javascript
            //// solo si en el futuro son necesarias
            XsltSettings settings = new XsltSettings();
            settings.EnableScript = true;
            settings.EnableDocumentFunction = true;

            ////
            //// Setear la salida del documento
            XmlWriterSettings xwsettings = new XmlWriterSettings();
            xwsettings.Indent = true;
            xwsettings.Encoding = Encoding.GetEncoding("ISO-8859-1");

            ////
            //// Cree los parametros necesarios para la transformacion
            XsltArgumentList xslParametros = new XsltArgumentList();
            
            foreach(KeyValuePair<string, string> keyValuePair in parametros)
            {
                xslParametros.AddParam(keyValuePair.Key, "", keyValuePair.Value);
            }

            ////
            //// Iniciar la transformación del documento xml a html
            xwsettings.Encoding = Encoding.GetEncoding("utf-8");
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(url_XSL, settings, new XmlUrlResolver());
            using (XmlWriter xw = XmlWriter.Create(uri_html, xwsettings))
            {
                ////
                //// Realice la transformacion de los documentos
                //// y depositelo en la carpeta out
                xslt.Transform(uri_xml, xslParametros, xw);
            }
        }



        internal static Res GenerarDocumentoPdfPagoProveedores(string uriXML, string v1, string v2)
        {
            ////
            //// Iniciar el retorno de valor
            string MiNombreArchivo = string.Empty;
            Res res = new Res();

            ////
            //// Donde debemos dejar el archivo html
            string uriHtml = Path.ChangeExtension(uriXML, ".Html");
            string uriPdfT = Path.ChangeExtension(uriXML, ".Pdf");

            if (File.Exists(uriPdfT))
                res.Error("El pdf ya estaba creado");

            ////
            //// Iniciar el proceso de generación
            try
            {
                string UrlXSL = @"Recursos\ImpresionPagoProveedores.xsl";


                #region GENERAR DOCUMENTO HTML

                ////
                //// Setee la lectura del documento xslt para aceptar secuencias javascript
                //// solo si en el futuro son necesarias
                XsltSettings settings = new XsltSettings();
                settings.EnableScript = true;
                settings.EnableDocumentFunction = true;

                ////
                //// Setear la salida del documento
                XmlWriterSettings xwsettings = new XmlWriterSettings();
                xwsettings.Indent = true;
                xwsettings.Encoding = Encoding.GetEncoding("ISO-8859-1");

                ////
                //// Cree los parametros necesarios para la transformacion
                XsltArgumentList xslParametros = new XsltArgumentList();
                //xslParametros.AddParam("esCedible", "", "True");

                ////
                //// Iniciar la transformación del documento xml a html
                xwsettings.Encoding = Encoding.GetEncoding("utf-8");
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(UrlXSL, settings, new XmlUrlResolver());
                using (XmlWriter xw = XmlWriter.Create(uriHtml, xwsettings))
                {
                    ////
                    //// Realice la transformacion de los documentos
                    //// y depositelo en la carpeta out
                    xslt.Transform(uriXML, xslParametros, xw);
                }

                #endregion

                #region GENERAR DOCUMENTO PDF

                ////
                //// Crear el converto de gtml a pdf
                HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
                htmlToPdfConverter.LicenseKey = "oy0+LD0sOz45LD09IjwsPz0iPT4iNTU1NQ==";
                htmlToPdfConverter.HtmlViewerWidth = 1024;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                htmlToPdfConverter.NavigationTimeout = 60;

                ////
                //// Cree la fullpath del documento
                byte[] arrPdf = htmlToPdfConverter.ConvertHtmlFile(uriHtml);


                ////
                //// Guarde el documento en disco
                File.WriteAllBytes(uriPdfT, arrPdf);
                MiNombreArchivo = uriPdfT;

                #endregion

                #region LIMPIAR ELEMENTOS DEL PROCESO

                if (File.Exists(uriHtml))
                    File.Delete(uriHtml);

                if (File.Exists(uriXML))
                    File.Delete(uriXML);


                #endregion

                ////
                //// Se completo el proceso
                res.Correcto();
                res.Respuesta = uriPdfT;

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);

                ////
                //// Cree el elemento error
                new LogWriter(ex.Message);

            }


            return res;
        }

        public static Res GenerarDocumentoPdfSolMercaderia(string uriXML, string v, string nombre_sucursal)
        {
            ////
            //// Iniciar el retorno de valor
            string MiNombreArchivo = string.Empty;
            Res res = new Res();

            ////
            //// Donde debemos dejar el archivo html
            string uriHtml = Path.ChangeExtension(uriXML, ".Html");
            string uriPdfT = Path.ChangeExtension(uriXML, ".Pdf");

            ////
            //// Iniciar el proceso de generación
            try
            {
                string UrlXSL = @"Recursos\ImpresionSolMercaderia.xsl";

                #region GENERAR DOCUMENTO HTML

                ////
                //// Setee la lectura del documento xslt para aceptar secuencias javascript
                //// solo si en el futuro son necesarias
                XsltSettings settings = new XsltSettings();
                settings.EnableScript = true;
                settings.EnableDocumentFunction = true;

                ////
                //// Setear la salida del documento
                XmlWriterSettings xwsettings = new XmlWriterSettings();
                xwsettings.Indent = true;
                xwsettings.Encoding = Encoding.GetEncoding("ISO-8859-1");

                ////
                //// Cree los parametros necesarios para la transformacion
                XsltArgumentList xslParametros = new XsltArgumentList();
                //xslParametros.AddParam("esCedible", "", "True");

                ////
                //// Iniciar la transformación del documento xml a html
                xwsettings.Encoding = Encoding.GetEncoding("utf-8");
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(UrlXSL, settings, new XmlUrlResolver());
                using (XmlWriter xw = XmlWriter.Create(uriHtml, xwsettings))
                {
                    ////
                    //// Realice la transformacion de los documentos
                    //// y depositelo en la carpeta out
                    xslt.Transform(uriXML, xslParametros, xw);
                }

                #endregion

                #region GENERAR DOCUMENTO PDF

                ////
                //// Crear el converto de gtml a pdf
                HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
                htmlToPdfConverter.LicenseKey = "oy0+LD0sOz45LD09IjwsPz0iPT4iNTU1NQ==";
                htmlToPdfConverter.HtmlViewerWidth = 1024;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                htmlToPdfConverter.NavigationTimeout = 60;

                ////
                //// Cree la fullpath del documento
                byte[] arrPdf = htmlToPdfConverter.ConvertHtmlFile(uriHtml);


                ////
                //// Guarde el documento en disco
                File.WriteAllBytes(uriPdfT, arrPdf);
                MiNombreArchivo = uriPdfT;

                #endregion

                #region LIMPIAR ELEMENTOS DEL PROCESO

                if (File.Exists(uriHtml))
                    File.Delete(uriHtml);

                if (File.Exists(uriXML))
                    File.Delete(uriXML);


                #endregion

                ////
                //// Se completo el proceso
                res.Correcto();
                res.Respuesta = uriPdfT;

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);

                ////
                //// Cree el elemento error
                new LogWriter(ex.Message);

            }


            return res;
        }

        public static Res GenerarDocumentoPdfCotizacion(string uriXML, string sFolio, string sRutReceptor)
        {

            ////
            //// Iniciar el retorno de valor
            string MiNombreArchivo = string.Empty;
            Res res = new Res();

            ////
            //// Donde debemos dejar el archivo html
            string uriHtml = Path.ChangeExtension(uriXML, ".Html");
            string uriPdfT = Path.ChangeExtension(uriXML, ".Pdf");

            ////
            //// Iniciar el proceso de generación
            try
            {
                string UrlXSL = @"Recursos\ImpresionCotizacion.xsl";
                /*
                if (sTipoDTE == "39")
                    Parametros = @"Recursos\Impresion_boleta.xsl";
                else
                {
                    Parametros = @"Recursos\Impresion.xsl";
                }*/

                #region GENERAR DOCUMENTO HTML

                ////
                //// Setee la lectura del documento xslt para aceptar secuencias javascript
                //// solo si en el futuro son necesarias
                XsltSettings settings = new XsltSettings();
                settings.EnableScript = true;
                settings.EnableDocumentFunction = true;

                ////
                //// Setear la salida del documento
                XmlWriterSettings xwsettings = new XmlWriterSettings();
                xwsettings.Indent = true;
                xwsettings.Encoding = Encoding.GetEncoding("ISO-8859-1");

                ////
                //// Cree los parametros necesarios para la transformacion
                XsltArgumentList xslParametros = new XsltArgumentList();
                //xslParametros.AddParam("esCedible", "", "True");

                ////
                //// Iniciar la transformación del documento xml a html
                xwsettings.Encoding = Encoding.GetEncoding("utf-8");
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(UrlXSL, settings, new XmlUrlResolver());
                using (XmlWriter xw = XmlWriter.Create(uriHtml, xwsettings))
                {
                    ////
                    //// Realice la transformacion de los documentos
                    //// y depositelo en la carpeta out
                    xslt.Transform(uriXML, xslParametros, xw);
                }

                #endregion

                #region GENERAR DOCUMENTO PDF

                ////
                //// Crear el converto de gtml a pdf
                HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
                htmlToPdfConverter.LicenseKey = "oy0+LD0sOz45LD09IjwsPz0iPT4iNTU1NQ==";
                htmlToPdfConverter.HtmlViewerWidth = 1024;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                htmlToPdfConverter.NavigationTimeout = 60;

                ////
                //// Cree la fullpath del documento
                byte[] arrPdf = htmlToPdfConverter.ConvertHtmlFile(uriHtml);


                ////
                //// Guarde el documento en disco
                File.WriteAllBytes(uriPdfT, arrPdf);
                MiNombreArchivo = uriPdfT;

                #endregion

                #region LIMPIAR ELEMENTOS DEL PROCESO

                if (File.Exists(uriHtml))
                    File.Delete(uriHtml);

                if (File.Exists(uriXML))
                    File.Delete(uriXML);


                #endregion

                ////
                //// Se completo el proceso
                res.Correcto();
                res.Respuesta = uriPdfT;

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);

                ////
                //// Cree el elemento error
                new LogWriter(ex.Message);

            }


            return res;
        }

        internal static Res GenerarDocumentoPdfCompra(string uriXML, string v1, string v2)
        {
            ////
            //// Iniciar el retorno de valor
            string MiNombreArchivo = string.Empty;
            Res res = new Res();

            ////
            //// Donde debemos dejar el archivo html
            string uriHtml = Path.ChangeExtension(uriXML, ".Html");
            string uriPdfT = Path.ChangeExtension(uriXML, ".Pdf");

            ////
            //// Iniciar el proceso de generación
            try
            {
                string UrlXSL = @"Recursos\ImpresionCompra.xsl";


                #region GENERAR DOCUMENTO HTML

                ////
                //// Setee la lectura del documento xslt para aceptar secuencias javascript
                //// solo si en el futuro son necesarias
                XsltSettings settings = new XsltSettings();
                settings.EnableScript = true;
                settings.EnableDocumentFunction = true;

                ////
                //// Setear la salida del documento
                XmlWriterSettings xwsettings = new XmlWriterSettings();
                xwsettings.Indent = true;
                xwsettings.Encoding = Encoding.GetEncoding("ISO-8859-1");

                ////
                //// Cree los parametros necesarios para la transformacion
                XsltArgumentList xslParametros = new XsltArgumentList();
                //xslParametros.AddParam("esCedible", "", "True");

                ////
                //// Iniciar la transformación del documento xml a html
                xwsettings.Encoding = Encoding.GetEncoding("utf-8");
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(UrlXSL, settings, new XmlUrlResolver());
                using (XmlWriter xw = XmlWriter.Create(uriHtml, xwsettings))
                {
                    ////
                    //// Realice la transformacion de los documentos
                    //// y depositelo en la carpeta out
                    xslt.Transform(uriXML, xslParametros, xw);
                }

                #endregion

                #region GENERAR DOCUMENTO PDF

                ////
                //// Crear el converto de gtml a pdf
                HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
                htmlToPdfConverter.LicenseKey = "oy0+LD0sOz45LD09IjwsPz0iPT4iNTU1NQ==";
                htmlToPdfConverter.HtmlViewerWidth = 1024;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                htmlToPdfConverter.NavigationTimeout = 60;

                ////
                //// Cree la fullpath del documento
                byte[] arrPdf = htmlToPdfConverter.ConvertHtmlFile(uriHtml);


                ////
                //// Guarde el documento en disco
                File.WriteAllBytes(uriPdfT, arrPdf);
                MiNombreArchivo = uriPdfT;

                #endregion

                #region LIMPIAR ELEMENTOS DEL PROCESO

                if (File.Exists(uriHtml))
                    File.Delete(uriHtml);

                if (File.Exists(uriXML))
                    File.Delete(uriXML);


                #endregion

                ////
                //// Se completo el proceso
                res.Correcto();
                res.Respuesta = uriPdfT;

            }
            catch (Exception ex)
            {
                ////
                //// Regrese el valor de retorno
                res.Error(ex.Message);

                ////
                //// Cree el elemento error
                new LogWriter(ex.Message);

            }


            return res;
        }
    }
}
