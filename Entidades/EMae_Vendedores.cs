using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Vendedores : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_vend;
        uint rut_vend;
        string dv;
        string nom_vendedor;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Cod_vend { get => cod_vend; set => cod_vend = value; }
        public uint Rut_vend { get => rut_vend; set => rut_vend = value; }
        public string Dv { get => dv; set => dv = value; }
        public string Nom_vendedor { get => nom_vendedor; set => nom_vendedor = value; }

        public bool ValidaRut()
        {
            string rut = this.rut_vend + "-" + this.dv;
            return Entidad.ValidaRut(rut);
        }
    }
}
