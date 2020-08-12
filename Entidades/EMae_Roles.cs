using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    public class EMae_Roles : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_rol;
        string nom_rol;
        string descripcion;
        BoolDB habilitada;

        List<EMae_Accesos> aceesos = new List<EMae_Accesos>();

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Cod_rol { get => cod_rol; set => cod_rol = value; }
        public string Nom_rol { get => nom_rol; set => nom_rol = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
        public List<EMae_Accesos> Aceesos { get => aceesos; set => aceesos = value; }

        public EMae_Roles()
        {
            this.aceesos = new List<EMae_Accesos>();
        }
    }
}
