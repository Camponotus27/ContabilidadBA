using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEnt_Direcciones_Despacho_Comuna_Ciudad : EEnt_Direcciones_Despacho
    {
        string nom_comuna;
        string nom_ciudad;

        public string Nom_comuna { get => nom_comuna; set => nom_comuna = value; }
        public string Nom_ciudad { get => nom_ciudad; set => nom_ciudad = value; }
    }
}
