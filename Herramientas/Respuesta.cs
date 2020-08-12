using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class Res
    {
        private bool _isCorrecto = false;
        private bool _isError = false;
        private bool _isImpresion = false;
        private string _descripcionError = "";
        private object respuesta;
        private string mensaje;

        private string MENSAJE_SUCCESS = "SUCCESS";

        private int _id;
        private string contexto;

        public Res()
        {

        }

        public Res(string contexto)
        {
            this.contexto = contexto;
        }

        public bool IsImpresion { get => _isImpresion; set => _isImpresion = value; }
        public int Id { get => _id; set => _id = value; }
        public bool IsCorrecto
        {
            get { return _isCorrecto; }

            set
            {
                _isCorrecto = value;
                _isError = !value;
            }
        }
        public bool IsError
        {
            get => _isError;
            set
            {
                _isError = value;
                _isCorrecto = !value;
            }
        }
        public string DescripcionError
        {
            get
            {
                if (_descripcionError != "")
                {
                    return _descripcionError;
                }
                else
                {
                    return "error desconocido";
                }
            }
            set {
                _descripcionError = value;
                if (value == "Colección modificada; puede que no se ejecute la operación de enumeración.")
                {

                }
               }
        }

        public object Respuesta { get => respuesta; set => respuesta = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }

        /// <summary>
        /// Formatea la respuesta a un datatable si es posible
        /// </summary>
        /// <returns>Obtiene un objeto DataTable desde una respuesta que puede ser un datatable o un dataset</returns>
        public DataTable ObtenerResultadoDT(int indice = 0)
        {
            if (!this.IsCorrecto)
            {
                throw new Exception("No se puede obtener resultado si la respuesta no fue correcta");
            }

            if (this.Respuesta is DataSet)
            {
                DataSet data_set = (DataSet)this.Respuesta;
                if (data_set.Tables.Count > indice)
                {
                    return data_set.Tables[indice];
                }
                else
                {
                    throw new Exception("El dataset no tiene la tabla " + indice);
                }

            }
            else if (this.Respuesta is DataTable)
            {
                return (DataTable)this.Respuesta;
            }
            else
            {
                throw new Exception("No se puede obtener resultado, la respuesta no es un dataset o datatable");
            }

            return new DataTable();
        }


        Exception Ex;
        public void Error(Exception ex)
        {
            this.Ex = ex;
            this.Error(Formateador.BuscarErrorSignificativo(ex));
        }

        /// <summary>
        /// Mandar un error instantaeo generado a travez del mensaje y el contxto creado previamente y como respuesta se manda a si mismo con la informacion
        /// </summary>
        /// <param name="error">Error a mandar</param>
        /// <returns>Se manda a si mismo, o sea un objeto tipo respuesta con el error</returns>
        public Res ErrorContexto(string error)
        {
            this.Error(this.contexto + ": " + error);

            if (string.IsNullOrEmpty(this.contexto))
            {
                Interacciones.Ex("Se intento generar un error de contexto con el contexto vacio, esto no aportaria nada paa esta funcionalidad, añade contexto primero o no uses esta opcion y usa el el metodo de 'Error' normal");
            }

            return this;
        }

        public void cargarRespuesta(Res res)
        {
            this.IsCorrecto = res.IsCorrecto;

            this.Respuesta = res.respuesta;
            this.Id = res.Id;
            this.Mensaje = res.Mensaje;

            if (this.IsError)
            {
                if (res.DescripcionError != "error desconocido")
                    this._descripcionError += res.DescripcionError;
            }
        }

        public void addError(string nuevoError)
        {
            if (!this.IsError)
                this.Error();
            this._descripcionError += nuevoError;
        }

        public Res Correcto(int id)
        {
            this.Correcto();
            this.Id = id;
            return this;
        }

        public Res Correcto()
        {
            this.IsCorrecto = true;
            return this;
        }

        public Res Error()
        {
            this.IsError = true;
            return this;
        }

        public Res Error(string descricionError)
        {
            this.IsError = true;
            this.DescripcionError = descricionError;
            new LogWriter(descricionError);

            return this;
        }

        public void Correcto(string mensaje)
        {
            this.Mensaje = mensaje;
            this.Correcto();
        }

        public Res AddMensaje(string mensaje, string separador = " ")
        {
            this.Mensaje = this.Mensaje + separador + mensaje;
            return this;
        }

        public Res AddMensajeLista(string mensaje, string separador = "\n")
        {
            this.Mensaje = mensaje + separador + this.Mensaje;
            return this;
        }

        public Res AddMensajeAntesLista(string mensaje, string separador = "\n")
        {
            this.Mensaje = this.Mensaje + separador + mensaje;
            return this;
        }

        public void CargarRespuestaDesdeDB(DataSet data_set, string errores, string mensaje)
        {
            // declaran variabls
            string subStringErroresSuccess = string.Empty;
            string restoDelError = string.Empty;

            // si el largo es el adecuado se intentara sacar el mensaje que indica que la consulta esta correcto
            if (errores.Length >= this.MENSAJE_SUCCESS.Length)
            {
                subStringErroresSuccess = errores.Substring(0, this.MENSAJE_SUCCESS.Length);
                restoDelError = errores.Substring(this.MENSAJE_SUCCESS.Length);
            }

            // siempre se obtienen los posibles mensajes y resultados
            this.Mensaje = mensaje;
            this.Respuesta = data_set;

            if (subStringErroresSuccess == this.MENSAJE_SUCCESS)
                this.Correcto();
            else
                this.Error(errores);
        }

    }

    public class Res<T> : Res
    {
        private T respuesta;
        public new T Respuesta { get => respuesta; set => respuesta = value; }
    }
}
