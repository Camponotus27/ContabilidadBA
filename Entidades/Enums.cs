using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public enum Sentencia
    {
        Select,
        InsertOrUpdate,
        Delete,
        Insert
    }

    public enum EstadoImportacion
    {
        SinEstado,
        Importado,
        SinImportar,
        Inconsistente
    }

    public enum DTESII
    {
        dte_sii
    }

    public enum BoolDB {
        S,
        N
    }
    public enum Origen
    {
        COMPRA,
        VENTA
    }

    public enum IngEgre
    {
        I,
        E,
        N
    }
    public enum CondVenta
    {
        NINGUNO,
        CONTADO,
        CREDITO
    }
    public enum PrecioNetoBruto
    {
        NETO,
        BRUTO
    }
    public enum CausaAnulacion
    {
        COMPLETA,
        PARCIAL,
        NINGUNO
    }
    public enum AjusteMargenPrecio
    {
        MntMargenAjusPrecio,
        MantPrecioAjusMargen
    }
    public enum PrecioBaseParaCalculoPrecioVenta
    {
        PrecioUltimaCompra,
        CostoPromedio,
        Mayor
    }
    public enum NivelMargenCalculoPrecioVenta
    {
        N1,
        N2
    }
    public enum TipoBusqueda{
        Minimizada,
        Completa
    }
    public enum Ambiente
    {
        CERTIFICACION,
        PRODUCCION
    }
    public enum EstadoOrdenCompra
    {
        GENERADA,
        MODIFICADA,
        TERMINADA
    }
    public class Enums
    {
        public static BoolDB ToBoolDB(object item)
        {
            if(item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a BoolDB");

            string item_str = item.ToString();
            if (item_str == "N")
                return BoolDB.N;
            else if (item_str == "S")
                return BoolDB.S;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a BoolDB");
        }

        internal static string ToString(IngEgre tipo)
        {
            if (tipo == IngEgre.E)
                return "EGRESO";
            else if (tipo == IngEgre.I)
                return "INGRESO";
            else
                return "INDEFINIDO";
        }

        public static bool BoolDBToBool(BoolDB b)
        {
            return b == BoolDB.S;
        }

        public static BoolDB BoolToBoolDB(bool b)
        {
            if (b)
                return BoolDB.S;
            else
                return BoolDB.N;
        }

        public static IngEgre ToIngEgre(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a IngEgre");

            string item_str = item.ToString();
            if (item_str == "E")
                return IngEgre.E;
            else if (item_str == "I")
                return IngEgre.I;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a IngEgre");
        }

        public static CondVenta ToCondVenta(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a ToCondVenta");

            string item_str = item.ToString();
            if (item_str == "CONTADO")
                return CondVenta.CONTADO;
            else if (item_str == "CREDITO")
                return CondVenta.CREDITO;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a ToCondVenta");
        }

        internal static AjusteMargenPrecio ToAjusteMargenPrecio(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a AjusteMargenPrecio");

            string item_str = item.ToString();
            if (item_str == "MantPrecioAjusMargen")
                return AjusteMargenPrecio.MantPrecioAjusMargen;
            else if (item_str == "MntMargenAjusPrecio")
                return AjusteMargenPrecio.MntMargenAjusPrecio;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a AjusteMargenPrecio");
        }

        internal static PrecioBaseParaCalculoPrecioVenta ToPrecioBaseParaCalculoPrecioVenta(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a PrecioBaseParaCalculoPrecioVenta");

            string item_str = item.ToString();
            if (item_str == "CostoPromedio")
                return PrecioBaseParaCalculoPrecioVenta.CostoPromedio;
            else if (item_str == "Mayor")
                return PrecioBaseParaCalculoPrecioVenta.Mayor;
            else if (item_str == "PrecioUltimaCompra")
                return PrecioBaseParaCalculoPrecioVenta.PrecioUltimaCompra;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a PrecioBaseParaCalculoPrecioVenta");
        }

        internal static NivelMargenCalculoPrecioVenta ToNivelMargenCalculoPrecioVenta(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a NivelMargenCalculoPrecioVenta");

            string item_str = item.ToString();
            if (item_str == "N1")
                return NivelMargenCalculoPrecioVenta.N1;
            else if (item_str == "N2")
                return NivelMargenCalculoPrecioVenta.N2;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a NivelMargenCalculoPrecioVenta");
        }

        internal static CausaAnulacion ToCausaAnulacion(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a CausaAnulacion");

            string item_str = item.ToString();
            if (item_str == "COMPLETA")
                return CausaAnulacion.COMPLETA;
            else if (item_str == "PARCIAL")
                return CausaAnulacion.PARCIAL;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a CausaAnulacion");
        }

        internal static Ambiente ToAmbiente(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a Ambiente");

            string item_str = item.ToString();
            if (item_str == "CERTIFICACION")
                return Ambiente.CERTIFICACION;
            else if (item_str == "PRODUCCION")
                return Ambiente.PRODUCCION;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a Ambiente");
        }

        internal static DTESII ToDTESII(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a DTESII");

            string item_str = item.ToString();
            if (item_str == "dte_sii")
                return DTESII.dte_sii;
            /*else if (item_str == "PRODUCCION")
                return Ambiente.PRODUCCION;*/
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a DTESII");
        }
        internal static EstadoOrdenCompra ToEstadoOrdenCompra(object item)
        {
            if (item == null)
                throw new Exception("El valor de entrada es nulo, no se puede convertir a EstadoOrdenCompra");

            string item_str = item.ToString();
            if (item_str == "GENERADA")
                return EstadoOrdenCompra.GENERADA;
            else if (item_str == "MODIFICADA")
                return EstadoOrdenCompra.MODIFICADA;
            else if (item_str == "TERMINADA")
                return EstadoOrdenCompra.TERMINADA;
            else
                throw new Exception("El valor de entrada no es valido, no se puede convertir a EstadoOrdenCompra");
        }

        #region Emuns sin uso en la DB
        // por el momento esta vacio
        #endregion

    }
}
