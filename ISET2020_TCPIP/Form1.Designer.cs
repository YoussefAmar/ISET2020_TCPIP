namespace ISET2020_TCPIP
{
    partial class EcranPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.mcListenerClient = new System.Windows.Forms.ToolStripMenuItem();
            this.mcListenerClient_Ecouter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcListenerClient_Connecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcUDP = new System.Windows.Forms.ToolStripMenuItem();
            this.mcUDP_Ecouter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcUDP_Connecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcSocket = new System.Windows.Forms.ToolStripMenuItem();
            this.mcSocket_Ecouter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcSocket_Connecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mcSocket_Deconnecter = new System.Windows.Forms.ToolStripMenuItem();
            this.mUtilitaire = new System.Windows.Forms.ToolStripMenuItem();
            this.muVerifier = new System.Windows.Forms.ToolStripMenuItem();
            this.mQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lServeur = new System.Windows.Forms.Label();
            this.tServeur = new System.Windows.Forms.TextBox();
            this.tMessage = new System.Windows.Forms.TextBox();
            this.lmessage = new System.Windows.Forms.Label();
            this.btnEnvoyer = new System.Windows.Forms.Button();
            this.lEchanges = new System.Windows.Forms.Label();
            this.lbEchanges = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCommunication,
            this.mUtilitaire,
            this.mQuitter});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mCommunication
            // 
            this.mCommunication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcListenerClient,
            this.mcUDP,
            this.mcSocket});
            this.mCommunication.Name = "mCommunication";
            this.mCommunication.Size = new System.Drawing.Size(154, 29);
            this.mCommunication.Text = "Communication";
            // 
            // mcListenerClient
            // 
            this.mcListenerClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcListenerClient_Ecouter,
            this.mcListenerClient_Connecter});
            this.mcListenerClient.Name = "mcListenerClient";
            this.mcListenerClient.Size = new System.Drawing.Size(270, 34);
            this.mcListenerClient.Text = "Listener / Client";
            // 
            // mcListenerClient_Ecouter
            // 
            this.mcListenerClient_Ecouter.Name = "mcListenerClient_Ecouter";
            this.mcListenerClient_Ecouter.Size = new System.Drawing.Size(270, 34);
            this.mcListenerClient_Ecouter.Text = "Ecouter";
            this.mcListenerClient_Ecouter.Click += new System.EventHandler(this.mcListenerClient_Ecouter_Click);
            // 
            // mcListenerClient_Connecter
            // 
            this.mcListenerClient_Connecter.Name = "mcListenerClient_Connecter";
            this.mcListenerClient_Connecter.Size = new System.Drawing.Size(270, 34);
            this.mcListenerClient_Connecter.Text = "Connecter";
            this.mcListenerClient_Connecter.Click += new System.EventHandler(this.mcListenerClient_Connecter_Click);
            // 
            // mcUDP
            // 
            this.mcUDP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcUDP_Ecouter,
            this.mcUDP_Connecter});
            this.mcUDP.Name = "mcUDP";
            this.mcUDP.Size = new System.Drawing.Size(270, 34);
            this.mcUDP.Text = "UDP";
            // 
            // mcUDP_Ecouter
            // 
            this.mcUDP_Ecouter.Name = "mcUDP_Ecouter";
            this.mcUDP_Ecouter.Size = new System.Drawing.Size(270, 34);
            this.mcUDP_Ecouter.Text = "Ecouter";
            this.mcUDP_Ecouter.Click += new System.EventHandler(this.mcUDP_Ecouter_Click);
            // 
            // mcUDP_Connecter
            // 
            this.mcUDP_Connecter.Name = "mcUDP_Connecter";
            this.mcUDP_Connecter.Size = new System.Drawing.Size(270, 34);
            this.mcUDP_Connecter.Text = "Connecter";
            this.mcUDP_Connecter.Click += new System.EventHandler(this.mcUDP_Connecter_Click);
            // 
            // mcSocket
            // 
            this.mcSocket.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcSocket_Ecouter,
            this.mcSocket_Connecter,
            this.mcSocket_Deconnecter});
            this.mcSocket.Name = "mcSocket";
            this.mcSocket.Size = new System.Drawing.Size(270, 34);
            this.mcSocket.Text = "Socket";
            // 
            // mcSocket_Ecouter
            // 
            this.mcSocket_Ecouter.Name = "mcSocket_Ecouter";
            this.mcSocket_Ecouter.Size = new System.Drawing.Size(213, 34);
            this.mcSocket_Ecouter.Text = "Ecouter";
            // 
            // mcSocket_Connecter
            // 
            this.mcSocket_Connecter.Name = "mcSocket_Connecter";
            this.mcSocket_Connecter.Size = new System.Drawing.Size(213, 34);
            this.mcSocket_Connecter.Text = "Connecter";
            // 
            // mcSocket_Deconnecter
            // 
            this.mcSocket_Deconnecter.Enabled = false;
            this.mcSocket_Deconnecter.Name = "mcSocket_Deconnecter";
            this.mcSocket_Deconnecter.Size = new System.Drawing.Size(213, 34);
            this.mcSocket_Deconnecter.Text = "Déconnecter";
            // 
            // mUtilitaire
            // 
            this.mUtilitaire.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muVerifier});
            this.mUtilitaire.Name = "mUtilitaire";
            this.mUtilitaire.Size = new System.Drawing.Size(92, 29);
            this.mUtilitaire.Text = "Utilitaire";
            // 
            // muVerifier
            // 
            this.muVerifier.Name = "muVerifier";
            this.muVerifier.Size = new System.Drawing.Size(168, 34);
            this.muVerifier.Text = "Vérifier";
            this.muVerifier.Click += new System.EventHandler(this.muVerifier_Click);
            // 
            // mQuitter
            // 
            this.mQuitter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem});
            this.mQuitter.Name = "mQuitter";
            this.mQuitter.Size = new System.Drawing.Size(83, 29);
            this.mQuitter.Text = "Quitter";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // lServeur
            // 
            this.lServeur.AutoSize = true;
            this.lServeur.Location = new System.Drawing.Point(13, 51);
            this.lServeur.Name = "lServeur";
            this.lServeur.Size = new System.Drawing.Size(64, 20);
            this.lServeur.TabIndex = 1;
            this.lServeur.Text = "Serveur";
            // 
            // tServeur
            // 
            this.tServeur.Location = new System.Drawing.Point(17, 75);
            this.tServeur.Name = "tServeur";
            this.tServeur.Size = new System.Drawing.Size(407, 26);
            this.tServeur.TabIndex = 2;
            this.tServeur.Text = "Youssef";
            // 
            // tMessage
            // 
            this.tMessage.Location = new System.Drawing.Point(16, 143);
            this.tMessage.Name = "tMessage";
            this.tMessage.Size = new System.Drawing.Size(407, 26);
            this.tMessage.TabIndex = 4;
            // 
            // lmessage
            // 
            this.lmessage.AutoSize = true;
            this.lmessage.Location = new System.Drawing.Point(12, 119);
            this.lmessage.Name = "lmessage";
            this.lmessage.Size = new System.Drawing.Size(74, 20);
            this.lmessage.TabIndex = 3;
            this.lmessage.Text = "Message";
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.Location = new System.Drawing.Point(16, 176);
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(407, 85);
            this.btnEnvoyer.TabIndex = 5;
            this.btnEnvoyer.Text = "Envoyer";
            this.btnEnvoyer.UseVisualStyleBackColor = true;
            this.btnEnvoyer.Click += new System.EventHandler(this.btnEnvoyer_Click);
            // 
            // lEchanges
            // 
            this.lEchanges.AutoSize = true;
            this.lEchanges.Location = new System.Drawing.Point(13, 274);
            this.lEchanges.Name = "lEchanges";
            this.lEchanges.Size = new System.Drawing.Size(81, 20);
            this.lEchanges.TabIndex = 6;
            this.lEchanges.Text = "Echanges";
            // 
            // lbEchanges
            // 
            this.lbEchanges.FormattingEnabled = true;
            this.lbEchanges.ItemHeight = 20;
            this.lbEchanges.Location = new System.Drawing.Point(17, 310);
            this.lbEchanges.Name = "lbEchanges";
            this.lbEchanges.Size = new System.Drawing.Size(407, 244);
            this.lbEchanges.TabIndex = 7;
            // 
            // EcranPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 617);
            this.Controls.Add(this.lbEchanges);
            this.Controls.Add(this.lEchanges);
            this.Controls.Add(this.btnEnvoyer);
            this.Controls.Add(this.tMessage);
            this.Controls.Add(this.lmessage);
            this.Controls.Add(this.tServeur);
            this.Controls.Add(this.lServeur);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranPrincipal";
            this.Text = "Exploration TCP/IP";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mCommunication;
        private System.Windows.Forms.ToolStripMenuItem mUtilitaire;
        private System.Windows.Forms.ToolStripMenuItem mQuitter;
        private System.Windows.Forms.ToolStripMenuItem mcListenerClient;
        private System.Windows.Forms.ToolStripMenuItem mcUDP;
        private System.Windows.Forms.ToolStripMenuItem mcSocket;
        private System.Windows.Forms.ToolStripMenuItem mcListenerClient_Ecouter;
        private System.Windows.Forms.ToolStripMenuItem mcListenerClient_Connecter;
        private System.Windows.Forms.ToolStripMenuItem mcSocket_Ecouter;
        private System.Windows.Forms.ToolStripMenuItem mcSocket_Connecter;
        private System.Windows.Forms.ToolStripMenuItem mcSocket_Deconnecter;
        private System.Windows.Forms.ToolStripMenuItem muVerifier;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mcUDP_Ecouter;
        private System.Windows.Forms.ToolStripMenuItem mcUDP_Connecter;
        private System.Windows.Forms.Label lServeur;
        private System.Windows.Forms.TextBox tServeur;
        private System.Windows.Forms.TextBox tMessage;
        private System.Windows.Forms.Label lmessage;
        private System.Windows.Forms.Button btnEnvoyer;
        private System.Windows.Forms.Label lEchanges;
        private System.Windows.Forms.ListBox lbEchanges;
    }
}

