using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    public class EMae_Locales : Entidad
    {
        uint id;
        uint cod_local;
        uint id_emp;
        string nom_local;
        uint id_lista_precio;
        string direccion;
        uint id_comuna;
        BoolDB habilitada = BoolDB.S;
        EMae_Lista_Precios lista_precios;
        List<EMae_Bodegas> bodegas;
        List<EMae_Cajas> cajas;

        public EMae_Locales()
        {
            this.Bodegas = new List<EMae_Bodegas>();
        }

        public uint Id { get => id; set => id = value; }
        public uint Cod_local { get => cod_local; set => cod_local = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public string Nom_local { get => nom_local; set => nom_local = value; }
        public uint Id_lista_precio { get => id_lista_precio; set => id_lista_precio = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Id_comuna { get => id_comuna; set => id_comuna = value; }
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
        public List<EMae_Bodegas> Bodegas { get => bodegas; set => bodegas = value; }
        public List<EMae_Cajas> Cajas { get => cajas; set => cajas = value; }
        public EMae_Lista_Precios Lista_precios { get => lista_precios; set => lista_precios = value; }

        internal string Mostrar()
        {
            return this.id + " - " + this.nom_local;
        }
    }
}
