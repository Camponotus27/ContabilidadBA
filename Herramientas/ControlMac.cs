using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class ControlMac
    {
        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                sMacAddress = adapter.GetPhysicalAddress().ToString();

                if (!string.IsNullOrEmpty(sMacAddress))
                    return sMacAddress;

                /*
                if (sMacAddress == String.Empty)// solo devuelve la mac de la primera tarjeta
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    return sMacAddress;
                }*/
            }

            return sMacAddress;
        }

        public static string GetMACAddressOrBuscar(String sMacAddress)
        {
            if (sMacAddress == string.Empty)
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// solo devuelve la mac de la primera tarjeta
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                        return sMacAddress;
                    }
                }
            }

            return sMacAddress;
        }
    }
}
