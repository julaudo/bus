using Bus.Config;
using Bus.Lignes;
using Bus.Picto;
using Bus.Tray;
using Bus.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace Bus
{
    public partial class Notifications : UserControl
    {
        public const string FILES_DIRECTORY = "files";

        Dictionary<String, int> lineIndex = new Dictionary<string, int>();
        Dictionary<String, Bitmap> comboBitmaps = new Dictionary<string, Bitmap>();

        public static Notifications Instance { get; set; }

        public TrayIcon TrayIcon { get; set; }

        private System.Timers.Timer timer = new System.Timers.Timer(5000);


        public Notifications()
        {
            Instance = this;
            System.IO.Directory.CreateDirectory(FILES_DIRECTORY);
            LignesService.Init();

            InitializeComponent();
            PictoService.LoadFilenames();
            var lignes = LignesService.GetLignes();
            String dir = Directory.GetCurrentDirectory();
            FormUtil.SetDoubleBuffered(comboLignes);
            FormUtil.SetDoubleBuffered(listViewCorrespondances);
            listView1.SmallImageList = new ImageList();
            listView1.SmallImageList.ImageSize = new Size(32, 32);
            listView1.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            listViewCorrespondances.LargeImageList = listView1.SmallImageList;
            listViewCorrespondances.SmallImageList = listView1.SmallImageList;
            listViewCorrespondances.View = View.LargeIcon;
            FormUtil.SetControlSpacing(listViewCorrespondances, 40, 40);
            foreach (String ligne in lignes.Keys)
            {
                Image image = PictoService.getPicto(ligne);
                Bitmap bmp = new Bitmap(FormUtil.ResizeImage(image, 32, 32));
                comboLignes.Items.Add(lignes[ligne]);
                lineIndex[ligne] = listView1.SmallImageList.Images.Count;
                listView1.SmallImageList.Images.Add(bmp);
                comboBitmaps[ligne] = bmp;

            }
            this.comboLignes.SelectedIndex = lineIndex[LignesService.GetLigne("50").Nom];
            this.comboArrets.Text = "Château de Vaux";
            timer.Elapsed += Timer_Elapsed; ;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.SynchronizingObject = this;
        }


        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach(Favorite fav in Favorites)
            {
                String destination = fav.Destination;
                String ligne = fav.NomLigne;
                String arret = fav.NomArret;
                String direction = fav.Direction;
                var t = new Thread(() => TrayIcon.Notification(ligne, arret, direction, destination, 15));
                t.Start();
            }
        }

        public List<Favorite> Favorites
        {
            get
            {
                List<Favorite> result = new List<Favorite>();
                foreach(ListViewItem item in listView1.Items)
                {
                    result.Add((Favorite)item.Tag);
                }
                return result;
            }
            set
            {
                if (value != null)
                {
                    foreach (Favorite fav in value)
                    {
                        this.AddFavorite(fav);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notification();
        }

        private String GetDestination()
        {
            return this.direction.Value == 0 ? sens1.Text : sens2.Text;

        }

        public void Notification()
        {
            String destination = GetDestination();
            String ligne = GetSelectedLigne().Nom;
            String arret = this.comboArrets.Text;
            String direction = this.direction.Value.ToString();
            var t = new Thread(() => TrayIcon.Notification(ligne, arret, direction, destination, null));
            t.Start();
        }
    
        public void Form1_Quit(object sender, EventArgs e)
        {
            Configuration.Save();
            Application.Exit();
        }

        Ligne GetSelectedLigne()
        {
            return (Ligne)comboLignes.SelectedItem;
        }

        private void comboLignes_SelectedValueChanged(object sender, EventArgs e)
        {
            var arrets = LignesService.GetArrets(GetSelectedLigne().Nom);
            comboArrets.Items.Clear();
            foreach (Stop arret in arrets)
            {
                comboArrets.Items.Add(arret);
            }

            if(comboArrets.Items.Count > 0)
            {
                comboArrets.SelectedIndex = 0;
            }
            Ligne ligne = LignesService.GetLigne(GetSelectedLigne().Nom);
            sens1.Text = ligne.Sens0;
            sens2.Text = ligne.Sens1;
        }

        private void AddFavorite(Favorite fav)
        {
            ListViewItem item = new ListViewItem(new[] { fav.NomLigne, fav.NomArret, fav.Destination });
            item.Tag = fav;
            item.ImageIndex = lineIndex[fav.NomLigne];
            listView1.Items.Add(item);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Ligne ligne = GetSelectedLigne();

            Favorite fav = new Favorite(ligne.Nom, comboArrets.Text, this.direction.Value.ToString(), GetDestination());
            AddFavorite(fav);
        }

        private void comboLignes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Ligne ligne = (Ligne)comboLignes.Items[e.Index];

                e.DrawBackground();

                Rectangle r = e.Bounds;
                r.Offset(32, 0);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(ligne.GetItineraire(), this.Font, (e.State & DrawItemState.Selected) == DrawItemState.Selected ? SystemBrushes.HighlightText : SystemBrushes.WindowText, r, sf);
                e.Graphics.DrawImage(comboBitmaps[ligne.Nom], e.Bounds.Location);
            }
        }

        private void comboArrets_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Stop arret = (Stop)comboArrets.Items[e.Index];

                e.DrawBackground();

                Rectangle r = e.Bounds;
                r.Offset(32, 0);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(arret.ToString(), this.Font, (e.State & DrawItemState.Selected) == DrawItemState.Selected ? SystemBrushes.HighlightText : SystemBrushes.WindowText, r, sf);
                
            }
        }

        private void comboArrets_SelectedValueChanged(object sender, EventArgs e)
        {
            listViewCorrespondances.Items.Clear();
            String ligne = GetSelectedLigne().Nom;
            Stop stop = (Stop)comboArrets.SelectedItem;
            if (stop != null)
            {
                foreach (String s in stop.Correspondances)
                {
                    if (s != ligne)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = lineIndex[s];
                        listViewCorrespondances.Items.Add(item);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}