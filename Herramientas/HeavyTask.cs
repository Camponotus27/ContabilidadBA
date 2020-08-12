using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Herramientas
{
    public class HeavyTask
    {
        private bool HeavyProcessStopped;

        // Expone el contexto de sincronización en la clase entera 
        private readonly SynchronizationContext SyncContext;

        private Res respuesta;

        public Res Res {
            get
            {
                if (respuesta == null)
                    this.respuesta = new Res();

                return respuesta;
            } set => respuesta = value; }

        // Crear los 2 contenedores de callbacks
        public event EventHandler<Res> Callback1;
        public event EventHandler<Res> Callback2;

        // Constructor de la clase HeavyTask
        public HeavyTask()
        {
            // Importante actualizar el valor de SyncContext en el constructor con
            // el valor de SynchronizationContext del AsyncOperationManager
            SyncContext = AsyncOperationManager.SynchronizationContext;
        }

        // Método para iniciar el proceso
        public void Start()
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }

        // Método para detener el proceso
        public void Stop()
        {
            HeavyProcessStopped = true;
            this.SyncContext.OperationCompleted();
        }

        // Método donde la lógica principal de tu tarea se ejecuta
        private void Run()
        {
            while (!HeavyProcessStopped)
            {

                // Si el primer callback existe, ejecutarlo con la información dada
                // Callback1?.Invoke(this, response);
                

                SyncContext.Post(e => triggerCallback1(
                    this.Res
                ), null);

                SyncContext.Post(e => triggerCallback2(
                   this.Res
               ), null);

                // La tarea heavy task finaliza, así que hay que detenerla.
                Stop();
            }
        }


        // Métodos que ejecutan los callback si y solo si fueron declarados durante la instanciación de la clase HeavyTask
        private void triggerCallback1(Res response)
        {
            // Si el primer callback existe, ejecutarlo con la información dada
            Callback1?.Invoke(this, response);
        }

        private void triggerCallback2(Res response)
        {
            // Si el segundo callback existe, ejecutarlo con la información dada
            Callback2?.Invoke(this, response);
        }
    }
}
