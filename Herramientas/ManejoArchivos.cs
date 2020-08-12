using System;
using System.IO;

namespace Herramientas
{
    public class ManejoArchivos
    {
        public static bool IsFileLocked(string url)
        {
            FileStream fs = null;

            if (!File.Exists(url))
                return false;

            try
            {
                fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.None);
                //fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            //file is not locked
            return false;
        }

        public static RespuestaFileToBytes FileToBytes(string url)
        {
            RespuestaFileToBytes res = new RespuestaFileToBytes();
            //Extracion de documento firmado a bits
            Int64 Size;
            byte[] Bytes;
            FileStream fs;

            if (!File.Exists(url))
            {
                res.Error("No se pudo encontrar la url : " + url);
                return res;
            }

            try
            {
                fs = new FileStream(url, FileMode.Open, FileAccess.Read);
                Size = fs.Length;

                Bytes = new byte[Size];
                fs.Read(Bytes, 0, Convert.ToInt32(Size));
                fs.Close();

                res.Bytes = Bytes;
                res.Size = Size;
                res.Url = url;
                res.Nombre = Path.GetFileName(url);
                res.Correcto();
            }
            catch(Exception ex)
            {
                res.Error("Problemas conviertiendo el archivo " + url + " :" + ex.Message);
            }

            return res;
        }
        /// <summary>
        /// Guarda un archivo desde una respuestaFileYoByte, si encuentra el archivo lo copiara
        /// si no, creara uno nuevo desde la respuesta
        /// </summary>
        /// <param name="url_destino_sin_nombre"></param>
        /// <param name="resF"></param>
        /// <returns></returns>
        public static Res GuardarArchivoUrlSinNombre(string url_destino_sin_nombre, RespuestaFileToBytes resF)
        {
            string url_file_origen = resF.Url;
            string url_file_destino = Path.Combine(url_destino_sin_nombre, resF.Nombre);

            return GuardarArchivo(resF, url_file_origen, url_file_destino);
        }
        /// <summary>
        /// Guarda un archivo desde una respuestaFileYoByte, si encuentra el archivo lo copiara
        /// si no, creara uno nuevo desde la respuesta
        /// </summary>
        /// <param name="url_destino_con_nombre"></param>
        /// <param name="resF"></param>
        /// <returns></returns>
        public static Res GuardarArchivoUrlConNombre(string url_destino_con_nombre, RespuestaFileToBytes resF)
        {
    
            string url_file_origen = resF.Url;
            string url_file_destino = url_destino_con_nombre;

            return GuardarArchivo(resF, url_file_origen, url_file_destino);
        }
        public static Res GuardarArchivo(RespuestaFileToBytes resF, string url_file_origen, string url_file_destino)
        {

            Res res = new Res();
            if (resF.Bytes == null || resF.Bytes.Length == 0)
            {
                res.Error("No se proporciono una cadena de bytes para generar el archivo");
                return res;
            }

            if (string.IsNullOrEmpty(Path.GetFileName(url_file_destino)))
            {
                res.Error("No se proporciono una direccion de destino para el archivo");
                return res;
            }

            if (string.IsNullOrEmpty(resF.Nombre))
            {
                res.Error("No se proporciono un nombre al archivo");
                return res;
            }

            if (url_file_origen == url_file_destino)
            {
                res.Correcto("La direccion de origen y destino son iguales por lo que no se movio el archivo");
                return res;
            }

            // elimina el direccitorio si ya existe
            if (File.Exists(url_file_destino))
            {
                File.Delete(url_file_destino);
            }

            // crea la carpeta si no existe
            CrearCarpetaSiNoExiste(Path.GetDirectoryName(url_file_destino));

            // si existe el archivo de origen se moverá en vez de crear uno nuevo
            if (!string.IsNullOrEmpty(url_file_origen) && File.Exists(url_file_origen))
            {
                File.Move(url_file_origen, url_file_destino);

                res.Correcto();
            }
            // si no existe se creará el archivo desde la respuesta
            else
            {
                using (FileStream fs = new FileStream(url_file_destino, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(resF.Bytes, 0, resF.Bytes.Length);

                    res.Correcto();
                }
            }
            return res;
        }

        public static void EliminarCarpetaSiExiste(string url_carpeta)
        {
            if (Directory.Exists(url_carpeta))
                Directory.Delete(url_carpeta);
        }

        /// <summary>
        /// Limpia una path de simbolos que no son permitidos en una path
        /// </summary>
        /// <param name="path_con_simbolos_restringidos">path limpia</param>
        /// <returns></returns>
        public static string LimpiarPathSimbolosRestringidos(string path_con_simbolos_restringidos)
        {
            return string.Join("", path_con_simbolos_restringidos.Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Guarda un documento desde un objetio tipo archivo
        /// </summary>
        /// <param name="url_destino_sin_nombre">url de destino donde se guardara</param>
        /// <param name="archivo">el archivo que se desea guardar, debe tener si o si los bytes y el nombre del archivo</param>
        /// <returns></returns>
        public static Res GuardarArchivoUrlSinNombre(string url_destino_sin_nombre, Archivo archivo)
        {
            RespuestaFileToBytes resF = new RespuestaFileToBytes();
            resF.Bytes = archivo.Bytes;
            resF.Nombre = archivo.Nombre;
            resF.Size = archivo.Size;

            return GuardarArchivoUrlSinNombre(url_destino_sin_nombre, resF);
        }

        /// <summary>
        /// Guarda un documento desde un objetio tipo archivo
        /// </summary>
        /// <param name="url_destino_con_nombre">url de destino sonde se guardara</param>
        /// <param name="archivo">el archivo que se desea guardar, debe tener si o si los bytes y el nombre del archivo</param>
        /// <returns></returns>
        public static Res GuardarArchivoUrlConNombre(string url_destino_con_nombre, Archivo archivo)
        {
            RespuestaFileToBytes resF = new RespuestaFileToBytes();
            resF.Bytes = archivo.Bytes;
            resF.Nombre = archivo.Nombre;
            resF.Size = archivo.Size;

            return GuardarArchivoUrlConNombre(url_destino_con_nombre, resF);
        }

        /// <summary>
        /// Crea una carpeta de la url dada
        /// </summary>
        /// <param name="url">url que se creará la carpeta</param>
        /// <param name="isUrlUnaCarpeta"> Indida si la url dada es una carpeta o archivo para tratarla como tal</param>
        public static void CrearCarpetaSiNoExiste(string url, bool isUrlUnaCarpeta = true)
        {

            if (!isUrlUnaCarpeta)
                url = Path.GetDirectoryName(url);

            if (!Directory.Exists(url))
                Directory.CreateDirectory(url);

            /*
             
             // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(@"c:\Temp");

            if (attr.HasFlag(FileAttributes.Directory))
                MessageBox.Show("Its a directory");
            else
                MessageBox.Show("Its a file");

             */

        }

        public static void EliminarArchivoSiExiste(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// Mueve un archivo desde una direccion de origen a una de destino
        /// </summary>
        /// <param name="url_origen"></param>
        /// <param name="uri_destino"></param>
        public static void Mover(string url_origen, string url_destino)
        {
            if (!File.Exists(url_origen))
                Interacciones.Ex("No existe el archivo de origen");

            EliminarArchivoSiExiste(url_destino);
            CrearCarpetaSiNoExiste(url_destino, false);

            File.Move(url_origen, url_destino);
        }

        public static void Copiar(string url_origen, string url_destino)
        {
            if (!File.Exists(url_origen))
                Interacciones.Ex("No existe el archivo de origen");

            EliminarArchivoSiExiste(url_destino);
            CrearCarpetaSiNoExiste(url_destino, false);

            File.Copy(url_origen, url_destino);
        }
    }

    public class RespuestaFileToBytes : Res
    {
        private byte[] bytes;
        private Int64 size;
        private string url;
        private string nombre;

        public byte[] Bytes { get => bytes; set => bytes = value; }
        public Int64 Size { get => size; set => size = value; }
        public string Url { get => url; set => url = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }

    public class Archivo
    {
        private byte[] bytes;
        private Int64 size;
        private string url;
        private string nombre;

        public byte[] Bytes { get => bytes; set => bytes = value; }
        public Int64 Size { get => size; set => size = value; }
        public string Url { get => url; set => url = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }

}
