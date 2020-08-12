using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class Cronometro
    {
        //TimeSpan stop;
        TimeSpan start;

        public Cronometro(bool iniciar = true)
        {
            if (iniciar)
                this.Iniciar();
        }

        public void Iniciar()
        {
            this.start = new TimeSpan(DateTime.Now.Ticks);
        }

        public double Detener()
        {
            TimeSpan stop = new TimeSpan(DateTime.Now.Ticks);
            return stop.Subtract(start).TotalMilliseconds;
        }

        public void ImprimirDetener(string fragmento_codigo)
        {
            TimeSpan stop = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine("CRONOMETRO: " + fragmento_codigo + " se demoro " + stop.Subtract(start).TotalMilliseconds + "ms");
        }
    }
}
