using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    // la definicion de clases de los eventos, se tienen que declarar una por aca tipo de evento
    // se defienen aca por que se tiene que definir muchas (desde una fecha se empezaron a definir aca, por lo tanto no estan todas)

    public enum TipoChangue
    {
        Update,
        Delete,
        Insert,
        InsertOrUpdate
    }

    public class ChangeEntidadEventArgs<T> : EventArgs 
        where T : Entidad
    {
        T entidad;
        TipoChangue tipo_changue;

        public ChangeEntidadEventArgs(T entidad, TipoChangue tipo_changue)
        {
            this.entidad = entidad;
            this.tipo_changue = tipo_changue;
        }

        public T Entidad { get => entidad; set => entidad = value; }
        public TipoChangue TipoChangue { get => tipo_changue; set => tipo_changue = value; }
    }

    public class DatosCargadosEventArgs : EventArgs
    {
        DataTable dt;

        public DatosCargadosEventArgs() { }
        public DatosCargadosEventArgs(DataTable dt)
        {
            this.dt = dt;
        }

        public DataTable Dt { get => dt; set => dt = value; }
    }

    public interface IControlInicializador
    {
        bool Inicializado { get; }
        string Nombre { get; }

        event EventHandler DatosCargados;

        event EventHandler Inicializando;

        Form FindForm();
        void Reiniciar();
    }
}
