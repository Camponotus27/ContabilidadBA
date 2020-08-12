using Entidades;
using Herramientas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Importador_Contable_BA
{
    public class AppSettings
    {
        List<EPath_Excel> path_excel;
        public List<EPath_Excel> Path_excel { get => path_excel; set => path_excel = value; }

        private const string DEFAULT_FILENAME = "settings.xml";

        

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
            using (var writer = XmlWriter.Create(fileName))
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


            var serializer = new XmlSerializer(typeof(AppSettings));
            using (var reader = XmlReader.Create(fileName))
            {
                AppSettings setting = (AppSettings)serializer.Deserialize(reader);

                this.CargarSetingEnSiMismo(setting);
            }
        }

        private void CargarSetingEnSiMismo(AppSettings setting)
        {
            this.Path_excel = setting.Path_excel;
        }
    }
}
