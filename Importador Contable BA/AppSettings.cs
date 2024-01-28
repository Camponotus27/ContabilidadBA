using Entidades;
using Herramientas;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Importador_Contable_BA
{
    public class AppSettings
    {
        private List<EPath_Excel> path_excel;
        public List<EPath_Excel> Path_excel { get => path_excel; set => path_excel = value; }
        public string Path_aplicacion_contable { get; set; }
        public int Rut_empresa { get; set; }

        private const string DEFAULT_FILENAME = "settings.xml";



        public void Save(string fileName = DEFAULT_FILENAME)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                serializer.Serialize(writer, this);
            }

        }

        public void Load(string fileName = DEFAULT_FILENAME)
        {
            if (!File.Exists(fileName))
            {
                Interacciones.MessajeBoxAviso("No se encontro una configuracion que cargar, si es primera vez que abre la aplicacion ignore este mensaje");
                return;
            }


            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                AppSettings setting = (AppSettings)serializer.Deserialize(reader);

                CargarSetingEnSiMismo(setting);
            }
        }

        private void CargarSetingEnSiMismo(AppSettings setting)
        {
            Path_excel = setting.Path_excel;
            Rut_empresa = setting.Rut_empresa;
            Path_aplicacion_contable = setting.Path_aplicacion_contable;
        }
    }
}
