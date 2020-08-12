using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaConvenio
    {
        private bool _isAprobado;
        private bool _isError;

        private string _descripcionError;
        private string _descripcionDesapruebo;

        private int _saldoDisponible;

        public bool IsAprobado { get => _isAprobado; set => _isAprobado = value; }
        public bool IsError { get => _isError; set => _isError = value; }
        public string DescripcionError { get => _descripcionError; set => _descripcionError = value; }
        public int SaldoDisponible { get => _saldoDisponible; set => _saldoDisponible = value; }
        public string DescripcionDesapruebo { get => _descripcionDesapruebo; set => _descripcionDesapruebo = value; }

        public RespuestaConvenio()
        {
            this.IsAprobado = false;
            this.IsError = false;
            this.DescripcionDesapruebo = "";
        }
    }
}
