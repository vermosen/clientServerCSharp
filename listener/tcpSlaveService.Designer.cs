﻿namespace listener
{
    partial class tcpSlave
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
            this.eventLogger = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogger)).BeginInit();
            // 
            // eventLogger
            // 
            this.eventLogger.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLogger_EntryWritten);
            // 
            // tcpSlave
            // 
            this.ServiceName = "tcpSlave";
            ((System.ComponentModel.ISupportInitialize)(this.eventLogger)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog eventLogger;

    }
}
