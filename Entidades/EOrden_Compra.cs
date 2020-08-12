using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EOrden_Compra : Entidad
    {
        uint id;
        uint cod;
        uint id_emp;
        uint id_entidad;
        DateTime fecha;
        DateTime fecha_desde;
        DateTime fecha_hasta;
        uint prov_rut;
        string prov_dv; // este esta validado en la DB como dv o sea solo permite [1-9,k]
        string prov_razon_social;
        decimal subtotal_neto;
        decimal desc_porcentaje;
        decimal desc_monto_neto;
        decimal neto;
        decimal iva_porcentaje;
        decimal iva_monto;
        decimal total;
        string glosa;
        EstadoOrdenCompra estado = EstadoOrdenCompra.GENERADA;
        uint rectificado;
        List<EOrden_Compra_Detalle> detalle;


        public uint Id { get => id; set => id = value; }
        public uint Cod { get => cod; set => cod = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public DateTime Fecha {
            get
            {
                if (fecha < DateTime.Parse("2000-01-01"))
                    return DateTime.Now.Date;

                return fecha;
            }
            set => fecha = value; }
        public DateTime Fecha_desde {
            get
            {
                if (fecha_desde < DateTime.Parse("2000-01-01"))
                    return DateTime.Now.Date;

                return fecha_desde;
            }
            set => fecha_desde = value; }
        public DateTime Fecha_hasta {
            get
            {
                if (fecha_hasta < DateTime.Parse("2000-01-01"))
                    return DateTime.Now.Date;

                return fecha_hasta;
            } set => fecha_hasta = value; }
        public string Fecha_texto { get => Formateador.DateToTextDB(fecha); set { } }
        public string Fecha_desde_texto { get => Formateador.DateToTextDB(fecha_desde); set { } }
        public string Fecha_hasta_texto { get => Formateador.DateToTextDB(fecha_hasta); set { } }
        public uint Prov_rut { get => prov_rut; set => prov_rut = value; }
        public string Prov_dv { get => prov_dv; set => prov_dv = value; }
        public string Prov_razon_social { get => prov_razon_social; set => prov_razon_social = value; }
        public decimal Subtotal_neto { get => subtotal_neto; set => subtotal_neto = value; }
        public decimal Desc_porcentaje { get => desc_porcentaje; set => desc_porcentaje = value; }
        public decimal Desc_monto_neto { get => desc_monto_neto; set => desc_monto_neto = value; }
        public decimal Neto { get => neto; set => neto = value; }
        public decimal Iva_porcentaje { get => iva_porcentaje; set => iva_porcentaje = value; }
        public decimal Iva_monto { get => iva_monto; set => iva_monto = value; }
        public decimal Total { get => total; set => total = value; }
        public string Glosa { get => glosa; set => glosa = value; }
        public EstadoOrdenCompra Estado { get => estado; set => estado = value; }
        public string Estado_Mostrar {
            get {
                if (this.id == 0)
                    return "SIN ESTADO";

                return estado.ToString();
            } set { } }
        /// <summary>
        /// Cantidad de rectificaciones o modificaciones
        /// </summary>
        public uint Rectificado { get => rectificado; set => rectificado = value; }
        public string Rectificado_Mostrar
        {
            get
            {
                if (this.id == 0)
                    return "--";

                return rectificado.ToString("N0");
            } set { }
        }
        public List<EOrden_Compra_Detalle> Detalle { get => detalle; set => detalle = value; }
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        
    }
}
