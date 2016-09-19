using Bus.Passages;
using Bus.Picto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Bus.Tray
{

    public class TrayIcon
    {
        static public uint NIM_MODIFY = 0x00000001;

        static public int NIF_MESSAGE = 0x1;
        static public int NIF_ICON = 0x2;
        static public int NIF_TIP = 0x4;
        static public int NIF_INFO = 0x10;

        static public int NIIF_NONE = 0x0;
        static public int NIIF_INFO = 0x1;
        static public int NIIF_WARNING = 0x2;
        static public int NIIF_ERROR = 0x3;
        static public int NIIF_USER = 0x4;
        static public int NIIF_LARGE_ICON = 0x20;

        [DllImport("shell32.dll")]
        static extern bool Shell_NotifyIcon(uint dwMessage, [In] ref NOTIFYICONDATA pnid);

        private static FieldInfo windowField = typeof(NotifyIcon).GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        private static FieldInfo idField = typeof(NotifyIcon).GetField("id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        private static IntPtr GetHandle(NotifyIcon icon)
        {
            NativeWindow window = windowField.GetValue(icon) as NativeWindow;
            return window.Handle;
        }

        private static int GetId(NotifyIcon icon)
        {
            return (int)idField.GetValue(icon);
        }

        private NotifyIcon icon;

        private Notifications parent;

        private ContextMenu menu;

        public TrayIcon(Notifications parent)
        {
            menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem("Quitter", parent.Form1_Quit));
            this.parent = parent;
            icon = new NotifyIcon()
            {
                Icon = Icon.FromHandle(new Bitmap(Bus.Properties.Resources.Icon, System.Windows.Forms.SystemInformation.SmallIconSize).GetHicon()),
                Visible = true
            };
            icon.DoubleClick += Icon_DoubleClick;
            icon.Click += Icon_Click;
            icon.ContextMenu = menu;
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                //parent.Notification();
            }
        }

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        private void Icon_DoubleClick(object sender, EventArgs e)
        {
            parent.ParentForm.Show();
            SetForegroundWindow(parent.Handle.ToInt32());
        }

        public void Destroy()
        {
            icon.Dispose();
        }

        public void Balloon(String title, String message, IntPtr hicon)
        {
            NOTIFYICONDATA data;

            data = new NOTIFYICONDATA();
            data.cbSize = Marshal.SizeOf(data);
            data.hwnd = GetHandle(icon);
            data.uFlags = NIF_INFO;
            data.dwInfoFlags = NIIF_USER | NIIF_LARGE_ICON;
            data.szInfo = message;
            data.szInfoTitle = title;
            data.uVersion = 0;
            data.uID = GetId(icon);
            data.hBalloonIcon = hicon;
            bool b = Shell_NotifyIcon(NIM_MODIFY, ref data);
        }

        private Dictionary<String, DateTime> lastCourseNotification = new Dictionary<string, DateTime>();

        public void Notification(String ligne, String arret, String direction, String destination, int? minutesMax)
        {
            Boolean notif = minutesMax == null;
            PassagesResult result = PassagesService.getPassages(ligne, arret, direction, 10);
            StringBuilder sb = new StringBuilder();
            if (result.records.Count > 0)
            {

                foreach (PassagesRecord record in result.records.OrderBy(o => o.fields.depart).ToList())
                {
                    long minutes = record.fields.depart.Subtract(DateTime.Now).Minutes;
                    if (sb.Length > 0)
                    {
                        sb.AppendLine();
                    }
                    else
                    {
                        DateTime dt;
                        if (lastCourseNotification.TryGetValue(record.fields.idcourse, out dt))
                        {
                            if (minutes <= minutesMax && dt != null && dt < DateTime.Now.AddMinutes(-1))
                            {
                                lastCourseNotification[record.fields.idcourse] = DateTime.Now;
                                notif = true;
                            }
                        } else
                        {
                            lastCourseNotification[record.fields.idcourse] = DateTime.Now;
                            notif = true;
                        }
                    }
                    sb.Append(minutes + " minutes (" + record.fields.depart.ToString("HH:mm:ss") + ")");
                }
            }
            else
            {
                sb.Append("Pas de passage dans l'heure");
            }
            if (notif)
            {
                
                Image img = PictoService.getPicto(ligne);
                Balloon("Direction " + destination, sb.ToString(), new Bitmap(img).GetHicon());
            }
        }
    }
}