using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Lista_Precios : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_list_precio;
        string nom_list_precio;
        decimal descuento;
        BoolDB habilitada;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public string Nom_list_precio { get => nom_list_precio; set => nom_list_precio = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
        public uint Cod_list_precio { get => cod_list_precio; set => cod_list_precio = value; }
    }
}
