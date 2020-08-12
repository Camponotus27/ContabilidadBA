using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace Herramientas
{
    public class HFTP : IDisposable
    {
        Session session;
        SessionOptions sessionOptions;
        string path_archivos_publicos = "https://libreriabunick.cl/wp-content/uploads";
        string path_remote_directorio_base = "/var/www/html/word_press/wp-content/uploads";

        public HFTP()
        {
            // Configuración de opciones de sesión
            sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = "170.239.85.146",
                PortNumber = 22222,
                UserName = "root",
                Password = "gNAoyFCw9z794F10oR",
                SshHostKeyFingerprint = "ssh-ed25519 255 qkQUYEBoEIEypW0Jf3I5Gixec9Su9Me/ls2f9ZPA3Jg=",
            };

            session = new Session();

            session.FileTransferProgress += Session_FileTransferProgress;

            // Conexión
            session.Open(sessionOptions);

        }

        #region Disposing
        private bool _disposed = false;
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                session?.Dispose();
            }

            _disposed = true;
        } 
        #endregion

        /// <summary>
        /// Sube un archivo al servidor, se necesita la path local y la remota
        /// </summary>
        /// <param name="path_local">full path local del archivo que se desea subir</param>
        /// <param name="path_remote">la remota solo la extencion final, la carpeta
        /// objetivo ya esta configurada</param>
        /// <returns>Retorna una respueta con el estado de la operacion, en el resultado se devuelta la full path remota</returns>
        public Res UploadFile(string path_local, string path_remote)
        {
            Res res = new Res();

            try
            {
                string path_remote_raiz_punto_final = path_remote_directorio_base + path_remote;
                string path_remote_full = "https://" + sessionOptions.HostName + path_remote_raiz_punto_final;


                if (session == null)
                    session = new Session();

                // Se sube el archivo
                TransferOperationResult transferResult = session.PutFiles(path_local, path_remote_raiz_punto_final);


                // causa una excepcion si existe un error
                transferResult.Check();

                // Print results
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    res.AddMensajeLista("Subida de " + transfer.FileName + " correcto");
                }

                res.Correcto();
                res.Respuesta = path_archivos_publicos + path_remote + Path.GetFileName(path_local);
            }
            catch (Exception ex)
            {
                res.Error(ex.Message);
            }


            return res;
        }

        public Res DeleteFile(string path_remote)
        {

            Res res = new Res();

            try
            {
                if (session == null)
                    session = new Session();

                // Se elimina el archivo
                RemovalEventArgs remov = session.RemoveFile(path_remote_directorio_base + "/" + path_remote);

                if (remov.Error != null)
                    return res.Error(remov.Error.Message);

                res.Correcto();
            }
            catch (Exception ex)
            {
                res.Error(ex.Message);
            }


            return res;
        }

        private void Session_FileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            Console.WriteLine("CPS: " + e.CPS + " Directory: " + e.Directory + " FileName: " + e.FileName + " FileProgress: " + e.FileProgress + " Operation: " + e.Operation + " Side: " + e.Side.ToString());
            //throw new NotImplementedException();
        }


    }
}
