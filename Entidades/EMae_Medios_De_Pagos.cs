using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Medios_De_Pagos : Entidad
    {
        uint id;
        string nombre_forma_pago;
        string descripcion_forma_pago;
        BoolDB habilitada;

        public uint Id { get => id; set => id = value; }
        public string Nombre_forma_pago { get => nombre_forma_pago; set => nombre_forma_pago = value; }
        public string Descripcion_forma_pago { get => descripcion_forma_pago; set => descripcion_forma_pago = value; }
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
        public bool HabilitadaBool
        {
            get
            {
                return Enums.BoolDBToBool(this.Habilitada);
            }
        }
    }
}
