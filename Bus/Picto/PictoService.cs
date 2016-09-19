using Bus.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bus.Picto
{
    class PictoService
    {
        private static Dictionary<String, String> filenames;
        private static Dictionary<String, Image> images = new Dictionary<string, Image>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LoadFilenames()
        {
            if (filenames == null)
            {
                filenames = new Dictionary<String, String>();
                StringBuilder url = new StringBuilder("dataset=tco-bus-lignes-pictogrammes-dm");
                url.Append("&rows=1000");
                url.Append("&refine.resolution=1:100");

                byte[] data = DownloadUtils.Download("http://data.explore.star.fr/api/records/1.0/search/?" + url);

                dynamic d = JsonConvert.DeserializeObject(System.Text.Encoding.Default.GetString(data));
                foreach (dynamic record in d.records)
                {
                    String nom = record.fields.nomcourtligne;
                    String id = record.fields.image.id;
                    filenames[nom] = id;
                }
            }
        }

        public static Image getPicto(String line)
        {
            LoadFilenames();

            String imageFile = Notifications.FILES_DIRECTORY + "/" + line + ".png";
            Image image;
            if (!images.TryGetValue(line, out image))
            {
                try
                {
                    image = Image.FromFile(imageFile);
                }
                catch (Exception)
                {
                    byte[] data = DownloadUtils.Download("http://data.explore.star.fr/explore/dataset/tco-bus-lignes-pictogrammes-dm/files/" + filenames[line] + "/download");
                    image = Image.FromStream(new MemoryStream(data));
                    File.WriteAllBytes(imageFile, data);
                }
            }
            images[line] = image;

            return image;
        }
    }
}
