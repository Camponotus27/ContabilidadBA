using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ERel_Documento_Tributario_Tipo_Traslado_Equipo : Entidad
    {
        uint id;
        uint id_equipo;
        uint id_doc_tributario_tipo_traslado_bienes;
        string impresora;

        public uint Id { get => id; set => id = value; }
        public uint Id_equipo { get => id_equipo; set => id_equipo = value; }
        public string Impresora { get => impresora; set => impresora = value; }
        public uint Id_doc_tributario_tipo_traslado_bienes { get => id_doc_tributario_tipo_traslado_bienes; set => id_doc_tributario_tipo_traslado_bienes = value; }
    }
}
