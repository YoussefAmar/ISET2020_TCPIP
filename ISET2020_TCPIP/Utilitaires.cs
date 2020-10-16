using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //pour traiter adresses IP
using System.Net.NetworkInformation; //pour avoir le Ping

namespace ISET2020_TCPIP
{
    class Utilitaires
    {
        public static IPAddress Verifier(string sAdresse)
        {
            IPAddress rep = null;
            if (sAdresse.Trim().Length > 0)
            {
                IPAddress[] ipVerifs = Dns.GetHostEntry(sAdresse).AddressList;

                for (int i = 0; i < ipVerifs.Length; i++)
                {
                    if (ipVerifs[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //vérif si l'IP est une IPV4
                        if(ipVerifs[i] != new IPAddress(0x0100007f)) //différent de IP LOCALHOST
                        {
                            Ping pVerif = new Ping();
                            PingReply pRepon = pVerif.Send(ipVerifs[i]);
                            if (pRepon.Status == IPStatus.Success)
                            {
                                rep = ipVerifs[i];
                                break; //permet de chopper la 1ere correct et puis de sortir de la boucle
                            }
                        }
                }

            }

            return rep;
        }
    }
}
