using Herramientas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Entidades
{
    public class EMae_Caf : Entidad
    {
        uint id;
        uint id_emp;
        DateTime? fecha_generacion;
        private string fecha_generacion_texto;
        Ambiente ambiente = Ambiente.CERTIFICACION;
        string rut_emisor;
        uint tipo_tde;
        DateTime? fecha_asignacion;
        string fecha_asignacion_texto;
        uint desde;
        uint hasta;
        string firma;
        string nombre;
        byte[] xml;
        Int64 size;
        private string url;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public DateTime? Fecha_generacion { get => fecha_generacion; set => fecha_generacion = value; }
        public Ambiente Ambiente { get => ambiente; set => ambiente = value; }
        public string Rut_emisor { get => rut_emisor; set => rut_emisor = value; }
        public uint Tipo_tde { get => tipo_tde; set => tipo_tde = value; }
        public DateTime? Fecha_asignacion { get => fecha_asignacion; set => fecha_asignacion = value; }
        public uint Desde { get => desde; set => desde = value; }
        public uint Hasta { get => hasta; set => hasta = value; }
        public string Firma { get => firma; set => firma = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public byte[] Xml { get => xml; set => xml = value; }
        public long Size { get => size; set => size = value; }
        public string Url { get => url; set => url = value; }
        public decimal Cantidad {
            get
            {
                if (this.hasta == 0)
                    return 0;
                return this.hasta - this.desde + 1;
            }
        }
        public string Fecha_asignacion_texto { get => Formateador.ToStringDB(fecha_asignacion); set => fecha_asignacion_texto = value; }
        public string Fecha_generacion_texto { get => Formateador.ToStringDB(DateTime.Now); set => fecha_generacion_texto = value; }

        public Res CargarDesdeXML(string url)
        {
            Res res = new Res();
            RespuestaFileToBytes resF = ManejoArchivos.FileToBytes(url);

            if (resF.IsCorrecto)
            {
                try
                {
                    XmlDocument xmlDTE = new XmlDocument();
                    xmlDTE.PreserveWhitespace = true;
                    xmlDTE.Load(url);

                    XmlNode nodeCAF = xmlDTE.SelectSingleNode("AUTORIZACION/CAF");

                    XmlNode nodeDA = nodeCAF.SelectSingleNode("DA");

                    XmlNode nodeRE = nodeDA.SelectSingleNode("RE");
                    this.rut_emisor = nodeRE.InnerText;

                    XmlNode nodeTD = nodeDA.SelectSingleNode("TD");
                    this.tipo_tde = Formateador.ToUInt32(nodeTD.InnerText);

                    XmlNode nodeFA = nodeDA.SelectSingleNode("FA");
                    this.fecha_asignacion = DateTime.ParseExact(nodeFA.InnerText, "yyyy-MM-dd", Thread.CurrentThread.CurrentCulture);

                    //RNG
                    XmlNode nodeRNG = nodeDA.SelectSingleNode("RNG");

                    XmlNode nodeD = nodeRNG.SelectSingleNode("D");
                    this.desde = Formateador.ToUInt32(nodeD.InnerText);

                    XmlNode nodeH = nodeRNG.SelectSingleNode("H");
                    this.hasta = Formateador.ToUInt32(nodeH.InnerText);

                    //FRMA
                    XmlNode nodeFRMA = nodeCAF.SelectSingleNode("FRMA ");
                    this.firma = nodeFRMA.InnerText;


                    this.nombre = resF.Nombre;
                    this.xml = resF.Bytes;
                    this.size = resF.Size;
                    this.Url = url;

                    res.Correcto();
                }catch(Exception ex)
                {
                    res.Error("EL xml no tiene el formato correcto: " + ex.Message);
                }
            }
            else
            {
                res.Error(res.DescripcionError);
            }

            return res;
        }

        /// <summary>
        /// Recolecta los valores actuales para consturir una respuesta tipo FileToBytes
        /// </summary>
        /// <returns>devuelte un objeto tipo respuesta FileToBytes con los valores actuales del caft</returns>
        public RespuestaFileToBytes GetFileToBytes()
        {
            RespuestaFileToBytes res = new RespuestaFileToBytes();
            res.Bytes = this.xml;
            res.Nombre = this.nombre;
            res.Size = this.size;
            res.Url = this.Url;
            res.Correcto();

            return res;
        }

        public Res GuardarEnDisco()
        {
            return ManejoArchivos.GuardarArchivoUrlSinNombre(EPath.CarpetaCAF, this.GetFileToBytes());
        }

        public byte[] GetBytes()
        {
            return this.xml;
        }
    }
}
