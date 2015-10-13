namespace tcpMainService
{
    partial class projectInstaller
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

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcpMasterProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.tcpMasterInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // tcpMasterProcessInstaller
            // 
            this.tcpMasterProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.tcpMasterProcessInstaller.Password = null;
            this.tcpMasterProcessInstaller.Username = null;
            // 
            // tcpMasterInstaller
            // 
            this.tcpMasterInstaller.Description = "a TCP control program";
            this.tcpMasterInstaller.DisplayName = "TCP master Service";
            this.tcpMasterInstaller.ServiceName = "tcpMaster";
            this.tcpMasterInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.tcpProcessInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.tcpMasterProcessInstaller,
            this.tcpMasterInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller tcpMasterProcessInstaller;
        private System.ServiceProcess.ServiceInstaller tcpMasterInstaller;
    }
}