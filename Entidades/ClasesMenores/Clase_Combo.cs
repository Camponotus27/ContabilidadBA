using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesMenores
{
    public class IngEgre_Combo
    {
        string value;
        IngEgre ing_egre;

        public IngEgre_Combo(IngEgre ing_egre, string value)
        {
            this.ing_egre = ing_egre;
            this.value = value;
        }
        
        public string Value { get => value; set => this.value = value; }
        public IngEgre Ing_egre { get => ing_egre; set => ing_egre = value; }
    }
}
