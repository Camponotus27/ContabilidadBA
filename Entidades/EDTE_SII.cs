using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDTE_SII : Entidad
    {
        string trackid_dte;
        string rut_emisor;
        DTESII origen;
        string estado_dte;
        string estado_general_dte;
        string descripcion_estado_general_dte;


        public string Trackid_dte { get => trackid_dte; set => trackid_dte = value; }
        public string Rut_emisor { get => rut_emisor; set => rut_emisor = value; }
        public DTESII Origen { get => origen; set => origen = value; }
        public string Estado_dte { get => estado_dte; set => estado_dte = value; }
        public string Estado_general_dte { get => estado_general_dte; set => estado_general_dte = value; }
        public string Descripcion_estado_general_dte { get => descripcion_estado_general_dte; set => descripcion_estado_general_dte = value; }
    }
}
