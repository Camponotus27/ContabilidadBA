using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    public class EMae_Empresas : Entidad
    {
        uint id;
        uint rut;
        string dv;
        string razon_social;
        uint codigo_actividad;
        string direccion;
        uint id_com;
        string giro;
        uint rut_representante_legal;
        string dv_representante_legal;
        string nom_rep_legal;
        string dir_rep_legal;
        uint id_com_rep_legal;
        uint id_entidad_rep_legal;
        EEmp_Parametros parametros;
        EEmp_Contab_Ctas_Conts_Nom_Ctas cuentas_contables;
        EEmp_SII sii;
        List<ERel_Emp_Medios_De_Pagos_Nompre_Des> medios_de_pagos;
        uint id_email;

        public uint Id { get => id; set => id = value; }
        public uint Rut { get => rut; set => rut = value; }
        public string Dv { get => dv; set => dv = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }
        public uint Codigo_actividad { get => codigo_actividad; set => codigo_actividad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Id_com { get => id_com; set => id_com = value; }
        public string Giro { get => giro; set => giro = value; }
        public uint Rut_representante_legal { get => rut_representante_legal; set => rut_representante_legal = value; }
        public string Dv_representante_legal { get => dv_representante_legal; set => dv_representante_legal = value; }
        public string Nom_rep_legal { get => nom_rep_legal; set => nom_rep_legal = value; }
        public string Dir_rep_legal { get => dir_rep_legal; set => dir_rep_legal = value; }
        public uint Id_com_rep_legal { get => id_com_rep_legal; set => id_com_rep_legal = value; }
        public uint Id_entidad_rep_legal { get => id_entidad_rep_legal; set => id_entidad_rep_legal = value; }
        public EEmp_Parametros Parametros { get => parametros; set => parametros = value; }
        public EEmp_Contab_Ctas_Conts_Nom_Ctas Cuentas_contables { get => cuentas_contables; set => cuentas_contables = value; }
        public EEmp_SII Sii { get => sii; set => sii = value; }
        public List<ERel_Emp_Medios_De_Pagos_Nompre_Des> Medios_de_pagos { get => medios_de_pagos; set => medios_de_pagos = value; }
        public uint Id_email { get => id_email; set => id_email = value; }

        public string Mostrar()
        {
            return this.rut + "-" + this.dv + " " + this.razon_social;
        }

        public string RutCompleto()
        {
            return this.rut + "-" + this.dv;
        }

        public string GiroSii()
        {
            return Formateador.Acortar(this.giro, 80);
        }
    }
}
