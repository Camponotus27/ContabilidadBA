using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDicStringString
    {
        string key;
        string value;

        public string Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }

        public EDicStringString()
        {

        }

        public EDicStringString(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
