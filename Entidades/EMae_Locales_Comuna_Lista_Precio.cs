using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Locales_Comuna_Lista_Precio : EMae_Locales
    {
        string nom_comuna;
        uint cod_list_precio;
        string nom_list_precio;

        public string Nom_comuna { get => nom_comuna; set => nom_comuna = value; }
        public uint Cod_list_precio { get => cod_list_precio; set => cod_list_precio = value; }
        public string Nom_list_precio { get => nom_list_precio; set => nom_list_precio = value; }
    }
}
