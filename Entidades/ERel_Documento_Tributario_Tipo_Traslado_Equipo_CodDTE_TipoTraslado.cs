using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado : ERel_Documento_Tributario_Tipo_Traslado_Equipo
    {
        uint cod;
        string nom_docsii;
        uint tipo_traslado_bienes;
        string nombre_traslado_bienes;

        public uint Cod { get => cod; set => cod = value; }
        public uint Tipo_traslado_bienes { get => tipo_traslado_bienes; set => tipo_traslado_bienes = value; }
        public string Nombre_traslado_bienes { get => nombre_traslado_bienes; set => nombre_traslado_bienes = value; }
        public string Nom_docsii { get => nom_docsii; set => nom_docsii = value; }
        public string Nom_Completo {
            get
            {
                string nombre = nom_docsii;

                if (!string.IsNullOrEmpty(nombre_traslado_bienes))
                    nombre = nombre + " " + nombre_traslado_bienes;

                return nombre;
            }
        }
    }
}
