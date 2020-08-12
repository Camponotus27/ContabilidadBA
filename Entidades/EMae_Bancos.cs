using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Bancos : Entidad
    {
        private uint id;
        private uint cod_banco;
        private string nom_banco;

        public uint Id { get => id; set => id = value; }
        public uint Cod_banco { get => cod_banco; set => cod_banco = value; }
        public string Nom_banco { get => nom_banco; set => nom_banco = value; }
    }
}
