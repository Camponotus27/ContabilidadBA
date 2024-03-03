using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class EComprobante_Detalle
    {
        int numero_cuenta;
        DateTime fecha;
        int numero_comprobante;
        string glosa;
        string rut;
        string parcela;
        int abono;
        int cargo;
        int correlativo;

        public EComprobante_Detalle(string parcela, string rut, string glosa, int abono)
        {
            this.Parcela = parcela;
            this.rut = rut;
            this.glosa = glosa;
            this.abono = abono;
        }

        public EComprobante_Detalle(string parcela, int numero_cuenta, string rut, string glosa, int abono)
        {
            this.Parcela = parcela;
            this.numero_cuenta = numero_cuenta;
            this.rut = rut;
            this.glosa = glosa;
            this.abono = abono;
        }

        public EComprobante_Detalle(int numero_comprobante, DateTime fecha, int numero_cuenta, string glosa, int correlativo, int suma_abono)
        {
            this.numero_comprobante = numero_comprobante;
            this.fecha = fecha;
            this.numero_cuenta = numero_cuenta;
            this.glosa = glosa;
            this.correlativo = correlativo;
            this.cargo = suma_abono;
        }

        public int Numero_cuenta { get => numero_cuenta; set => numero_cuenta = value; }
        public string Numero_cuenta_formateada { get => numero_cuenta.ToString().PadLeft(7, '0'); }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Fecha_formateada { get => fecha.ToString("ddMMyy"); }
        public int Numero_comprobante { get => numero_comprobante; set => numero_comprobante = value; }
        public string Numero_comprobante_formateada { get => numero_comprobante.ToString().PadLeft(7, '0'); }
        public string Glosa { get => glosa; set => glosa = value; }
        public string Glosa_Formateada{
            get
            {
                //string rut_formateado = this.ValidaRut(rut);

                // se formatea el rut pero no lo valida, hay rut que usan que no son validos  si que no tiene sentido
                string rut_formateado = rut;
                
                if(!string.IsNullOrEmpty(rut))
                {
                    rut_formateado = rut.Replace("-", "");
                    rut_formateado = rut_formateado.Replace(".", "");
                    rut_formateado = rut_formateado.PadLeft(9, '0');
                    if(rut_formateado.Length > 9)
                        rut_formateado = rut_formateado.Substring(rut_formateado.Length - 9, 9);
                    rut_formateado = rut_formateado.Insert(8, "-");
                    rut_formateado = rut_formateado.Insert(5, ".");
                    rut_formateado = rut_formateado.Insert(2, ".");
                }

                string glosa_formateada = "";

                // si el rut no es nulo se agrega a la glosa
                if (!string.IsNullOrEmpty(rut_formateado))
                {
                    glosa_formateada = rut_formateado + "/" + glosa;
                }
                else
                {
                    glosa_formateada = glosa;
                }

                if(glosa_formateada.Length > 25)
                {
                    return glosa_formateada.Substring(0, 25);
                }
                else
                {
                    return glosa_formateada;
                }
                
            }
        }
        public int Abono { get => abono; set => abono = value; }
        public int Cargo { get => cargo; set => cargo = value; }
        public int Correlativo { get => correlativo; set => correlativo = value; }
        public string Mes { get => fecha.ToString("MM");}
        public string Rut { get => rut; set => rut = value; }
        public string Parcela { get => parcela; set => parcela = value; }

        public override string ToString()
        {
            return this.Numero_cuenta_formateada + " " + this.Fecha_formateada + " " + this.Numero_comprobante_formateada + " " + this.Glosa_Formateada + " " + this.abono.ToString() + " " + this.cargo.ToString() + " " + this.correlativo.ToString() + " "  + this.Mes ;
        }

        /// <summary>
        /// Devuelve en la depsuesta un rut con formato XXXXXXXX-X
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public Res<string> ValidaRut(string rut)
        {
            Res<string> res = new Res<string>();

            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                res.Error("Rut tiene carecteres invalidos");
                return res;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                res.Error("El digito verificador no es correcto");
                return res;
            }

            res.Correcto();
            res.Respuesta = rut;
            return res;
        }

        public string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        public string SQLValues()
        {
            return "'" + this.Numero_cuenta_formateada + "', " +
                "'" + this.Fecha_formateada + "', " +
                "'" + this.Numero_comprobante_formateada + "', " +
                "'" + this.Glosa_Formateada + "', " +
                this.abono.ToString() + ", " + 
                this.cargo.ToString() + ", " +
                "'" + this.correlativo.ToString() + "', " +
                "'" + this.Mes + "'";
        }
    }
}
