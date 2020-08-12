using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Clases
{
    public class EItemLista
    {
        uint id;
        string nombre;

        public EItemLista()
        {

        }

        public EItemLista(uint id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public uint Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
