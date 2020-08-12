using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesMenores
{
    public class Clase_List<T> : Entidad
    {
        List<T> lista;
        public List<T> Lista { get => lista; set => lista = value; }

        public Clase_List()
        {

        }

        public Clase_List(List<T> lista){
            this.lista = lista;
        }
    }
}
