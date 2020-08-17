using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EComprobante
    {
        string nombre_comprobante = "NN";
        int numero_comprobante;
        int cuenta_abono;
        int cuenta_cargo;
        DateTime fecha;

        int suma_abono = 0;

        List<EComprobante_Detalle> detalle;

        public EComprobante(string nombre_comprobante, int numero_comprobante, DateTime fecha, int cuenta_abono, int cuenta_cargo)
        {
            this.numero_comprobante = numero_comprobante;
            this.Nombre_comprobante = nombre_comprobante;
            this.cuenta_abono = cuenta_abono;
            this.cuenta_cargo = cuenta_cargo;
            this.fecha = fecha;
        }

        public string Nombre_comprobante { get => nombre_comprobante; set => nombre_comprobante = value; }
        public List<EComprobante_Detalle> Detalle
        {
            get
            {
                if (detalle == null)
                    detalle = new List<EComprobante_Detalle>();

                return detalle;
            }
        }

        public string Fecha_formateada { get => fecha.ToString("ddMMyy"); }
        public int Numero_comprobante { get => numero_comprobante; set => numero_comprobante = value; }

        public void Add(EComprobante_Detalle detalle_add)
        {
            if (detalle == null)
                detalle = new List<EComprobante_Detalle>();

            detalle_add.Numero_comprobante = this.numero_comprobante;
            detalle_add.Fecha = this.fecha;
            detalle_add.Numero_cuenta = this.cuenta_abono;
            detalle_add.Correlativo = detalle.Count + 1;

            detalle.Add(detalle_add);

            suma_abono += detalle_add.Abono;
        }

        public List<EComprobante_Detalle> ExtraerComprobantes()
        {
            if(this.detalle == null)
            {
                Console.WriteLine("EL comprobante esta vacio");
                return new List<EComprobante_Detalle>();
            }

            List<EComprobante_Detalle> detalle_temp = new List<EComprobante_Detalle>(this.detalle);

            detalle_temp.Add(new EComprobante_Detalle(this.numero_comprobante, this.fecha, this.cuenta_cargo, this.nombre_comprobante, detalle_temp.Count + 1, this.suma_abono));

            return detalle_temp;
        }
    }
}
