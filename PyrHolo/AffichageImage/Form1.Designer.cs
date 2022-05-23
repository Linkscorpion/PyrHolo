namespace AffichageImage
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btOuvrir = new System.Windows.Forms.Button();
            this.dlOpFile = new System.Windows.Forms.OpenFileDialog();
            this.dlOpFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOuvrir
            // 
            this.btOuvrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOuvrir.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOuvrir.ForeColor = System.Drawing.Color.White;
            this.btOuvrir.Image = global::AffichageImage.Properties.Resources.bg_button;
            this.btOuvrir.Location = new System.Drawing.Point(100, 43);
            this.btOuvrir.Margin = new System.Windows.Forms.Padding(0);
            this.btOuvrir.Name = "btOuvrir";
            this.btOuvrir.Size = new System.Drawing.Size(425, 148);
            this.btOuvrir.TabIndex = 0;
            this.btOuvrir.Text = "Ouvrir Image";
            this.btOuvrir.UseVisualStyleBackColor = true;
            this.btOuvrir.Click += new System.EventHandler(this.btOuvrir_Click);
            // 
            // dlOpFile
            // 
            this.dlOpFile.FileName = "openFileDialog1";
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btStart.BackgroundImage = global::AffichageImage.Properties.Resources.bg_button;
            this.btStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btStart.FlatAppearance.BorderSize = 0;
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStart.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStart.ForeColor = System.Drawing.Color.White;
            this.btStart.Image = global::AffichageImage.Properties.Resources.bg_button;
            this.btStart.Location = new System.Drawing.Point(100, 268);
            this.btStart.Margin = new System.Windows.Forms.Padding(0);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(425, 51);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Démarrer";
            this.btStart.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AffichageImage.Properties.Resources.bg_main;
            this.ClientSize = new System.Drawing.Size(656, 397);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btOuvrir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pyramide Holographique";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOuvrir;
        private System.Windows.Forms.OpenFileDialog dlOpFile;
        private System.Windows.Forms.FolderBrowserDialog dlOpFolder;
        private System.Windows.Forms.Button btStart;
    }
}

