using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Herramientas
{
    public class HHTML
    {
        public static string getNumeroS(string innerHtml)
        {
            return getNumero(innerHtml).ToString();
        }

        public static decimal getNumero(string innerHtml)
        {
            decimal res = 0;
            innerHtml = innerHtml.Replace("$", "");

            innerHtml = Regex.Replace(innerHtml, "[^0-9,]", "", RegexOptions.None);

            innerHtml = innerHtml.Trim();

            if(decimal.TryParse(innerHtml, out res))
            {

            }
            else
            {
                res = 0;
            }

            return res;
        }

        /// <summary>
        /// Solo sirve para sacar el rango de tramos del los indicadores
        /// </summary>
        /// <param name="innerHtml"></param>
        /// <returns></returns>
        public static Dictionary<string, decimal> getTramoNumero(string innerHtml)
        {
            //string nombre_cantidad = "Renta";

            decimal res1 = 0;
            decimal res2 = 0;
            //innerHtml = innerHtml.Replace(nombre_cantidad, "X");

            innerHtml = innerHtml.Replace("$", "");
            innerHtml = innerHtml.Replace(" ", "");

            innerHtml = Regex.Replace(innerHtml, "[^0-9,><]", "", RegexOptions.None);

            innerHtml = innerHtml.Trim();

            if (innerHtml.Substring(0, 1) == "<")
                innerHtml = ">0" + innerHtml;

            string[] resul = innerHtml.Split(new char[] {'<','>' });

            if (decimal.TryParse(resul[1], out res1))
            {

            }
            else
            {
                res1 = 0;
            }

           if(resul.Length >= 3)
            {
                if (decimal.TryParse(resul[2], out res2))
                {

                }
                else
                {
                    res2 = 0;
                }
            }
            else
            {
                res2 = decimal.MaxValue;
            }

            return new Dictionary<string, decimal>() {
                ["minimo"] = res1,
                ["maximo"] = res2
            };
        }
    }
}
