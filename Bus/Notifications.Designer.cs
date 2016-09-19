using Bus.Controls;

namespace Bus
{
    partial class Notifications
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
            this.button1 = new System.Windows.Forms.Button();
            this.direction = new Bus.Controls.TransparentTrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelArret = new System.Windows.Forms.Label();
            this.comboArrets = new System.Windows.Forms.ComboBox();
            this.comboLignes = new System.Windows.Forms.ComboBox();
            this.sens1 = new System.Windows.Forms.Label();
            this.sens2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ligne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.arret = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.direct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewCorrespondances = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.direction)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // direction
            // 
            this.direction.BackColor = System.Drawing.SystemColors.Control;
            this.direction.Location = new System.Drawing.Point(186, 194);
            this.direction.Maximum = 1;
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(77, 45);
            this.direction.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ligne";
            // 
            // labelArret
            // 
            this.labelArret.AutoSize = true;
            this.labelArret.Location = new System.Drawing.Point(71, 61);
            this.labelArret.Name = "labelArret";
            this.labelArret.Size = new System.Drawing.Size(29, 13);
            this.labelArret.TabIndex = 5;
            this.labelArret.Text = "Arrêt";
            // 
            // comboArrets
            // 
            this.comboArrets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboArrets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboArrets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArrets.FormattingEnabled = true;
            this.comboArrets.IntegralHeight = false;
            this.comboArrets.ItemHeight = 33;
            this.comboArrets.Location = new System.Drawing.Point(106, 47);
            this.comboArrets.Name = "comboArrets";
            this.comboArrets.Size = new System.Drawing.Size(535, 39);
            this.comboArrets.TabIndex = 6;
            this.comboArrets.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboArrets_DrawItem);
            this.comboArrets.SelectedValueChanged += new System.EventHandler(this.comboArrets_SelectedValueChanged);
            // 
            // comboLignes
            // 
            this.comboLignes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLignes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboLignes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLignes.DropDownWidth = 300;
            this.comboLignes.FormattingEnabled = true;
            this.comboLignes.IntegralHeight = false;
            this.comboLignes.ItemHeight = 33;
            this.comboLignes.Location = new System.Drawing.Point(106, 3);
            this.comboLignes.Name = "comboLignes";
            this.comboLignes.Size = new System.Drawing.Size(454, 39);
            this.comboLignes.TabIndex = 7;
            this.comboLignes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboLignes_DrawItem);
            this.comboLignes.SelectedValueChanged += new System.EventHandler(this.comboLignes_SelectedValueChanged);
            // 
            // sens1
            // 
            this.sens1.Location = new System.Drawing.Point(12, 194);
            this.sens1.Name = "sens1";
            this.sens1.Size = new System.Drawing.Size(168, 45);
            this.sens1.TabIndex = 8;
            this.sens1.Text = "Depart";
            this.sens1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sens2
            // 
            this.sens2.Location = new System.Drawing.Point(269, 194);
            this.sens2.Name = "sens2";
            this.sens2.Size = new System.Drawing.Size(150, 45);
            this.sens2.TabIndex = 9;
            this.sens2.Text = "Arrivee";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ligne,
            this.arret,
            this.direct});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 245);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(640, 149);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ligne
            // 
            this.ligne.Text = "Ligne";
            this.ligne.Width = 40;
            // 
            // arret
            // 
            this.arret.Text = "Arrêt";
            this.arret.Width = 200;
            // 
            // direct
            // 
            this.direct.Text = "Direction";
            this.direct.Width = 200;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(566, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listViewCorrespondances
            // 
            this.listViewCorrespondances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCorrespondances.Location = new System.Drawing.Point(106, 92);
            this.listViewCorrespondances.Name = "listViewCorrespondances";
            this.listViewCorrespondances.Size = new System.Drawing.Size(535, 85);
            this.listViewCorrespondances.TabIndex = 12;
            this.listViewCorrespondances.UseCompatibleStateImageBehavior = false;
            this.listViewCorrespondances.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Correspondances";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewCorrespondances);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.sens2);
            this.Controls.Add(this.sens1);
            this.Controls.Add(this.comboLignes);
            this.Controls.Add(this.comboArrets);
            this.Controls.Add(this.labelArret);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.direction);
            this.Controls.Add(this.button1);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(664, 406);
            ((System.ComponentModel.ISupportInitialize)(this.direction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private TransparentTrackBar direction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelArret;
        private System.Windows.Forms.ComboBox comboArrets;
        private System.Windows.Forms.ComboBox comboLignes;
        private System.Windows.Forms.Label sens1;
        private System.Windows.Forms.Label sens2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ColumnHeader ligne;
        private System.Windows.Forms.ColumnHeader arret;
        private System.Windows.Forms.ColumnHeader direct;
        private System.Windows.Forms.ListView listViewCorrespondances;
        private System.Windows.Forms.Label label2;
    }
}

