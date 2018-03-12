﻿namespace Bus
{
    partial class Plages
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
            this.periodSelector = new Bus.PeriodSelector();
            this.SuspendLayout();
            // 
            // periodSelector
            // 
            this.periodSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.periodSelector.Begin = System.TimeSpan.Parse("00:00:00");
            this.periodSelector.End = System.TimeSpan.Parse("00:00:00");
            this.periodSelector.Location = new System.Drawing.Point(0, 0);
            this.periodSelector.Name = "periodSelector";
            this.periodSelector.Size = new System.Drawing.Size(380, 254);
            this.periodSelector.TabIndex = 0;
            // 
            // Plages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.periodSelector);
            this.Name = "Plages";
            this.Size = new System.Drawing.Size(380, 373);
            this.ResumeLayout(false);

        }

        #endregion

        private PeriodSelector periodSelector;
    }
}
