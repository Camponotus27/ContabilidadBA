using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EContab_Ctas_Conts : Entidad
    {
        uint id;
        uint id_emp;
        uint id_padre;
        string cta_contable;
        string nom_cta_cont;
        BoolDB habilitada = BoolDB.N;
        BoolDB imputable = BoolDB.N;
        BoolDB centro_costo = BoolDB.N;
        BoolDB conciliacion = BoolDB.N;
        BoolDB capital_propio = BoolDB.N;
        BoolDB flu = BoolDB.N;
        BoolDB ifrs = BoolDB.N;
        BoolDB analisis = BoolDB.N;
        BoolDB form1847 = BoolDB.N;
        BoolDB form29 = BoolDB.N;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_padre { get => id_padre; set => id_padre = value; }
        public string Cta_contable
        {
            get => cta_contable;
            set
            {
                cta_contable = value;
                this.cambio_nombre_o_cuenta = true;
            }
        }
        public string Nom_cta_cont
        {
            get => nom_cta_cont;
            set
            {
                nom_cta_cont = value;
                this.cambio_nombre_o_cuenta = true;
            }
        }
       
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
        public bool HabilitadaBool
        {
            get
            {
                return (habilitada == BoolDB.S);
            }
            set
            {
                if (value)
                    habilitada = BoolDB.S;
                else
                    habilitada = BoolDB.N;
            }
        }
        public BoolDB Imputable { get => imputable; set => imputable = value; }
        public bool ImputableBool
        {
            get
            {
                return (imputable == BoolDB.S);
            }
            set
            {
                if (value)
                    imputable = BoolDB.S;
                else
                    imputable = BoolDB.N;
            }
        }
        public BoolDB Centro_costo { get => centro_costo; set => centro_costo = value; }
        public bool Centro_costoBool
        {
            get
            {
                return (centro_costo == BoolDB.S);
            }
            set
            {
                if (value)
                    centro_costo = BoolDB.S;
                else
                    centro_costo = BoolDB.N;
            }
        }
        public BoolDB Conciliacion { get => conciliacion; set => conciliacion = value; }
        public bool ConciliacionBool
        {
            get
            {
                return (conciliacion == BoolDB.S);
            }
            set
            {
                if (value)
                    conciliacion = BoolDB.S;
                else
                    conciliacion = BoolDB.N;
            }
        }
        public BoolDB Capital_propio { get => capital_propio; set => capital_propio = value; }
        public bool Capital_propioBool
        {
            get
            {
                return (capital_propio == BoolDB.S);
            }
            set
            {
                if (value)
                    capital_propio = BoolDB.S;
                else
                    capital_propio = BoolDB.N;
            }
        }
        public BoolDB Flu { get => flu; set => flu = value; }
        public bool FluBool
        {
            get
            {
                return (flu == BoolDB.S);
            }
            set
            {
                if (value)
                    flu = BoolDB.S;
                else
                    flu = BoolDB.N;
            }
        }
        public BoolDB Ifrs { get => ifrs; set => ifrs = value; }
        public bool IfrsBool
        {
            get
            {
                return (ifrs == BoolDB.S);
            }
            set
            {
                if (value)
                    ifrs = BoolDB.S;
                else
                    ifrs = BoolDB.N;
            }
        }
        public BoolDB Analisis { get => analisis; set => analisis = value; }
        public bool AnalisisBool
        {
            get
            {
                return (analisis == BoolDB.S);
            }
            set
            {
                if (value)
                    analisis = BoolDB.S;
                else
                    analisis = BoolDB.N;
            }
        }
        public BoolDB Form1847 { get => form1847; set => form1847 = value; }
        public bool Form1847Bool
        {
            get
            {
                return (form1847 == BoolDB.S);
            }
            set
            {
                if (value)
                    form1847 = BoolDB.S;
                else
                    form1847 = BoolDB.N;
            }
        }
        public BoolDB Form29 { get => form29; set => form29 = value; }
        public bool Form29Bool
        {
            get
            {
                return (form29 == BoolDB.S);
            }
            set
            {
                if (value)
                    form29 = BoolDB.S;
                else
                    form29 = BoolDB.N;
            }
        }

        bool cambio_nombre_o_cuenta = false;

        public EContab_Ctas_Conts()
        {

        }
        public EContab_Ctas_Conts(uint id, string cta_contable)
        {
            this.id = id;
            this.cta_contable = cta_contable;
        }

        public bool CambioNombreOCuenta()
        {
            bool temp = this.cambio_nombre_o_cuenta;
            this.cambio_nombre_o_cuenta = false;
            return temp;
        }

        public void ResetearCambioNombreoCuente()
        {
            this.cambio_nombre_o_cuenta = false;
        }
    }
}
