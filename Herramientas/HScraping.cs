using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class HScraping
    {
        public HScraping()
        {
            
        }



        public static Res<string> ObtenerImagenProductoArtel(string cod_artel)
        {
            Res<string> res = new Res<string>();

            string utl_base = "https://www.artel.cl";

            string url = @"/productos/busqueda/";

            HtmlWeb oWeb = new HtmlWeb();
            HtmlDocument doc = oWeb.Load(utl_base + url + cod_artel + @"/");

           

            IEnumerable<HtmlNode> nodos_posible_listado = doc.DocumentNode.CssSelect("#listado-productos");

            if(nodos_posible_listado.Count() < 1)
            {
                res.Error("No se encontro el codigo");
                return res;
            }

            HtmlNode listado_productos = nodos_posible_listado.First();


            IEnumerable<HtmlNode> imagenes_listado_productos = listado_productos.CssSelect("img");

            if (imagenes_listado_productos.Count() == 0)
            {
                res.Error("No se encontro el nodo del producto");
                return res;
            }else if(imagenes_listado_productos.Count() > 1)
            {
                res.AddMensaje("Se encontro mas de un producto se selecciono el primero");
            }


            HtmlNode imagen = imagenes_listado_productos.First();
            string url_imagen = imagen.GetAttributeValue("src");

            res.Respuesta = utl_base + url_imagen;
            res.Correcto();

            return res;
        }

        public static Res<List<string>> ObtenerImagenesProductoRhein(string url_pagina)
        {
            Res<List<string>> res = new Res<List<string>>();

            HtmlWeb oWeb = new HtmlWeb();
            HtmlDocument doc = oWeb.Load(url_pagina);

            IEnumerable<HtmlNode> listado_productos = doc.DocumentNode.CssSelect(".fullContainer");

            if (listado_productos.Count() < 1)
            {
                res.Error("No se encontro la lista de prductos");
                return res;
            }


            IEnumerable<HtmlNode> imagenes_listado_productos = listado_productos.CssSelect("img");

            if (imagenes_listado_productos.Count() == 0)
            {
                res.Error("No se encontro ninguna imagen");
                return res;
            }

            List<string> listado_imagenes_string = new List<string>();

            foreach(HtmlNode imagen in imagenes_listado_productos)
            {
                string url_imagen = imagen.GetAttributeValue("src");
                if(!string.IsNullOrEmpty(url_imagen))
                    listado_imagenes_string.Add(url_imagen);
            }
            
            res.Respuesta = listado_imagenes_string;
            res.Correcto();


            return res;
        }
    }
}
