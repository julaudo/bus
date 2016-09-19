using Bus.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Passages
{
    class PassagesService
    {
        public static SortedSet<String> GetArrets(String ligne)
        {
            var list = new SortedSet<string>();
            StringBuilder url = new StringBuilder("dataset=tco-bus-circulation-passages-tr&q=nomcourtligne=");
            url.Append(ligne);
            url.Append("&rows=");
            url.Append(1000);

            byte[] data = DownloadUtils.Download("http://data.explore.star.fr/api/records/1.0/search/?" + url);

            dynamic result = JsonConvert.DeserializeObject(System.Text.Encoding.Default.GetString(data));
            foreach (dynamic record in result.records)
            {
                String nom = record.fields.nomarret;
                list.Add(nom);
            }
            return list;
        }

        public static PassagesResult getPassages(String ligne, String arret, String sens, int max)
        {
            StringBuilder url = new StringBuilder("dataset=tco-bus-circulation-passages-tr&q=nomcourtligne=");
            url.Append(ligne);
            url.Append("&rows=");
            url.Append(max);
            url.Append("&refine.nomarret=");
            url.Append(arret);
            url.Append("&refine.sens=");
            url.Append(sens);

            byte[] data = DownloadUtils.Download("http://data.explore.star.fr/api/records/1.0/search/?" + url);

            PassagesResult t = (PassagesResult)JsonConvert.DeserializeObject(System.Text.Encoding.Default.GetString(data), typeof(PassagesResult));
            return t;
        }
    }
}
