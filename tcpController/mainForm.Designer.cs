namespace tcpController
{
    partial class mainForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.serverIPBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.activityNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 162);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(251, 55);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(264, 162);
            this.abortButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(248, 55);
            this.abortButton.TabIndex = 1;
            this.abortButton.Text = "abort";
            this.abortButton.UseVisualStyleBackColor = true;
            // 
            // serverIPBox
            // 
            this.serverIPBox.Location = new System.Drawing.Point(12, 38);
            this.serverIPBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serverIPBox.Name = "serverIPBox";
            this.serverIPBox.Size = new System.Drawing.Size(500, 31);
            this.serverIPBox.TabIndex = 2;
            this.serverIPBox.Text = "127.0.0.1:12438";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "activity Name";
            // 
            // activityNameBox
            // 
            this.activityNameBox.Location = new System.Drawing.Point(12, 111);
            this.activityNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activityNameBox.Name = "activityNameBox";
            this.activityNameBox.Size = new System.Drawing.Size(500, 31);
            this.activityNameBox.TabIndex = 4;
            this.activityNameBox.Text = "simpleTask.exe";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 229);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.activityNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverIPBox);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.TextBox serverIPBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox activityNameBox;
    }
}

