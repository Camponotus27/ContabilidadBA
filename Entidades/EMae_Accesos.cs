using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Accesos : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_acceso;
        string nom_acceso;
        string descripcion;
        BoolDB habilitada;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Cod_acceso { get => cod_acceso; set => cod_acceso = value; }
        public string Nom_acceso { get => nom_acceso; set => nom_acceso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
    }
}
