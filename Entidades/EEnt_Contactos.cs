using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEnt_Contactos : Entidad
    {
        uint id;
        uint id_emp;
        uint id_entidad;
        uint cod_contacto;
        string nom_contacto;
        string cargo;
        uint cod_area;
        uint telefono;
        string email;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        public uint Cod_contacto { get => cod_contacto; set => cod_contacto = value; }
        public string Nom_contacto { get => nom_contacto; set => nom_contacto = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public uint Cod_area { get => cod_area; set => cod_area = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}
