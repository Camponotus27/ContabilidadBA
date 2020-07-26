using dBASE.NET;
using System;

namespace Importador_Contable_BA
{
    public class OpenOfficeApp
    {
        public OpenOfficeApp()
        {
            Dbf dbf = new Dbf();
            dbf.Read(@"C:\Users\Seba\source\repos\Importador Contable BA\Datos Git\contajvh\APARAM.DBF");

            foreach (DbfRecord record in dbf.Records)
            {
                for (int i = 0; i < dbf.Fields.Count; i++)
                {
                    Console.WriteLine(record[i]);
                }
            }
        }
    }
}