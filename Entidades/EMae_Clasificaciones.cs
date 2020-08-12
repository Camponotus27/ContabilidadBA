using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Clasificaciones : Entidad
    {
        uint id;
        uint id_emp;
        int id_word_press;
        int id_padre_word_press;
        string nom_clasificacion;
        uint id_padre;
        decimal margen;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public int Id_word_press { get => id_word_press; set => id_word_press = value; }
        public int Id_padre_word_press { get => id_padre_word_press; set => id_padre_word_press = value; }
        public string Nom_clasificacion { get => nom_clasificacion; set => nom_clasificacion = value; }
        public uint Id_padre { get => id_padre; set => id_padre = value; }
        public decimal Margen { get => margen; set => margen = value; }

        public string NombreMostrar
        {
            get
            {
                return this.id + " - " + this.nom_clasificacion;
            }
        }
    }
}
