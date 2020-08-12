using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEnt_Antecedentes_Comerciales : Entidad
    {
        uint id;
        uint id_emp;
        uint id_entidad;
        CondVenta cond_venta = CondVenta.CONTADO;
        decimal credito = 0;
        decimal credito_utilizado = 0;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        public CondVenta Cond_venta { get => cond_venta; set => cond_venta = value; }
        public decimal Credito { get => credito; set => credito = value; }
        public decimal Credito_utilizado { get => credito_utilizado; set => credito_utilizado = value; }
        public decimal Credito_disponible {
            get
            {
                return this.credito - this.credito_utilizado;
            }
        }
    }
}
