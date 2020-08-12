using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Es una clase con solo algunas propiedades de un dte, no refleja su estructura, se usa mas que nada para mostrar datos
    /// </summary>
    public class EDTE_Min : Entidad
    {
        uint id;
        uint id_emp;
        uint tipo;
        uint folio;
        DateTime fecha_documento;
        DateTime fecha_vencimiento;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Tipo { get => tipo; set => tipo = value; }
        public uint Folio { get => folio; set => folio = value; }
        public DateTime Fecha_documento { get => fecha_documento; set => fecha_documento = value; }
        public DateTime Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
    }
}
