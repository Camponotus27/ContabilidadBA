using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    public class EMae_Usuarios : Entidad
    {
        uint id;
        uint id_emp;
        uint id_entidad;
        uint id_rol;
        string nick;
        string clave;
        DateTime? fecha_creacion;
        DateTime? ultimo_acceso;
        uint id_usuario_creacion;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        public uint Id_rol { get => id_rol; set => id_rol = value; }
        public string Nick { get => nick; set => nick = value; }
        public string Clave { get => clave; set => clave = value; }
        public DateTime? Fecha_creacion { get => fecha_creacion; set => fecha_creacion = value; }
        public DateTime? Ultimo_acceso { get => ultimo_acceso; set => ultimo_acceso = value; }
        public uint Id_usuario_creacion { get => id_usuario_creacion; set => id_usuario_creacion = value; }
    }
}
