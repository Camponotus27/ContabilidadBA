using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Herramientas
{
    public class Sesion_OLD 
    {
        static Sesion_OLD miSesion;

        /// <summary>
        /// Singleton a MiSesion
        /// </summary>
        public static Sesion_OLD MiSesion {
            get
            {
                if (miSesion == null)
                    miSesion = new Sesion_OLD();
                return miSesion;
            }

            set => miSesion = value;
        }

        string usuario = "";
        bool isLogeado = false;
        string mac = "";

        /// Sucursal
        ///
        int id_sucursal = 0;
        string nombre_sucursal = "";

        /// Bodega
        /// 
        int id_bodega = 0;
        int numero_bodega = 0;
        string nombre_bodega = "";

        /// Caja
        /// 
        int id_caja = 0;
        string nombre_caja = "";

        /// rol
        /// 
        int id_rol = 0;
        string nombre_rol = "";
        string descripcion_rol = "";


        //private string urlParametro = @"Parametos\Parametos.xml";

        public Sesion_OLD()
        {

        }

        public Sesion_OLD(string mac, int id_sucursal, string nombre_sucursal, int id_bodega, int numero_bodega, string nombre_bodega, int id_caja, string nombre_caja)
        {
            this.mac = mac;
            this.id_sucursal = id_sucursal;
            this.nombre_sucursal = nombre_sucursal;
            this.id_bodega = id_bodega;
            this.numero_bodega = numero_bodega;
            this.nombre_bodega = nombre_bodega;
            this.id_caja = id_caja;
            this.nombre_caja = nombre_caja;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public bool IsLogeado { get => isLogeado; set => isLogeado = value; }
        public string Mac { get => mac; set => mac = value; }
        public int Id_sucursal { get => id_sucursal; set => id_sucursal = value; }
        public string Nombre_sucursal { get => nombre_sucursal; set => nombre_sucursal = value; }
        public int Id_bodega { get => id_bodega; set => id_bodega = value; }
        public int Numero_bodega { get => numero_bodega; set => numero_bodega = value; }
        public string Nombre_bodega { get => nombre_bodega; set => nombre_bodega = value; }
        public int Id_caja { get => id_caja; set => id_caja = value; }
        public string Nombre_caja { get => nombre_caja; set => nombre_caja = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Nombre_rol { get => nombre_rol; set => nombre_rol = value; }
        public string Descripcion_rol { get => descripcion_rol; set => descripcion_rol = value; }

        public string MostrarSucursal()
        {
            return this.Id_sucursal + " - " + this.Nombre_sucursal; 
        }

        public string MostrarBodega()
        {
            return this.Numero_bodega + " - " + this.Nombre_bodega;
        }

        public string MostrarCaja()
        {
            if(this.isCaja())
            {
                return this.Id_caja + " - " + this.Nombre_caja;
            }
            else{
                return "NO ES CAJA";
            }
            
        }

        public bool isCaja()
        {
            if (this.Id_caja != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Convierte la clase en un string XML
        /// </summary>
        /// <returns>string de XML</returns>
        public string XML()
        {
            XmlSerializer x = new XmlSerializer(this.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }

    }

    
}
