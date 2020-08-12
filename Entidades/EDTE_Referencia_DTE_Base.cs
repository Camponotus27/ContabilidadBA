using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDTE_Referencia_DTE_Base : EDTE_Referencia
    {
        uint id;
        uint id_emp;
        uint tipo;
        uint folio;
        DateTime fecha_documento;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Tipo { get => tipo; set => tipo = value; }
        public uint Folio { get => folio; set => folio = value; }
        public DateTime Fecha_documento { get => fecha_documento; set => fecha_documento = value; }
        public string Fecha_documento_texto { get => Fecha_documento.ToString("yyyy-MM-dd"); }
        public int Causa_referencia_cod
        {
            get
            {
                /*
                1: Anula Documento de Referencia
                2: Corrige Texto Documento de Referencia
                3: Corrige montos*/

                if (this.Causa_referencia == CausaAnulacion.COMPLETA)
                    return 1;
                else if (this.Causa_referencia == CausaAnulacion.PARCIAL)
                    return 3;

                Interacciones.Ex("No se puede asignar un codigo de causa de referencia valido");
                return 0;
            }
        }
        /// <summary>
        /// Valida que la referencia tenga los valores basicos para poder imprimirla y usarla, como el folio tipo referencia, y la id
        /// </summary>
        /// <returns>Si es True es valida, False en otro caso</returns>
        public bool Validar()
        {
            if (this.tipo == 0)
                return false;
            else if (this.folio == 0)
                return false;
            else if (this.Id_movimiento_referencia == 0)
                return false;
            else if (this.Causa_referencia == CausaAnulacion.NINGUNO)
                return false;

            return true;
        }
    }
}
