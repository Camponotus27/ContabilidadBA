using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    class Async
    {
      BackgroundWorker BW = new BackgroundWorker();

        public Async()
        {
            this.BW = new BackgroundWorker();
            this.BW.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            this.BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
