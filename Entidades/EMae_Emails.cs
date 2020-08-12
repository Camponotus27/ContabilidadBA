using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Emails : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_email;
        string email;
        string clave;
        string descripcion;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public string Email { get => email; set => email = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public uint Cod_email { get => cod_email; set => cod_email = value; }
    }
}
