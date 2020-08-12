using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Clases
{
    public class HEmpresa
    {
        private int _id_empresa;
        private int _rut;
        private string _dv;
        private string _razon_social;
        private string _codigo_actividad;
        private string _giro;
        private string _direccion_casa_matriz;
        private int _comuna;
        private int _ciudad;
        private string _comuna_nombre;
        private string _ciudad_nombre;
        private string _region;
        private string _rut_representante_legal;
        private string _dv_representante_legal;
        private string _nombre_representante_legal;
        private string _direccion_representante_legal;
        private int _comuna_representante_legal;
        private int _ciudad_representante_legal;
        private int _iva;
        private int _ila;
        private int _otro_impuesto;
        private int _margen_minimo;
        private string _ajuste_precio;
        private string _ajuste_margen;
        private string _margen_a_nivel;
        private string _sucursal_SII;
        private string _permite_stock_negativo;
        private string _ajusta_margen;
        private string _prefijo_codigo_barra_ean13;

        public int Id_empresa { get => _id_empresa; set => _id_empresa = value; }
        public int Rut { get => _rut; set => _rut = value; }
        public string Dv { get => _dv; set => _dv = value; }
        public string Razon_social { get => _razon_social; set => _razon_social = value; }
        public string Codigo_actividad { get => _codigo_actividad; set => _codigo_actividad = value; }
        public string Giro { get => _giro; set => _giro = value; }
        public string Direccion_casa_matriz { get => _direccion_casa_matriz; set => _direccion_casa_matriz = value; }
        public string Comuna_nombre { get => _comuna_nombre; set => _comuna_nombre = value; }
        public string Ciudad_nombre { get => _ciudad_nombre; set => _ciudad_nombre = value; }
        public string Rut_representante_legal { get => _rut_representante_legal; set => _rut_representante_legal = value; }
        public string Dv_representante_legal { get => _dv_representante_legal; set => _dv_representante_legal = value; }
        public string Nombre_representante_legal { get => _nombre_representante_legal; set => _nombre_representante_legal = value; }
        public string Direccion_representante_legal { get => _direccion_representante_legal; set => _direccion_representante_legal = value; }
        public int Comuna_representante_legal { get => _comuna_representante_legal; set => _comuna_representante_legal = value; }
        public int Ciudad_representante_legal { get => _ciudad_representante_legal; set => _ciudad_representante_legal = value; }
        public int Iva { get => _iva; set => _iva = value; }
        public int Ila { get => _ila; set => _ila = value; }
        public int Otro_impuesto { get => _otro_impuesto; set => _otro_impuesto = value; }
        public int Margen_minimo { get => _margen_minimo; set => _margen_minimo = value; }
        public string Ajuste_precio { get => _ajuste_precio; set => _ajuste_precio = value; }
        public string Ajuste_margen { get => _ajuste_margen; set => _ajuste_margen = value; }
        public string Margen_a_nivel { get => _margen_a_nivel; set => _margen_a_nivel = value; }
        public string Sucursal_SII { get => _sucursal_SII; set => _sucursal_SII = value; }
        public int Comuna { get => _comuna; set => _comuna = value; }
        public int Ciudad { get => _ciudad; set => _ciudad = value; }
        public string Permite_stock_negativo { get => _permite_stock_negativo; set => _permite_stock_negativo = value; }
        public string Ajusta_margen { get => _ajusta_margen; set => _ajusta_margen = value; }
        public string Region { get => _region; set => _region = value; }
        public string Prefijo_codigo_barra_ean13 { get => _prefijo_codigo_barra_ean13; set => _prefijo_codigo_barra_ean13 = value; }

        public HEmpresa()
        {

        }

        public string RutCompleto
        {
            get => this.Rut + "-" + this.Dv;
        }

        public string RutCompletoFormateado
        {
            get => Formateador.FormatearRut(this.Rut.ToString(), this.Dv);
        }

        public string RutCompletoRepresentanteLegal
        {
            get => this.Rut_representante_legal + "-" + this.Dv_representante_legal;
        }

        public string RutCompletoRepresentanteLegalFormateado
        {
            get => Formateador.FormatearRut(this.Rut_representante_legal.ToString(), this.Dv_representante_legal);
        }

        public string DireccionCompleta
        {
            get => this.Direccion_casa_matriz + ", " + this.Comuna_nombre;
        }

    }
}
