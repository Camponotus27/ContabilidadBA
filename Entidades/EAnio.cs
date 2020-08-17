using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EAnio
    {
        int id;
        int anio;

        public EAnio(int valor)
        {
            this.id = valor;
            this.anio = valor;
        }

        public int Id { get => id; set => id = value; }
        public int Anio { get => anio; set => anio = value; }
    }
}
