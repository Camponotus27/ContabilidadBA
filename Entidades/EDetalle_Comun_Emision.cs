using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EDetalleComportamiento
    {
        Normal,
        PrecioACosto,
        PrecioAUltimaCompraYCostoAPrecio
    } 

    /// <summary>
    ///  Detalle comun entre la nota de venta, cotizacion, emision de DTE
    /// </summary>
    public class EDetalle_Comun_Emision : Entidad
    {
        uint id;
        uint id_producto;
        uint linea;
        uint id_unidad_venta;

        uint id_word_press;
        decimal stock_gral;

        string nom_unidad_venta;
        string codigo_producto;
        string descripcion;
        decimal cantidad;
        decimal desc_porcentaje;
        decimal netopv;
        decimal ivapv;
        decimal brutopv;
        decimal precio_bruto_unit;
        decimal precio_bruto_linea;
        decimal monto_desc_bruto_linea;
        decimal monto_desc_bruto_unit;
        decimal total_bruto_c_desc;
        decimal precio_neto_unit;
        decimal precio_neto_linea;
        decimal monto_desc_neto_linea;
        decimal monto_desc_neto_unit;
        decimal total_neto_c_desc;
        decimal pv_real_unit;
        decimal pv_real_linea;
        private EDetalleComportamiento comportamiento;
        decimal pmp;
        decimal pmp_linea;
        BoolDB is_usado_nota_credito_debito = BoolDB.N;
        decimal descuento_lista_precios;
        decimal iva_porcetaje;

        decimal precio_base;
        decimal margen_base;

        decimal margen_minimo_comercializacion;

        decimal stock_bodega;
        decimal ultima_compra;

        bool prior_vta;
        decimal pre_vta_iva;

        bool PrecioACosto {
            get {
                return comportamiento == EDetalleComportamiento.PrecioACosto || comportamiento == EDetalleComportamiento.PrecioAUltimaCompraYCostoAPrecio;
            }
        }
        bool PrecioAUltimaCompraYCostoAPrecio {
            get {
                return comportamiento == EDetalleComportamiento.PrecioAUltimaCompraYCostoAPrecio;
            }
        }

        /// <summary>
        /// Si es True los valores se actualizan automaticamente al cambiar uno de ellos, Ej: si cambio cantidad el total linea cambiará
        /// </summary>
        bool permitirActualizarValores = false;
        bool controlar_stock = false;

        public uint Id { get => id; set => id = value; }
        public uint Id_producto { get => id_producto; set => id_producto = value; }
        public uint Linea { get => linea; set => linea = value; }
        public uint Id_unidad_venta { get => id_unidad_venta; set => id_unidad_venta = value; }
        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Cantidad
        {
            get => cantidad;
            set
            {
                if (controlar_stock && value > this.stock_bodega)
                {
                    cantidad = this.stock_bodega;
                    this.OnSuperoStockDisponible(new EventArgs());
                }
                else
                    cantidad = value;

                this.ActualizarTotalesDesdeLosValoresBase();
            }
        }
        public decimal Desc_porcentaje
        {
            get => desc_porcentaje;
            set
            {
                desc_porcentaje = value;
                this.ActualizarTotalesDesdeLosValoresBase();
            }
        }
        public decimal Netopv { get => netopv; set => netopv = value; }
        public decimal Ivapv { get => ivapv; set => ivapv = value; }
        public decimal Brutopv { get => brutopv; set => brutopv = value; }
        public decimal Precio_bruto_unit { get => precio_bruto_unit;
            set
            {
                if (this.permitirActualizarValores)
                {
                    if (this.PrecioAUltimaCompraYCostoAPrecio)
                    {
                        pmp = value * (1 + Porcentaje_iva_dividido_100);
                        this.ActualizarTotalesDesdeLosValoresBase();
                    }
                    else
                        Interacciones.Ex("No se puede modificar el precio del detalle");
                }
                else
                {
                    precio_bruto_unit = value;
                }

            }
        }
        public decimal Precio_bruto_linea { get => precio_bruto_linea; set => precio_bruto_linea = value; }
        public decimal Monto_desc_bruto_linea
        {
            get => monto_desc_bruto_linea;
            set
            {
                monto_desc_bruto_linea = value;
                this.ActualizarTotalesDesdeMontoDescBrutoLinea();
            }
        }
        public decimal Total_bruto_c_desc { get => total_bruto_c_desc; set => total_bruto_c_desc = value; }
        public decimal Precio_neto_unit { get => precio_neto_unit;
            set
            {
                if (this.permitirActualizarValores)
                {
                    if (this.PrecioAUltimaCompraYCostoAPrecio)
                    {
                        pmp = value;
                        this.ActualizarTotalesDesdeLosValoresBase();
                    }
                    else
                        Interacciones.Ex("No se puede modificar el precio del detalle");
                }
                else
                {
                    precio_neto_unit = value;
                }
                    
            }
        }
        public decimal Precio_neto_linea { get => precio_neto_linea; set => precio_neto_linea = value; }
        public decimal Monto_desc_neto_linea
        {
            get => monto_desc_neto_linea;
            set
            {
                monto_desc_neto_linea = value;
                this.ActualizarTotalesDesdeMontoDescNetoLinea();
            }
        }

        public decimal Total_neto_c_desc { get => total_neto_c_desc; set => total_neto_c_desc = value; }
        public decimal Pv_real_unit { get => pv_real_unit; set => pv_real_unit = value; }
        public decimal Pv_real_linea { get => pv_real_linea; set => pv_real_linea = value; }
        public decimal Pmp { get => pmp; set => pmp = value; }
        public decimal Pmp_linea { get => pmp_linea; set => pmp_linea = value; }
        public BoolDB Is_usado_nota_credito_debito { get => is_usado_nota_credito_debito; set => is_usado_nota_credito_debito = value; }
        public decimal Descuento_lista_precios
        {
            get => descuento_lista_precios;
            set
            {
                descuento_lista_precios = value;
                this.ActualizarTotalesDesdeLosValoresBase();
            }
        }
        public decimal Iva_porcetaje { get => iva_porcetaje; set => iva_porcetaje = value; }
        public decimal Precio_base
        {
            get => precio_base;
            set
            {
                precio_base = value;
                this.ActualizarTotalesDesdeLosValoresBase();
            }
        }
        public decimal Margen_base { get => margen_base; set => margen_base = value; }
        public decimal Margen_minimo_comercializacion { get => margen_minimo_comercializacion; set => margen_minimo_comercializacion = value; }
        public decimal Margen
        {
            get
            {
                decimal margen_calculado = this.margen_base - this.descuento_lista_precios;
                return Formateador.ToDecimalMayor(margen_calculado, this.margen_minimo_comercializacion);
            }
        }
        public decimal Monto_desc_bruto_unit { get => monto_desc_bruto_unit; set => monto_desc_bruto_unit = value; }
        public decimal Monto_desc_neto_unit { get => monto_desc_neto_unit; set => monto_desc_neto_unit = value; }

        public decimal Porcentaje_iva_dividido_100 { get => this.iva_porcetaje / 100m; }
        public decimal Porcentaje_descuento_dividido_100 { get => this.desc_porcentaje / 100m; }
        public decimal Porcentaje_margen_dividido_100 { get => this.Margen / 100m; }
        public decimal Stock_bodega { get => stock_bodega; set => stock_bodega = value; }
        public string Nom_unidad_venta { get => nom_unidad_venta; set => nom_unidad_venta = value; }
        public decimal Ultima_compra { get => ultima_compra;}
        public bool Prior_vta { get => prior_vta; set => prior_vta = value; }
        public decimal Pre_vta_iva { get => pre_vta_iva; set => pre_vta_iva = value; }

        public int Id_word_press_int
        {
            get
            {
                return Formateador.ToInt32(id_word_press);
            }
        }

        public int Stock_gral_int
        {
            get
            {
                if (int.TryParse(Math.Round(this.Stock_gral).ToString(), out int stock_general))
                {
                    return stock_general;
                }

                return 0;
            }
        }

        public uint Id_word_press { get => id_word_press; set => id_word_press = value; }
        public decimal Stock_gral { get => stock_gral; set => stock_gral = value; }

        public EDetalle_Comun_Emision()
        {

        }

        public EDetalle_Comun_Emision(EMae_Productos_DTE producto_dte, EEmp_Parametros parametros, EMae_Lista_Precios lista_precios, EDetalleComportamiento comportamiento = EDetalleComportamiento.Normal)
        {
            if (parametros == null)
                Interacciones.Ex("No se suministro parametros de empresa");

            if (parametros.Iva == 0)
                Interacciones.Ex("El iva es cero");

            if (lista_precios == null)
                Interacciones.Ex("No se sumininistro una lista de precios");

            this.comportamiento = comportamiento;

            this.prior_vta = Enums.BoolDBToBool(producto_dte.Prior_vta);
            this.pre_vta_iva = producto_dte.Pre_vta_iva;

            this.pmp = producto_dte.Pmp;
            this.id_producto = producto_dte.Id;
            this.descripcion = producto_dte.Nom_producto;
            this.codigo_producto = producto_dte.Cod_producto;

            this.stock_bodega = producto_dte.Stock_bodega;

            this.id_unidad_venta = producto_dte.Id_unidad_venta;
            this.nom_unidad_venta = producto_dte.Nom_unidad_venta;

            this.ultima_compra = producto_dte.Ultima_compra;

            if (stock_bodega > 1)
                this.cantidad = 1;

            this.iva_porcetaje = parametros.Iva;

            this.margen_minimo_comercializacion = parametros.Margen_minimo_comercializacion;
            this.precio_base = producto_dte.Precio_base;
            this.margen_base = producto_dte.Margen_base;
            this.descuento_lista_precios = lista_precios.Descuento;

            this.permitirActualizarValores = true;
            this.controlar_stock = true;


            if (this.comportamiento == EDetalleComportamiento.PrecioAUltimaCompraYCostoAPrecio)
                this.pmp = this.ultima_compra;

            this.ActualizarTotalesDesdeLosValoresBase();
        }

        public void ActivarDetalle()
        {
            this.permitirActualizarValores = true;
            this.controlar_stock = true;
            this.ActualizarTotalesDesdeLosValoresBase();
        }

        #region Evento
        public event EventHandler TotalesActualizados;
        protected virtual void OnTotalesActualizados(EventArgs e)
        {
            EventHandler handler = TotalesActualizados;
            handler?.Invoke(this, e);
        }
        public delegate void TotalesActualizadosEventHandler(object sender, EventArgs e);



        public event EventHandler SuperoStockDisponible;
        protected virtual void OnSuperoStockDisponible(EventArgs e)
        {
            EventHandler handler = SuperoStockDisponible;
            handler?.Invoke(this, e);
        }
        public delegate void SuperoStockDisponibleEventHandler(object sender, EventArgs e);
        #endregion
        public void ActualizarTotalesDesdeLosValoresBase()
        {
            if (!this.permitirActualizarValores)
                return;

            if (this.PrecioACosto)
                this.desc_porcentaje = 0;

            this.CalcularPrecioBruto();
            this.CalculosBrutos();
            this.CalculosNetos();
            this.CalulosRealesActivaciondeEvento();
        }

        private void CalculosBrutos()
        {
            #region Calculo Bruto Forma normal
            this.precio_bruto_linea = this.cantidad * this.precio_bruto_unit;
            this.total_bruto_c_desc = this.precio_bruto_linea - (this.precio_bruto_linea * Porcentaje_descuento_dividido_100);
            this.monto_desc_bruto_linea = this.precio_bruto_linea - this.total_bruto_c_desc;
            this.monto_desc_bruto_unit = Formateador.Dividir(this.monto_desc_bruto_linea, this.cantidad);
            #endregion
        }

        private void ActualizarTotalesDesdeMontoDescBrutoLinea()
        {
            if (!this.permitirActualizarValores)
                return;

            if (this.PrecioACosto)
                this.desc_porcentaje = 0;

            this.CalcularPrecioBruto();
            this.CalculosBrutosDesdeMontoDescLinea();
            this.CalculosNetos();
            this.CalulosRealesActivaciondeEvento();
        }

        private void ActualizarTotalesDesdeMontoDescNetoLinea()
        {
            if (!this.permitirActualizarValores)
                return;

            this.CalcularDescPorcDesdeMontoDescNetoLinea();

            this.CalculosBrutos();
            this.CalculosNetos();
            this.CalulosRealesActivaciondeEvento();
        }

        private void CalcularDescPorcDesdeMontoDescNetoLinea()
        {
            if (this.PrecioACosto)
                this.monto_desc_neto_linea = 0;

            this.total_neto_c_desc = this.precio_neto_linea - this.monto_desc_neto_linea;
            this.desc_porcentaje = decimal.Round(Formateador.Dividir((this.total_neto_c_desc - this.precio_neto_linea), precio_neto_linea * -1) * 100, 4);
            //this.monto_desc_neto_unit = Formateador.Dividir(this.monto_desc_neto_linea, this.cantidad);
        }

        private void CalculosBrutosDesdeMontoDescLinea()
        {
            if (PrecioACosto)
                this.monto_desc_bruto_linea = 0;

            #region Calculo Bruto Especial
            this.precio_bruto_linea = this.cantidad * this.precio_bruto_unit;
            //// solo esto es distinto al actualizar desde los valores base y desde el total descuento linea
            this.total_bruto_c_desc = this.precio_bruto_linea - this.monto_desc_bruto_linea;
            this.desc_porcentaje = decimal.Round(Formateador.Dividir((this.total_bruto_c_desc - this.precio_bruto_linea), precio_bruto_linea * -1) * 100, 4);
            //// hasta acá
            this.monto_desc_bruto_unit = Formateador.Dividir(this.monto_desc_bruto_linea, this.cantidad);
            #endregion
        }
        private void CalculosNetos()
        {
            #region Calculo Neto
            this.total_neto_c_desc = Formateador.Dividir(this.total_bruto_c_desc, (1 + Porcentaje_iva_dividido_100));
            this.precio_neto_linea = Formateador.Dividir(this.total_neto_c_desc, (1 - Porcentaje_descuento_dividido_100));
            this.monto_desc_neto_linea = this.precio_neto_linea - this.total_neto_c_desc;
            this.monto_desc_neto_unit = Formateador.Dividir(this.monto_desc_neto_linea, this.cantidad);
            this.precio_neto_unit = Formateador.Dividir(this.precio_neto_linea, this.cantidad);
            #endregion
        }


        private void CalulosRealesActivaciondeEvento()
        {
            this.ivapv = this.precio_bruto_unit - this.precio_neto_unit;
            this.pmp_linea = this.cantidad * this.pmp;


            this.brutopv = Formateador.Dividir(this.total_bruto_c_desc, this.cantidad);
            this.netopv = Formateador.Dividir(this.brutopv, (1 + Porcentaje_iva_dividido_100));
            this.ivapv = this.brutopv - this.netopv;

            //decimal PrecioiIvaLinea = this.Precio_bruto_linea * this.Precio_neto_linea;

            // llama el evento que avisa que los datos estan cargados
            this.OnTotalesActualizados(new EventArgs());
        }

        private void CalcularPrecioBruto()
        {
            if (this.PrecioACosto || this.PrecioAUltimaCompraYCostoAPrecio)
                this.precio_bruto_unit = this.pmp * (1 + Porcentaje_iva_dividido_100);
            else
            {
                if (this.prior_vta)
                    this.precio_bruto_unit = this.pre_vta_iva;
                else
                    this.precio_bruto_unit = Formateador.RedondeoMultiplo(this.Precio_base * (1 + Porcentaje_margen_dividido_100) * (1 + Porcentaje_iva_dividido_100), 10);
            }
        }
    }
}
