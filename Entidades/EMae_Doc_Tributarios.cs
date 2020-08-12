using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Doc_Tributarios : Entidad
    {
        uint id;
        uint cod;
        uint id_emp;
        string nom_docsii;
        uint orden;
        BoolDB vigente;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public string Nom_docsii { get => nom_docsii; set => nom_docsii = value; }
        public uint Orden { get => orden; set => orden = value; }
        public BoolDB Vigente { get => vigente; set => vigente = value; }
        public bool VigenteBool
        {
            get
            {
                return (vigente == BoolDB.S);
            }
            set
            {
                if (value)
                    vigente = BoolDB.S;
                else
                    vigente = BoolDB.N;
            }
        }

        public uint Cod { get => cod; set => cod = value; }
    }
}
