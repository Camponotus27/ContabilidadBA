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
    public class EEmp_SII
    {
        uint id_emp;
        uint rut_envia;
        string dv_envia;
        string nombre_certificado_digital;
        DateTime fecha_resolucion_certificacion; // ojo: el formato para la aplicacion es 'yyyy-MM-Dd'
        DateTime fecha_resolucion_produccion; // ojo: el formato para la aplicacion es 'yyyy-MM-Dd'
        uint numero_resolucion;
        Ambiente ambiente;
        string sucursal;

        // emails
        // produccion
        string email_usuario_administrador_produccion;
        string clave_usuario_administrador_produccion;
        string email_contacto_sii_produccion;
        string clave_contacto_sii_produccion;
        string email_contacto_empresas_produccion;
        string clave_contacto_empresas_produccion;

        // certificacion

        string email_usuario_administrador_certificacion;
        string clave_usuario_administrador_certificacion;

        string email_contacto_sii_certificacion;
        string clave_contacto_sii_certificacion;

        string email_contacto_empresas_certificacion;
        string clave_contacto_empresas_certificacion;

        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Rut_envia { get => rut_envia; set => rut_envia = value; }
        public string Dv_envia { get => dv_envia; set => dv_envia = value; }
        public string Nombre_certificado_digital { get => nombre_certificado_digital; set => nombre_certificado_digital = value; }
        public uint Numero_resolucion_segun_ambiente {
            get {
                if (this.ambiente == Ambiente.PRODUCCION)
                    return numero_resolucion;

                return 0;
            }
        }
        public Ambiente Ambiente { get => ambiente; set => ambiente = value; } 
        public DateTime Fecha_resolucion_certificacion { get => fecha_resolucion_certificacion; set => fecha_resolucion_certificacion = value; }
        public DateTime Fecha_resolucion_produccion { get => fecha_resolucion_produccion; set => fecha_resolucion_produccion = value; }
        public DateTime Fecha_resolucion_segun_ambiente {
            get
            {
                if (this.ambiente == Ambiente.PRODUCCION)
                    return fecha_resolucion_produccion;

                return fecha_resolucion_certificacion;
            }
        }
        public string Fecha_resolucion_texto {
            get
            {
                return Fecha_resolucion_segun_ambiente.ToString("yyyy-MM-dd");
            }
        }

        public string Fecha_resolucion_certificacion_texto { get => Formateador.DateToTextDB(fecha_resolucion_certificacion); set { } }
        public string Fecha_resolucion_produccion_texto { get => Formateador.DateToTextDB(fecha_resolucion_produccion); set { } }

        public string Sucursal { get => sucursal; set => sucursal = value; }
        public uint Numero_resolucion { get => numero_resolucion; set => numero_resolucion = value; }
        public string Email_usuario_administrador_produccion { get => email_usuario_administrador_produccion; set => email_usuario_administrador_produccion = value; }
        public string Clave_usuario_administrador_produccion { get => clave_usuario_administrador_produccion; set => clave_usuario_administrador_produccion = value; }
        public string Email_contacto_sii_produccion { get => email_contacto_sii_produccion; set => email_contacto_sii_produccion = value; }
        public string Clave_contacto_sii_produccion { get => clave_contacto_sii_produccion; set => clave_contacto_sii_produccion = value; }
        public string Email_contacto_empresas_produccion { get => email_contacto_empresas_produccion; set => email_contacto_empresas_produccion = value; }
        public string Clave_contacto_empresas_produccion { get => clave_contacto_empresas_produccion; set => clave_contacto_empresas_produccion = value; }
        public string Email_usuario_administrador_certificacion { get => email_usuario_administrador_certificacion; set => email_usuario_administrador_certificacion = value; }
        public string Clave_usuario_administrador_certificacion { get => clave_usuario_administrador_certificacion; set => clave_usuario_administrador_certificacion = value; }
        public string Email_contacto_sii_certificacion { get => email_contacto_sii_certificacion; set => email_contacto_sii_certificacion = value; }
        public string Clave_contacto_sii_certificacion { get => clave_contacto_sii_certificacion; set => clave_contacto_sii_certificacion = value; }
        public string Email_contacto_empresas_certificacion { get => email_contacto_empresas_certificacion; set => email_contacto_empresas_certificacion = value; }
        public string Clave_contacto_empresas_certificacion { get => clave_contacto_empresas_certificacion; set => clave_contacto_empresas_certificacion = value; }

        public string RutEnviaCompleto()
        {
            return this.rut_envia + "-" + this.dv_envia;
        }
    }
}
