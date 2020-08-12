using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EGenerica : Entidad
    {
        //
        List<EMae_Doc_Tributarios> doc_tributarios;
        public List<EMae_Doc_Tributarios> Doc_tributarios { get => doc_tributarios; set => doc_tributarios = value; }

        List<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado> doc_trib_tipo_trasl_equipo_cod_dte_tipo_traspado;
        public List<ERel_Documento_Tributario_Tipo_Traslado_Equipo_CodDTE_TipoTraslado> DocTribTipoTraslEquipoCodDteTipoTraspado { get => doc_trib_tipo_trasl_equipo_cod_dte_tipo_traspado; set => doc_trib_tipo_trasl_equipo_cod_dte_tipo_traspado = value; }
    }
}
