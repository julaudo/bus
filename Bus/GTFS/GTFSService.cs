using Bus.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.GTFS
{
    class GTFSService
    {
        public static byte[] GetGTFS()
        {
            var list = new SortedSet<string>();
            StringBuilder url = new StringBuilder("dataset=tco-busmetro-horaires-gtfs-versions-td&sort=publication");

            byte[] data = DownloadUtils.Download("http://data.explore.star.fr/api/records/1.0/search/?" + url);

            dynamic result = JsonConvert.DeserializeObject(System.Text.Encoding.Default.GetString(data));
            for (int i = 0; i < 5; i++)
            {
                DateTime now = DateTime.Now.Date.AddDays(i);
                foreach (dynamic record in result.records)
                {
                    DateTime debutValidite = record.fields.debutvalidite;
                    DateTime finValidite = record.fields.finvalidite;
                    if (debutValidite <= now && finValidite >= now)
                    {
                        String gtfsUrl = record.fields.url;
                        String name = Notifications.FILES_DIRECTORY + "/" + record.fields.id + ".zip";

                        try
                        {

                            data = File.ReadAllBytes(name);
                        }
                        catch (Exception)
                        {
                            data = DownloadUtils.Download(gtfsUrl);
                            File.WriteAllBytes(name, data);
                        }

                        return data;
                    }
                }
            }
            return null;
        }
    }
}
