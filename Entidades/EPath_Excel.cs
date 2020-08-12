using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EPath_Excel
    {
        string path_excel;
        string nombre;
        int numero_hojas_validas;

        public string Path_excel { get => path_excel; set => path_excel = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero_hojas_validas { get => numero_hojas_validas; set => numero_hojas_validas = value; }
    }
}
