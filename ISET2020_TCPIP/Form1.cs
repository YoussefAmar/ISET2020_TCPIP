using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ISET2020_TCPIP
{
    public partial class EcranPrincipal : Form
    {
        public EcranPrincipal()
        {
            InitializeComponent();
            
        }

        private IPAddress AdresseValide(string nPC)
        {
            IPAddress ipReponse = null;

            if (nPC.Length > 0)
            {
                IPAddress[] IPServeur = Dns.GetHostEntry(nPC).AddressList;

                for (int i = 0; i < IPServeur.Length; i++)
                {
                    Ping pingServeur = new Ping();
                    PingReply pingReponse = pingServeur.Send(IPServeur[i]);

                    if(pingReponse.Status == IPStatus.Success)
                        if (IPServeur[i].AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipReponse = IPServeur[i];
                            break;
                        }

                }

            }

            return ipReponse;
        }

        private void muVerifier_Click(object sender, EventArgs e)
        {
            if (tServeur.Text.Length > 0)
            {
               IPAddress IPServeur = AdresseValide(tServeur.Text);

               if (IPServeur != null)
               {
                   MessageBox.Show("Ping réussi");
               }
               else
               {
                   MessageBox.Show("Pas de ping");
               }
            }
            else
            {
                MessageBox.Show("Renseigner le nom de la machine");
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mcListenerClient_Ecouter_Click(object sender, EventArgs e)
        {
            mcListenerClient_Ecouter.Enabled = mcListenerClient_Connecter.Enabled = false;

            IPAddress ipLocal = AdresseValide(Dns.GetHostName());
            TcpListener lcServeur = new TcpListener(ipLocal, 8000);
            lcServeur.Start();
            TcpClient lcClient = lcServeur.AcceptTcpClient();
            NetworkStream flux = lcClient.GetStream();
            BinaryWriter bw = new BinaryWriter(flux);
            bw.Write("Connexion initialisée");
            BinaryReader br = new BinaryReader(flux);
            lbEchanges.Items.Insert(0, br.ReadString());
            bw.Write("Ordre de déconnexion");
            lbEchanges.Items.Insert(0, br.ReadString());
            lcClient.Close();
            lcServeur.Stop();

            mcListenerClient_Ecouter.Enabled = mcListenerClient_Connecter.Enabled = true;
        }

        private void mcListenerClient_Connecter_Click(object sender, EventArgs e)
        {
            mcListenerClient_Ecouter.Enabled = mcListenerClient_Connecter.Enabled = false;

            IPAddress ipServeur = AdresseValide(tServeur.Text);
            TcpClient lcClient = new TcpClient();
            lcClient.Connect(ipServeur, 8000);
            NetworkStream flux = lcClient.GetStream();
            BinaryReader br = new BinaryReader(flux);
            lbEchanges.Items.Insert(0, br.ReadString());
            BinaryWriter bw = new BinaryWriter(flux);
            bw.Write("Machine " + AdresseValide(Dns.GetHostName()).ToString() + " connectée");
            lbEchanges.Items.Insert(0, br.ReadString());
            bw.Write("Déconnexion effectuée");
            lcClient.Close();

            mcListenerClient_Ecouter.Enabled = mcListenerClient_Connecter.Enabled = true;
        }
    }
}
