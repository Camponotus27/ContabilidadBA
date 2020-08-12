using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Cajas_Equipo : EMae_Cajas
    {
        string nom_equipo;

        public string Nom_equipo { get => nom_equipo; set => nom_equipo = value; }
    }
}
