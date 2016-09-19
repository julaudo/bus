using Bus.GTFS;
using Bus.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Lignes
{
    static class LignesService
    {
        private static IDictionary<String, Ligne> lignes = null;

        private static Dictionary<String, int> tripSens0 = new Dictionary<string, int>();
        private static Dictionary<String, int> tripSens1 = new Dictionary<string, int>();
        private static Dictionary<int, Stop> stops = new Dictionary<int, Stop>();
        private static Dictionary<String, List<Stop>> lineStops = new Dictionary<string, List<Stop>>();
        private static Dictionary<String, SortedSet<string>> correspondances = new Dictionary<string, SortedSet<string>>();

        public static SortedSet<string> GetCorrespondances(String name)
        {
            return correspondances[name];
        }

        public class LigneComparer : IComparer<String>
        {
            public int Compare(string x, string y)
            {
                int xStartC = x.StartsWith("C") ? 0 : 1;
                int yStartC = y.StartsWith("C") ? 0 : 1;
                if (xStartC != yStartC)
                {
                    return xStartC.CompareTo(yStartC);
                }

                int xInt, yInt;
                int xIsInt = int.TryParse(x, out xInt) ? 0 : 1;
                int yIsInt = int.TryParse(y, out yInt) ? 0 : 1;
                if (xIsInt == yIsInt)
                {
                    if (xIsInt == 0)
                        return xInt.CompareTo(yInt);
                    else
                    {
                        return x.CompareTo(y);
                    }
                }

                return xIsInt.CompareTo(yIsInt);
            }

        }

        public static String getSens(String line, Dictionary<String, List<int>> dico, Dictionary<String, int> tripSens)
        {
            int max = 0;
            String result = null;
            foreach (KeyValuePair<String, List<int>> value in dico)
            {
                if (value.Value.Count > max)
                {
                    result = value.Key;
                    max = value.Value.Count;
                    tripSens[line] = value.Value[0];
                }
            }
            return result;
        }

        public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            var dictionary = new Dictionary<TValue, TKey>();
            foreach (var entry in source)
            {
                if (!dictionary.ContainsKey(entry.Value))
                    dictionary.Add(entry.Value, entry.Key);
            }
            return dictionary;
        }

        private static String GetValue(String value)
        {
            return value.Replace("\"", "");
        }

        public static void Init() {
        
            if(lignes != null) 
            {
                return;
            }
            var result = new SortedDictionary<String, Ligne>(new LigneComparer());
            var sens0Count = new Dictionary<String, Dictionary<String, List<int>>>();
            var sens1Count = new Dictionary<String, Dictionary<String, List<int>>>();

            using (var memStream = new MemoryStream(GTFSService.GetGTFS()))
            using (ZipArchive archive = new ZipArchive(memStream))
            {
                ZipArchiveEntry entry = archive.GetEntry("trips.txt");
                using (var stream = entry.Open())
                using (var reader = new StreamReader(stream))
                {

                    SortedSet<String> busLines = new SortedSet<string>();
                    //route_id,service_id,trip_id,trip_headsign,trip_short_name,direction_id,block_id,shape_id,wheelchair_accessible,bikes_allowed
                    reader.ReadLine();
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Replace("\"", "");
                        String[] values = line.Split(',');
                        String[] trip_headsign = values[3].Split('|');
                        String busLine = trip_headsign[0].Trim();
                        if (!"A".Equals(busLine.ToUpper()))
                        {
                            String destination = trip_headsign[1].Trim();
                            int tripId = int.Parse(values[2]);
                            int sens = int.Parse(values[5]);
                            var dicoSens = sens == 0 ? sens0Count : sens1Count;
                            Dictionary<String, List<int>> dico;
                            if (!dicoSens.TryGetValue(busLine, out dico))
                            {
                                dico = new Dictionary<string, List<int>>();
                                dicoSens[busLine] = dico;
                            }
                            List<int> trips;
                            if (!dico.TryGetValue(destination, out trips))
                            {
                                trips = new List<int>();
                                dico[destination] = trips;
                            }
                            trips.Add(tripId);
                        }
                    }
                    Console.WriteLine();
                }

                foreach (String line in sens0Count.Keys)
                {
                    String sens0 = sens0Count.ContainsKey(line) ? getSens(line, sens0Count[line], tripSens0) : null;
                    String sens1 = sens1Count.ContainsKey(line) ? getSens(line, sens1Count[line], tripSens1) : null;

                    result[line] = new Ligne(line, sens0, sens1);
                    lineStops[line] = new List<Stop>();
                }

                entry = archive.GetEntry("stops.txt");
                using (var stream = entry.Open())
                using (var reader = new StreamReader(stream))
                {
                    //stop_id,stop_code,stop_name,stop_desc,stop_lat,stop_lon,zone_id,stop_url,location_type,parent_station,stop_timezone,wheelchair_boarding
                    reader.ReadLine();
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Replace("\"", "");
                        String[] values = line.Split(',');
                        int id = int.Parse(values[0]);
                        Stop stop = new Stop(id, values[2]);
                        stops[id] = stop;
                        correspondances[stop.Name] = new SortedSet<string>(new LigneComparer());
                    }
                }

                entry = archive.GetEntry("stop_times.txt");
                using (var stream = entry.Open())
                using (var reader = new StreamReader(stream))
                {
                    var trips = Reverse(tripSens0);
                    var tripsLeft = new SortedSet<int>(trips.Keys);

                    //trip_id,arrival_time,departure_time,stop_id,stop_sequence,stop_headsign,pickup_type,drop_off_type,shape_dist_traveled
                    reader.ReadLine();
                    string line = null;
                    int lineCount = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineCount++;
                        int tripId = int.Parse(line.Substring(1, line.IndexOf('"', 1) - 1));
                        if(trips.ContainsKey(tripId))
                        {
                            String[] values = line.Split(',');
                            tripsLeft.Remove(tripId);
                            int stopId = int.Parse(GetValue(values[3]));
                            int stopSeq = int.Parse(GetValue(values[4]));

                            String ligne = trips[tripId];
                            List<Stop> stopList = lineStops[ligne];
                            while(stopList.Count < stopSeq)
                            {
                                stopList.Add(null);
                            }
                            Stop stop = stops[stopId];
                            stopList[stopSeq - 1] = stop;
                            correspondances[stop.Name].Add(ligne);
                        }
                        else if(tripsLeft.Count == 0)
                        {
                            break;
                        }
                    }

                    foreach(List<Stop> spots in lineStops.Values)
                    {
                        spots.RemoveAll(x => x == null);
                    }
                }
            }


            lignes = result;
        }

        public static IDictionary<String, Ligne> GetLignes()
        {
            return lignes;
        }

        public static List<Stop> GetArrets(String line)
        {
            return lineStops[line];
        }

        public static Ligne GetLigne(String ligne)
        {
            return lignes[ligne];
        }
    }
}
