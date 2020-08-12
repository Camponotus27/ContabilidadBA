using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlType(TypeName = "ERel_Emp_Medios_De_Pagos_Nompre_Des")] 
    public class ERel_Emp_Medios_De_Pagos_Nompre_Des : ERel_Emp_Medios_De_Pagos
    {
        string nombre_forma_pago;
        string descripcion_forma_pago;
        BoolDB habilitada_emp;
        
        public string Nombre_forma_pago { get => nombre_forma_pago; set => nombre_forma_pago = value; }
        public string Descripcion_forma_pago { get => descripcion_forma_pago; set => descripcion_forma_pago = value; }
        public BoolDB Habilitada_emp { get => habilitada_emp; set => habilitada_emp = value; }

        public bool HabilitadaEmpBool
        {
            get
            {
                return (habilitada_emp == BoolDB.S);
            }
            set
            {
                if (value)
                    habilitada_emp = BoolDB.S;
                else
                    habilitada_emp = BoolDB.N;
            }
        }
    }
}
