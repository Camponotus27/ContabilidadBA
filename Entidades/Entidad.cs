using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Entidades
{
    /*
    interface Validacion
    {
        List<ReglaValidacion> ReglasValidacion();
    }

    public class ReglaValidacion
    {
        string nombre_campo;
        List<TipoValidacion> tipoValidacion;

        public string Nombre_campo { get => nombre_campo; set => nombre_campo = value; }
        public List<TipoValidacion> TipoValidacion { get => tipoValidacion; set => tipoValidacion = value; }
    }

    public enum TipoValidacion
    {
        Unico,
        Requerido
    }*/

    [Serializable()]
    public class Entidad : ICloneable
    {
     

        /// <summary>
        /// Convierte la clase en un string XML
        /// </summary>
        /// <returns>string de XML</returns>
        public string XML()
        {
            XmlSerializer x = new XmlSerializer(this.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }

        public object Clone()
        {
            return Formateador.Copia(this);
        }

        /// <summary>
        /// Transforma un listado de clases heredadas a una clase base, perdera las propiedades extras que tenga la calse extendida
        /// </summary>
        /// <typeparam name="H">Tipo de la clase objetivo, es el tipo de clase base que se quiere obtener</typeparam>
        /// <typeparam name="P">Tipo de la clase que heredo a al tipo de la clase padre</typeparam>
        /// <param name="clase_extendida">Listado de la clase extendida que se quiere transformar al tipo base</param>
        /// <returns>Liitado de la clase base, las propiedas extras de la place extendida se pierden</returns>
        public static List<H> PoblarListDesdeListObjeto<H, P>(List<P> clase_extendida)
        where H : class
        {
            List<H> list = new List<H>();

            foreach(P padre_obj in clase_extendida)
            {
                list.Add(PoblarDesdeUnObjeto<H, P>( padre_obj));
            }

            return list;
        }

        public static H PoblarDesdeUnObjeto<H, P>(P padre)
        where H : class
        {
            Type tipo_hijo = typeof(H);
            H objetoHijo = (H)Activator.CreateInstance(tipo_hijo);

            Type tipo_padre = padre.GetType();
            P objetoPadre = (P)Activator.CreateInstance(tipo_padre);

            PropertyInfo[] properties_hijo = tipo_hijo.GetProperties();
            PropertyInfo[] properties_padre = tipo_padre.GetProperties();
            foreach (PropertyInfo p in properties_hijo)
            {
                string nombre_parametro = p.Name;
                try
                {
                    PropertyInfo p_hijo = ContieneParametro(properties_padre, nombre_parametro);
                    if (p_hijo != null && p.PropertyType == p_hijo.PropertyType)
                    {
                        p.SetValue(objetoHijo, p_hijo.GetValue(padre), null);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return objetoHijo;
        }

        public static bool ObtenerRutYDvDesdeString(string rut_string, out uint rut, out string dv)
        {
            rut = 0;
            dv = string.Empty;

            if (rut_string == null)
                return false;

            rut_string = rut_string.Replace(".", "");

            if (rut_string.Contains("-"))
            {
                string[] rut_spit = rut_string.Split('-');

                if(rut_spit.Length > 0)
                    rut_string = rut_spit[0];

                if (rut_spit.Length > 1)
                    dv = rut_spit[1];
            }

            if (uint.TryParse(rut_string, out uint rut_uint))
                rut = rut_uint;

            if (dv.Length > 1)
                dv = dv.Substring(0, 1);

            dv = dv.ToUpper();

            if (rut == 0 || string.IsNullOrEmpty(dv)) // faltaria su es distitno a 1-9 o K
                return false;

            return true;
        }

        private static PropertyInfo ContieneParametro(PropertyInfo[] properties, string nombre_parametro)
        {
            foreach(PropertyInfo p in properties)
            {
                if (p.Name == nombre_parametro)
                    return p;
            }
            return null;
        }




        /// <summary>
        /// Devuelve una lista de objetos de tipo solicitado poblado desde un DataTable
        /// </summary>
        /// <typeparam name="T">>Tipo solicitado de respuesta</typeparam>
        /// <param name="dt">Datatable para poblar</param>
        /// <returns></returns>
        public static BindingList<T> PoblarDesdeDataDataTable<T>(DataTable dt)
        where T : class
        {
            BindingList<T> list = new BindingList<T>();

            foreach(DataRow row in dt.Rows)
            {
                list.Add(Entidad.PoblarDesdeDataRow<T>(row));
            }

            return list;

        }
        /// <summary>
        /// Devuelve un objeto de tipo solicitado poblado desde un DataTable, seleciona la primera fila
        /// </summary>
        /// <typeparam name="T">>Tipo solicitado de respuesta</typeparam>
        /// <param name="dt">Datatable para poblar</param>
        /// <returns></returns>
        public static T PoblarUnoDesdeDataDataTable<T>(DataTable dt)
        where T : class
        {
            if(dt.Rows.Count > 0)
            {
                return Entidad.PoblarDesdeDataRow<T>(dt.Rows[0]);
            }

            return null;
        }
        /// <summary>
        /// Devuelve un objeto de tipo solicitado poblado desde un DataRow
        /// </summary>
        /// <typeparam name="T">Tipo solicitado de respuesta</typeparam>
        /// <param name="row">DataRow para poblar</param>
        /// <returns></returns>
        public static T PoblarDesdeDataRow<T>(DataRow row)
        where T : class
        {
            Type type = typeof(T);
            T result = (T)Activator.CreateInstance(type);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                string nombre_parametro = p.Name;

                nombre_parametro = nombre_parametro.ToLower();

                object item_respaldo = "No asignado";
                try
                {
                    if (row.Table.Columns.Contains(nombre_parametro))
                    {
                        object item = row[nombre_parametro];

                        item_respaldo = item;

                        if (p.PropertyType == typeof(BoolDB))
                        {
                            item = Enums.ToBoolDB(item);
                        }else if(p.PropertyType == typeof(IngEgre))
                        {
                            item = Enums.ToIngEgre(item);
                        }else if (p.PropertyType == typeof(CondVenta))
                        {
                            item = Enums.ToCondVenta(item);
                        }else if(p.PropertyType == typeof(AjusteMargenPrecio))
                        {
                            item = Enums.ToAjusteMargenPrecio(item);
                        }else if(p.PropertyType == typeof(PrecioBaseParaCalculoPrecioVenta))
                        {
                            item = Enums.ToPrecioBaseParaCalculoPrecioVenta(item);
                        }else if(p.PropertyType == typeof(NivelMargenCalculoPrecioVenta))
                        {
                            item = Enums.ToNivelMargenCalculoPrecioVenta(item);
                        }else if (p.PropertyType == typeof(CausaAnulacion))
                        {
                            item = Enums.ToCausaAnulacion(item);
                        }else if (p.PropertyType == typeof(Ambiente))
                        {
                            item = Enums.ToAmbiente(item);
                        }
                        else if (p.PropertyType == typeof(DTESII))
                        {
                            item = Enums.ToDTESII(item);
                        }
                        else if (p.PropertyType == typeof(EstadoOrdenCompra))
                        {
                            item = Enums.ToEstadoOrdenCompra(item);
                        }
                        else if (p.PropertyType == typeof(uint))
                        {
                            item = Formateador.ToUInt32(item);
                        }
                        else if (p.PropertyType == typeof(int))
                        {
                            item = Formateador.ToInt32(item);
                        }else if(p.PropertyType == typeof(decimal))
                        {
                            item = Formateador.ToDecimal(item);
                        }else if(p.PropertyType == typeof(string))
                        {
                            item = Formateador.ToString(item);
                        }
                        else if (p.PropertyType == typeof(DateTime?))
                        {
                            item = Formateador.ToDateTime(item);
                        }


                        p.SetValue(result, item, null);

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Clase: " + type.Name + " Propiedad: " + nombre_parametro);
                    Console.WriteLine("Tipo desde la db: " + item_respaldo.GetType() + " valor: " + item_respaldo);
                    Console.WriteLine("Tipo desde la Clase: " + p);
                    Console.WriteLine(ex.Message);
                }

            }

            return result;
        }

        public static void PoblarUnoDesdeDataDataTable<T>(DataTable dataTable, T model)
        {

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];


                Type type = typeof(T);

                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    string nombre_parametro = p.Name;

                    nombre_parametro = nombre_parametro.ToLower();

                    try
                    {
                        if (row.Table.Columns.Contains(nombre_parametro))
                        {
                            object item = row[nombre_parametro];

                            if (p.PropertyType == typeof(BoolDB))
                            {
                                item = Enums.ToBoolDB(item);
                            }

                            p.SetValue(model, item, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

           
        }

        public static bool ValidaRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                if(
                    dv == '0'
                    || dv == '1'
                    || dv == '2'
                    || dv == '3'
                    || dv == '4'
                    || dv == '5'
                    || dv == '6'
                    || dv == '7'
                    || dv == '8'
                    || dv == '9'
                    || dv == 'K'
                    )
                {
                    
                }
                else
                {
                    return false;
                }

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}
