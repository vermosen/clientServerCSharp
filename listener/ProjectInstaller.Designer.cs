namespace listener
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
            this.tcpSlaveProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.tcpSlaveInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // tcpSlaveProcessInstaller
            // 
            this.tcpSlaveProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.tcpSlaveProcessInstaller.Password = null;
            this.tcpSlaveProcessInstaller.Username = null;
            this.tcpSlaveProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.tcpSlaveProcessInstaller_AfterInstall);
            // 
            // tcpSlaveInstaller
            // 
            this.tcpSlaveInstaller.Description = "a tcp listening service";
            this.tcpSlaveInstaller.DisplayName = "TCP slave service";
            this.tcpSlaveInstaller.ServiceName = "tcpSlave";
            // 
            // projectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.tcpSlaveProcessInstaller,
            this.tcpSlaveInstaller});
            this.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.projectInstaller_AfterInstall);

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller tcpSlaveProcessInstaller;
        private System.ServiceProcess.ServiceInstaller tcpSlaveInstaller;
    }
}