namespace Ordinateur_Ventes
{
    partial class VoitureVentesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoitureVentesForm));
            this.informationClientGroupBox = new System.Windows.Forms.GroupBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.nomLabel = new System.Windows.Forms.Label();
            this.VenteGroupBox = new System.Windows.Forms.GroupBox();
            this.ordinateursComboBox = new System.Windows.Forms.ComboBox();
            this.vendeurComboBox = new System.Windows.Forms.ComboBox();
            this.totalPrixSaisieLabel = new System.Windows.Forms.Label();
            this.PrixSaisieLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.prixLabel = new System.Windows.Forms.Label();
            this.ordinateurLabel = new System.Windows.Forms.Label();
            this.vendeurLabel = new System.Windows.Forms.Label();
            this.transactionMenuStrip = new System.Windows.Forms.MenuStrip();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordinateurPictureBox = new System.Windows.Forms.PictureBox();
            this.informationClientGroupBox.SuspendLayout();
            this.VenteGroupBox.SuspendLayout();
            this.transactionMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordinateurPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // informationClientGroupBox
            // 
            this.informationClientGroupBox.Controls.Add(this.dateTextBox);
            this.informationClientGroupBox.Controls.Add(this.nomTextBox);
            this.informationClientGroupBox.Controls.Add(this.dateLabel);
            this.informationClientGroupBox.Controls.Add(this.nomLabel);
            this.informationClientGroupBox.Location = new System.Drawing.Point(44, 351);
            this.informationClientGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.informationClientGroupBox.Name = "informationClientGroupBox";
            this.informationClientGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.informationClientGroupBox.Size = new System.Drawing.Size(575, 160);
            this.informationClientGroupBox.TabIndex = 2;
            this.informationClientGroupBox.TabStop = false;
            this.informationClientGroupBox.Text = "Information du client";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(111, 96);
            this.dateTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(408, 22);
            this.dateTextBox.TabIndex = 3;
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(111, 44);
            this.nomTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(408, 22);
            this.nomTextBox.TabIndex = 2;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(29, 105);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(36, 16);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Date";
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(25, 48);
            this.nomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(36, 16);
            this.nomLabel.TabIndex = 0;
            this.nomLabel.Text = "Nom";
            // 
            // VenteGroupBox
            // 
            this.VenteGroupBox.Controls.Add(this.ordinateursComboBox);
            this.VenteGroupBox.Controls.Add(this.vendeurComboBox);
            this.VenteGroupBox.Controls.Add(this.totalPrixSaisieLabel);
            this.VenteGroupBox.Controls.Add(this.PrixSaisieLabel);
            this.VenteGroupBox.Controls.Add(this.totalLabel);
            this.VenteGroupBox.Controls.Add(this.prixLabel);
            this.VenteGroupBox.Controls.Add(this.ordinateurLabel);
            this.VenteGroupBox.Controls.Add(this.vendeurLabel);
            this.VenteGroupBox.Location = new System.Drawing.Point(44, 540);
            this.VenteGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VenteGroupBox.Name = "VenteGroupBox";
            this.VenteGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VenteGroupBox.Size = new System.Drawing.Size(569, 238);
            this.VenteGroupBox.TabIndex = 3;
            this.VenteGroupBox.TabStop = false;
            this.VenteGroupBox.Text = "Vente";
            // 
            // ordinateursComboBox
            // 
            this.ordinateursComboBox.FormattingEnabled = true;
            this.ordinateursComboBox.Location = new System.Drawing.Point(141, 89);
            this.ordinateursComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordinateursComboBox.Name = "ordinateursComboBox";
            this.ordinateursComboBox.Size = new System.Drawing.Size(332, 24);
            this.ordinateursComboBox.TabIndex = 13;
            // 
            // vendeurComboBox
            // 
            this.vendeurComboBox.FormattingEnabled = true;
            this.vendeurComboBox.Location = new System.Drawing.Point(141, 44);
            this.vendeurComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vendeurComboBox.Name = "vendeurComboBox";
            this.vendeurComboBox.Size = new System.Drawing.Size(332, 24);
            this.vendeurComboBox.TabIndex = 12;
            // 
            // totalPrixSaisieLabel
            // 
            this.totalPrixSaisieLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.totalPrixSaisieLabel.Location = new System.Drawing.Point(141, 183);
            this.totalPrixSaisieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPrixSaisieLabel.Name = "totalPrixSaisieLabel";
            this.totalPrixSaisieLabel.Size = new System.Drawing.Size(224, 30);
            this.totalPrixSaisieLabel.TabIndex = 11;
            // 
            // PrixSaisieLabel
            // 
            this.PrixSaisieLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PrixSaisieLabel.Location = new System.Drawing.Point(141, 137);
            this.PrixSaisieLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PrixSaisieLabel.Name = "PrixSaisieLabel";
            this.PrixSaisieLabel.Size = new System.Drawing.Size(224, 30);
            this.PrixSaisieLabel.TabIndex = 10;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(29, 183);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(38, 16);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Total";
            // 
            // prixLabel
            // 
            this.prixLabel.AutoSize = true;
            this.prixLabel.Location = new System.Drawing.Point(29, 138);
            this.prixLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prixLabel.Name = "prixLabel";
            this.prixLabel.Size = new System.Drawing.Size(29, 16);
            this.prixLabel.TabIndex = 8;
            this.prixLabel.Text = "Prix";
            // 
            // ordinateurLabel
            // 
            this.ordinateurLabel.AutoSize = true;
            this.ordinateurLabel.Location = new System.Drawing.Point(29, 92);
            this.ordinateurLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ordinateurLabel.Name = "ordinateurLabel";
            this.ordinateurLabel.Size = new System.Drawing.Size(69, 16);
            this.ordinateurLabel.TabIndex = 5;
            this.ordinateurLabel.Text = "Ordinateur";
            // 
            // vendeurLabel
            // 
            this.vendeurLabel.AutoSize = true;
            this.vendeurLabel.Location = new System.Drawing.Point(29, 48);
            this.vendeurLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vendeurLabel.Name = "vendeurLabel";
            this.vendeurLabel.Size = new System.Drawing.Size(58, 16);
            this.vendeurLabel.TabIndex = 4;
            this.vendeurLabel.Text = "Vendeur";
            // 
            // transactionMenuStrip
            // 
            this.transactionMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.transactionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem});
            this.transactionMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.transactionMenuStrip.Name = "transactionMenuStrip";
            this.transactionMenuStrip.Size = new System.Drawing.Size(659, 30);
            this.transactionMenuStrip.TabIndex = 4;
            this.transactionMenuStrip.Text = "menuStrip1";
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerToolStripMenuItem,
            this.imprimerToolStripMenuItem});
            this.transactionToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enregistrerToolStripMenuItem.Image = global::Ordinateur_Ventes.Properties.Resources.save_48px;
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.enregistrerToolStripMenuItem.Text = "Enregistrer";
            // 
            // imprimerToolStripMenuItem
            // 
            this.imprimerToolStripMenuItem.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imprimerToolStripMenuItem.Image = global::Ordinateur_Ventes.Properties.Resources.print_48px;
            this.imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
            this.imprimerToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.imprimerToolStripMenuItem.Text = "Imprimer";
            // 
            // ordinateurPictureBox
            // 
            this.ordinateurPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ordinateurPictureBox.Image")));
            this.ordinateurPictureBox.Location = new System.Drawing.Point(49, 64);
            this.ordinateurPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordinateurPictureBox.Name = "ordinateurPictureBox";
            this.ordinateurPictureBox.Size = new System.Drawing.Size(559, 240);
            this.ordinateurPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ordinateurPictureBox.TabIndex = 0;
            this.ordinateurPictureBox.TabStop = false;
            // 
            // VoitureVentesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 815);
            this.Controls.Add(this.VenteGroupBox);
            this.Controls.Add(this.informationClientGroupBox);
            this.Controls.Add(this.ordinateurPictureBox);
            this.Controls.Add(this.transactionMenuStrip);
            this.MainMenuStrip = this.transactionMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VoitureVentesForm";
            this.Text = "Voiture - Ventes";
            this.Load += new System.EventHandler(this.VoitureVentesForm_Load);
            this.informationClientGroupBox.ResumeLayout(false);
            this.informationClientGroupBox.PerformLayout();
            this.VenteGroupBox.ResumeLayout(false);
            this.VenteGroupBox.PerformLayout();
            this.transactionMenuStrip.ResumeLayout(false);
            this.transactionMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordinateurPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ordinateurPictureBox;
        private System.Windows.Forms.GroupBox informationClientGroupBox;
        private System.Windows.Forms.GroupBox VenteGroupBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label ordinateurLabel;
        private System.Windows.Forms.Label vendeurLabel;
        private System.Windows.Forms.MenuStrip transactionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimerToolStripMenuItem;
        private System.Windows.Forms.Label PrixSaisieLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label prixLabel;
        private System.Windows.Forms.ComboBox vendeurComboBox;
        private System.Windows.Forms.Label totalPrixSaisieLabel;
        private System.Windows.Forms.ComboBox ordinateursComboBox;
    }
}

