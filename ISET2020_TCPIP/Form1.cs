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

        #region Mode Debug

        delegate void RenvoiVersInserer(string sTexte);
        private void InsererItemThread(string sTexte)
        {
            Thread ThreadInsererItem = new Thread(new ParameterizedThreadStart(InsererItem));
            ThreadInsererItem.Start(sTexte);
        }

        private void InsererItem(object oTexte)
        {
            if (lbEchanges.InvokeRequired)
            {
                RenvoiVersInserer f = new RenvoiVersInserer(InsererItem);
                Invoke(f, new object[] { (string) oTexte });
            }
            else
            {
                lbEchanges.Items.Insert(0, (string)oTexte);
            }

        }

        #endregion

        private Socket MonServeur, MonClient;
        private int DrapeauSocket = 0; //1 pour serveur tcp (socket) et 2 pour le client tcp
        private byte[] MonBuffer = new byte[256];

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

        private async Task EcouterUDP()
        {
            mcListenerClient_Ecouter.Enabled = mcListenerClient_Connecter.Enabled = false;
            string Donnees;
            byte[] tabOctets;
            IPAddress IPLocal = Utilitaires.Verifier(tServeur.Text);
            IPEndPoint IPEP = new IPEndPoint(IPLocal, 8000);
            UdpClient MonServeur = new UdpClient(8000);
            lbEchanges.Items.Add("UDP prêt à recevoir des données de " + IPEP.ToString());
            tabOctets = MonServeur.Receive(ref IPEP); // Fonction bloquante
            Donnees = Encoding.ASCII.GetString(tabOctets, 0, tabOctets.Length);
            lbEchanges.Items.Add("Données reçues : ");
            lbEchanges.Items.Add(Donnees);
            lbEchanges.Items.Add("Fermeture serveur");
            MonServeur.Close();
            mcListenerClient_Ecouter.Enabled = mcListenerClient_Connecter.Enabled = true;
        }

        private async void mcUDP_Ecouter_Click(object sender, EventArgs e)
        {
            await EcouterUDP();

        }

        private void mcUDP_Connecter_Click(object sender, EventArgs e)
        {
            mcListenerClient_Connecter.Enabled = mcListenerClient_Ecouter.Enabled = false;
            IPAddress IPServeur = Utilitaires.Verifier(tServeur.Text);
            UdpClient MonClient = new UdpClient();
            MonClient.Connect(IPServeur, 8000);
            lbEchanges.Items.Add("Client connecté à " + IPServeur.ToString() + ":8000");
            byte[] tabOctets = Encoding.ASCII.GetBytes(tMessage.Text);
            MonClient.Send(tabOctets, tabOctets.Length);
            lbEchanges.Items.Add("Message envoyé");
            lbEchanges.Items.Add(tMessage.Text);
            lbEchanges.Items.Add("fermeture de la connexion");
            MonClient.Close();
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

        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            MonClient.Send(Encoding.Unicode.GetBytes(tMessage.Text));
        }

        private void mcSocket_Ecouter_Click(object sender, EventArgs e)
        {
            mcSocket_Ecouter.Enabled = mcSocket_Connecter.Enabled = false;
            mcSocket_Deconnecter.Enabled = true;
            DrapeauSocket = 1;
            MonClient = null;
            IPAddress IPServeur = AdresseValide(Dns.GetHostName());
            MonServeur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MonServeur.Bind(new IPEndPoint(IPServeur, 8000));
            MonServeur.Listen(1);
            MonServeur.BeginAccept(new AsyncCallback(SurDemandeConnexion), MonServeur);
        }

        public void SurDemandeConnexion(IAsyncResult iar)
        {
            if (DrapeauSocket == 1)
            {
              Socket tmp = (Socket)iar.AsyncState;
              MonClient = tmp.EndAccept(iar);
              MonClient.Send(Encoding.Unicode.GetBytes("Connexion acceptée"));
              InsererItemThread("Connexion effectuée par " + ((IPEndPoint)MonClient.RemoteEndPoint).Address.ToString());
                //lbEchanges.Items.Insert(0, "Connexion effectuée par " +((IPEndPoint) MonClient.RemoteEndPoint).Address.ToString());
                InitialiserReception(MonClient);
            }
        }

        public void InitialiserReception(Socket soc)
        {
            soc.BeginReceive(MonBuffer, 0, MonBuffer.Length, SocketFlags.None, new AsyncCallback(Reception), soc);
            Array.Clear(MonBuffer, 0, MonBuffer.Length);
        }

        private void mcSocket_Connecter_Click(object sender, EventArgs e)
        {
            if (tServeur.Text.Length > 0)
            {
                mcSocket_Ecouter.Enabled = mcSocket_Connecter.Enabled = false;
                mcSocket_Deconnecter.Enabled = true;
                DrapeauSocket = 2;
                MonClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                MonClient.Blocking = false;
                IPAddress IPserveur = AdresseValide(tServeur.Text);
                MonClient.BeginConnect(new IPEndPoint(IPserveur, 8000), new AsyncCallback(SurConnexion), MonClient);
            }
            else
            {
                MessageBox.Show("Renseigner le serveur");
            }
        }

        public void SurConnexion(IAsyncResult iar)
        {
            Socket tmp = (Socket)iar.AsyncState;

            if (tmp.Connected)
            {
                InitialiserReception(tmp);
            }
            else
            {
                MessageBox.Show("Serveur inaccessible");
            }
        }

        private void mcSocket_Deconnecter_Click(object sender, EventArgs e)
        {
            if (DrapeauSocket == 2)
            {
                MonClient.Send(Encoding.Unicode.GetBytes("Déconnexion (client)"));
                MonClient.Shutdown(SocketShutdown.Both);
                DrapeauSocket = 0;
                MonClient.BeginDisconnect(false, new AsyncCallback(DemandeConnexion), MonClient);
                mcSocket_Ecouter.Enabled = mcSocket_Connecter.Enabled = true;
                mcSocket_Deconnecter.Enabled = false;
            }
            else if(MonClient == null)
            {
                MonServeur.Close();
                DrapeauSocket = 0;
                mcSocket_Ecouter.Enabled = mcSocket_Connecter.Enabled = true;
                mcSocket_Deconnecter.Enabled = false;
            }
            else
            {
                MessageBox.Show("Client connecté = pas de déconnexion");
            }
        }

        public void DemandeConnexion(IAsyncResult iar)
        {
            Socket tmp = (Socket) iar.AsyncState;
            tmp.EndDisconnect(iar);
        }

        public void Reception(IAsyncResult iar)
        {
            if (DrapeauSocket > 0)
            {
                Socket tmp = (Socket) iar.AsyncState;
                int recu = tmp.EndReceive(iar);

                if (recu > 0)
                {
                    InsererItemThread(Encoding.Unicode.GetString(MonBuffer));
                    //lbEchanges.Items.Insert(0, Encoding.Unicode.GetString(MonBuffer));
                    InitialiserReception(tmp);

                    Array.Clear(MonBuffer, 0, MonBuffer.Length);
                }
                else
                {
                    tmp.Disconnect(true);
                    tmp.Close();
                    MonServeur.BeginAccept(new AsyncCallback(SurDemandeConnexion), MonServeur);
                    MonClient = null;
                }
            }
        }

    }
}