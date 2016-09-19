namespace Bus
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNotifications = new System.Windows.Forms.TabPage();
            this.notifications1 = new Bus.Notifications();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.verificationInterval = new System.Windows.Forms.NumericUpDown();
            this.secondsBetweenNotifications = new System.Windows.Forms.NumericUpDown();
            this.notificationTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plages1 = new Bus.Plages();
            this.tabControl1.SuspendLayout();
            this.tabPageNotifications.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verificationInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBetweenNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageNotifications);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 461);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageNotifications
            // 
            this.tabPageNotifications.Controls.Add(this.notifications1);
            this.tabPageNotifications.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotifications.Name = "tabPageNotifications";
            this.tabPageNotifications.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotifications.Size = new System.Drawing.Size(699, 435);
            this.tabPageNotifications.TabIndex = 0;
            this.tabPageNotifications.Text = "Alertes";
            this.tabPageNotifications.UseVisualStyleBackColor = true;
            // 
            // notifications1
            // 
            this.notifications1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notifications1.Favorites = ((System.Collections.Generic.List<Bus.Favorite>)(resources.GetObject("notifications1.Favorites")));
            this.notifications1.Location = new System.Drawing.Point(3, 3);
            this.notifications1.Name = "notifications1";
            this.notifications1.Size = new System.Drawing.Size(693, 429);
            this.notifications1.TabIndex = 0;
            this.notifications1.TrayIcon = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.verificationInterval);
            this.tabPage2.Controls.Add(this.secondsBetweenNotifications);
            this.tabPage2.Controls.Add(this.notificationTime);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.plages1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(699, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plages horaires";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "secondes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "secondes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "minutes avant le passage";
            // 
            // verificationInterval
            // 
            this.verificationInterval.Location = new System.Drawing.Point(224, 322);
            this.verificationInterval.Name = "verificationInterval";
            this.verificationInterval.Size = new System.Drawing.Size(60, 20);
            this.verificationInterval.TabIndex = 6;
            this.verificationInterval.ValueChanged += new System.EventHandler(this.verificationInterval_ValueChanged);
            // 
            // secondsBetweenNotifications
            // 
            this.secondsBetweenNotifications.Location = new System.Drawing.Point(224, 296);
            this.secondsBetweenNotifications.Name = "secondsBetweenNotifications";
            this.secondsBetweenNotifications.Size = new System.Drawing.Size(60, 20);
            this.secondsBetweenNotifications.TabIndex = 5;
            this.secondsBetweenNotifications.ValueChanged += new System.EventHandler(this.secondsBetweenNotifications_ValueChanged);
            // 
            // notificationTime
            // 
            this.notificationTime.Location = new System.Drawing.Point(224, 270);
            this.notificationTime.Name = "notificationTime";
            this.notificationTime.Size = new System.Drawing.Size(60, 20);
            this.notificationTime.TabIndex = 4;
            this.notificationTime.ValueChanged += new System.EventHandler(this.notificationTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Temps entre les vérifications :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temps avant de réafficher une notification :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Afficher une notification";
            // 
            // plages1
            // 
            this.plages1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plages1.Location = new System.Drawing.Point(0, 0);
            this.plages1.Name = "plages1";
            this.plages1.Size = new System.Drawing.Size(699, 264);
            this.plages1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 485);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Bus4Piscine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPageNotifications.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verificationInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBetweenNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPageNotifications;
        private Notifications notifications1;
        private Plages plages1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown verificationInterval;
        private System.Windows.Forms.NumericUpDown secondsBetweenNotifications;
        private System.Windows.Forms.NumericUpDown notificationTime;
    }
}