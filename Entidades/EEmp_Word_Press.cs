using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEmp_Word_Press : Entidad
    {
        uint id_emp;

        // fechas o otro dato extra de estado
        DateTime import_fecha_clasificaciones;
        DateTime import_fecha_productos;

        // datos api wordpress
        BoolDB habilitada_api;
        string uri_api;
        string key_api;
        string secret_api;

        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public DateTime Import_fecha_clasificaciones { get => import_fecha_clasificaciones; set => import_fecha_clasificaciones = value; }
        public DateTime Import_fecha_productos { get => import_fecha_productos; set => import_fecha_productos = value; }
        public string Import_fecha_clasificaciones_texto { get => Formateador.DateToTextDB(import_fecha_clasificaciones); set { } }
        public string Import_fecha_productos_texto { get => Formateador.DateToTextDB(import_fecha_productos); set { } }

        public BoolDB Habilitada_api { get => habilitada_api; set => habilitada_api = value; }
        public string Uri_api { get => uri_api; set => uri_api = value; }
        public string Key_api { get => key_api; set => key_api = value; }
        public string Secret_api { get => secret_api; set => secret_api = value; }
    }
}
