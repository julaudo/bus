using Bus.Config;
using Bus.Tray;
using Bus.Util;
using System.Drawing;
using System.Windows.Forms;

namespace Bus
{
    public partial class MainForm : Form
    {

        private TrayIcon icon;


        public MainForm()
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle(new Bitmap(Bus.Properties.Resources.Icon, System.Windows.Forms.SystemInformation.IconSize).GetHicon());
            icon = new TrayIcon(this.notifications1);
            notifications1.TrayIcon = icon;


            Configuration.Load();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            icon.Destroy();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void notificationTime_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void secondsBetweenNotifications_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void verificationInterval_ValueChanged(object sender, System.EventArgs e)
        {

        }
    }
}
