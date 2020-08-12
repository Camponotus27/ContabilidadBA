using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class EMae_Bodegas : Entidad
    {
        uint id;
        uint id_emp;
        uint id_local;
        uint cod_bod;
        string nom_bod;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Cod_bod { get => cod_bod; set => cod_bod = value; }
        public string Nom_bod { get => nom_bod; set => nom_bod = value; }

        internal string Mostrar()
        {
            return this.cod_bod + " - " + this.nom_bod;
        }


    }
}
