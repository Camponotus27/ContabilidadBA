using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Comunas_Ciudad : EMae_Comunas
    {
        string nom_ciudad;
        public string Nom_ciudad { get => nom_ciudad; set => nom_ciudad = value; }
    }
}
