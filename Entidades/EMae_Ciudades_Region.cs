using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Ciudades_Region: EMae_Ciudades
    {
        string nom_region;
        public string Nom_region { get => nom_region; set => nom_region = value; }
    }
}
