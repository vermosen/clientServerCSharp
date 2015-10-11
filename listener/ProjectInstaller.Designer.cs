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
            this.tcpListenerProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.tcpListenerInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // tcpListenerProcessInstaller
            // 
            this.tcpListenerProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.tcpListenerProcessInstaller.Password = null;
            this.tcpListenerProcessInstaller.Username = null;
            // 
            // tcpListenerInstaller
            // 
            this.tcpListenerInstaller.Description = "a tcp listening service";
            this.tcpListenerInstaller.DisplayName = "My super TCP listener";
            this.tcpListenerInstaller.ServiceName = "tcpListener";
            this.tcpListenerInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // projectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.tcpListenerProcessInstaller,
            this.tcpListenerInstaller});
            this.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.ProjectInstaller_AfterInstall);

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller tcpListenerProcessInstaller;
        private System.ServiceProcess.ServiceInstaller tcpListenerInstaller;
    }
}