using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EDetalle_Comun_Ingreso : Entidad
    {
        protected uint id;
        protected uint id_dte;
        protected uint id_producto;
        protected uint id_unidad_compra;
        protected string nom_unidad_compra;
        protected string codigo_producto;
        protected string desc_compra;
        protected string nom_producto;

        protected decimal cantidad;
        protected decimal desc_porcentaje;
        protected decimal precio_neto_unit;
        protected decimal precio_neto_linea;
        protected decimal monto_desc_neto_linea;
        protected decimal total_neto_c_desc;

        protected uint id_entidad;
        protected string cod_prod_proveedor;
        protected string desc_compra_proveedor;
        protected uint cant_comp = 1;
        protected uint cant_vta = 1;

        protected bool permitirActualizarValores = false;

        public uint Id { get => id; set => id = value; }
        public uint Id_dte { get => id_dte; set => id_dte = value; }
        public uint Id_producto { get => id_producto; set => id_producto = value; }
        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public string Desc_compra {
            get
            {
                if (string.IsNullOrEmpty(desc_compra) && this.id_producto != 0)
                {
                    if (string.IsNullOrEmpty(this.nom_producto))
                    {
                        return "(sin descripcion)";
                    }
                    else
                    {
                        return "(" + this.nom_producto + ")";
                    }
                }

                return desc_compra;
            }
            set => desc_compra = value; }
        public decimal Cantidad { get => cantidad;
            set
            {
                cantidad = value;
                this.ActualizarTotales();
            }
        }
        public decimal Desc_porcentaje { get => desc_porcentaje;
            set
            {
                desc_porcentaje = value;
                this.ActualizarTotales();
            }
        }
        public decimal Precio_neto_unit { get => precio_neto_unit;
            set
            {
                precio_neto_unit = value;
                this.ActualizarTotales();
            }
        }
        public decimal Precio_neto_linea { get => precio_neto_linea; set => precio_neto_linea = value; }
        public decimal Monto_desc_neto_linea { get => monto_desc_neto_linea;
            set
            {
                monto_desc_neto_linea = value;
                this.ActualizarTotalesDesdeDescNetoLinea();
            }
        }



        public decimal Total_neto_c_desc { get => total_neto_c_desc; set => total_neto_c_desc = value; }
        public decimal Porcentaje_descuento_dividido_100 {
            get
            {
                return this.desc_porcentaje / 100m;
            }
        }

        public uint Id_unidad_compra { get => id_unidad_compra; set => id_unidad_compra = value; }
        public string Nom_unidad_compra { get => nom_unidad_compra; set => nom_unidad_compra = value; }
        /// <summary>
        /// Se usa para crear un producto temporal para una busqueda, no es relevante
        /// </summary>
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        public string Cod_prod_proveedor { get => cod_prod_proveedor; set => cod_prod_proveedor = value; }
        public uint Cant_comp { get => cant_comp;
            set
            {
                if (permitirActualizarValores)
                    this.RevertirCambioUnidades();
                cant_comp = value;
                if (permitirActualizarValores)
                    this.CambioUnidades();
            }
        }
        public uint Cant_vta { get => cant_vta;
            set
            {
                if(permitirActualizarValores)
                    this.RevertirCambioUnidades();
                cant_vta = value;
                if (permitirActualizarValores)
                    this.CambioUnidades();
            }
        }
        public string Desc_compra_proveedor { get => desc_compra_proveedor; set => desc_compra_proveedor = value; }
        public decimal Relacion_de_cantidad_compra_sobre_venta {
            get
            {
                return Formateador.Dividir(this.cant_vta, this.cant_comp);
            }
        }

        public string Nom_producto { get => nom_producto; set => nom_producto = value; }

        public string Desc_compra_mostrar
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Desc_compra_proveedor))
                    return this.Desc_compra_proveedor;
                else if (!string.IsNullOrEmpty(this.Desc_compra))
                    return this.Desc_compra;

                return this.Nom_producto;
            }
        }

        /// <summary>
        /// Variable multiproposito de tipo uint
        /// </summary>
        public uint Var_Uint1 { get; set; }

        public EDetalle_Comun_Ingreso()
        {

        }

        public EDetalle_Comun_Ingreso(EMae_Productos_DTE_Compra producto_dte_compra, bool activar = true)
        {
            this.id_producto = producto_dte_compra.Id;

            this.nom_producto = producto_dte_compra.Nom_producto;
            this.desc_compra = producto_dte_compra.Desc_comp;

            this.codigo_producto = producto_dte_compra.Cod_producto;
            this.cod_prod_proveedor = producto_dte_compra.Cod_prod_proveedor;

            this.precio_neto_unit = producto_dte_compra.Ultima_compra;

            this.id_unidad_compra = producto_dte_compra.Id_unidad_compra;
            this.nom_unidad_compra = producto_dte_compra.Nom_unidad_compra;

            this.cant_comp = producto_dte_compra.Cant_comp;
            this.cant_vta = producto_dte_compra.Cant_vta;

            if (this.cant_comp == 0)
                this.cant_comp = 1;
            if (this.cant_vta == 0)
                this.cant_vta = 1;

            this.cantidad = 1;

            if (activar)
                this.ActivarReactividad();
        }

        private bool unidades_ya_cambiaron = false;
        /// <summary>
        /// Activa la funcion de actualizar los valores dependiendo de los cambios ellos
        /// en las propiedades, ademas realiza una actualizacion 
        /// </summary>
        public void ActivarReactividad()
        {
            this.permitirActualizarValores = true;
            this.ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            if (!this.permitirActualizarValores)
                return;

            this.precio_neto_linea = this.cantidad * this.precio_neto_unit;
            this.total_neto_c_desc = this.precio_neto_linea - (this.precio_neto_linea * Porcentaje_descuento_dividido_100);
            this.monto_desc_neto_linea = this.precio_neto_linea - this.total_neto_c_desc;
            //this.monto_desc_neto_unit = Formateador.Dividir(this.monto_desc_neto_linea, this.cantidad);

            this.OnTotalesActualizados(new EventArgs());
        }

        private void ActualizarTotalesDesdeDescNetoLinea()
        {
            if (!this.permitirActualizarValores)
                return;

            this.total_neto_c_desc = this.precio_neto_linea - this.monto_desc_neto_linea;
            this.desc_porcentaje = decimal.Round(Formateador.Dividir((this.total_neto_c_desc - this.precio_neto_linea), precio_neto_linea * -1) * 100, 4);

            this.ActualizarTotales();
        }

        public void RevertirCambioUnidades()
        {
            this.cantidad = Formateador.Dividir(this.cantidad, this.Relacion_de_cantidad_compra_sobre_venta);
            this.precio_neto_unit = this.precio_neto_unit * this.Relacion_de_cantidad_compra_sobre_venta;
        }

        public void CambioUnidades()
        {
            this.cantidad = this.cantidad * this.Relacion_de_cantidad_compra_sobre_venta;
            this.precio_neto_unit = Formateador.Dividir(this.precio_neto_unit, this.Relacion_de_cantidad_compra_sobre_venta);
            this.ActualizarTotales();
        }
        #region Eventos

        public event EventHandler TotalesActualizados;
        protected virtual void OnTotalesActualizados(EventArgs e)
        {
            EventHandler handler = TotalesActualizados;
            handler?.Invoke(this, e);
        }
        public delegate void TotalesActualizadosEventHandler(object sender, EventArgs e);

        #endregion
    }
}
