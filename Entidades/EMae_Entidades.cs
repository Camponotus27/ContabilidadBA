using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Entidades : Entidad
    {
        uint id;
        uint rut;
        uint id_emp;
        string dv;
        string razon_social;
        string direccion;
        uint id_com;
        uint telefono;
        string email;
        string giro;
        uint id_cta_cont;
        uint id_lista_precio;
        string email_sii;
        string nom_comuna;
        string nom_ciudad;
        EEnt_Antecedentes_Comerciales antecedentes_comerciales;
        List<EEnt_Contactos> contactos;
        List<EEnt_Direcciones_Despacho> direcciones_despacho;
        EMae_Lista_Precios lista_precios;

        public uint Id { get => id; set => id = value; }
        public uint Rut { get => rut; set => rut = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public string Dv { get => dv; set => dv = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public uint Id_com { get => id_com; set => id_com = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Giro { get => giro; set => giro = value; }
        public uint Id_cta_cont { get => id_cta_cont; set => id_cta_cont = value; }
        public uint Id_lista_precio { get => id_lista_precio; set => id_lista_precio = value; }
        public string Email_sii { get => email_sii; set => email_sii = value; }
        public List<EEnt_Contactos> Contactos { get => contactos; set => contactos = value; }
        public List<EEnt_Direcciones_Despacho> Direcciones_despacho { get => direcciones_despacho; set => direcciones_despacho = value; }
        public EEnt_Antecedentes_Comerciales Antecedentes_comerciales { get => antecedentes_comerciales; set => antecedentes_comerciales = value; }
        public EMae_Lista_Precios Lista_precios { get => lista_precios; set => lista_precios = value; }
        public string Nom_comuna { get => nom_comuna; set => nom_comuna = value; }
        public string Nom_ciudad { get => nom_ciudad; set => nom_ciudad = value; }

        public bool ValidaRut()
        {
            string rut = this.Rut + "-" + this.Dv;
            return Entidad.ValidaRut(rut);
        }
    }
}
