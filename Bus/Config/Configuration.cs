using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Bus.Config
{
    class Configuration
    {
        public Dictionary<int, List<Period>> Periods { get; set; }

        public List<Favorite> Favorites { get; set; }

        public static Configuration Instance { get; set; }

        public static void Save()
        {
            Instance = new Configuration();
            Instance.Periods = PeriodSelector.Periods.Periodes;
            Instance.Favorites = Notifications.Instance.Favorites;

            using (StreamWriter file = File.CreateText(Notifications.FILES_DIRECTORY + "/Bus.config"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Instance);
            }
        }

        public static void Load()
        {
            try
            {
                using (StreamReader file = File.OpenText(Notifications.FILES_DIRECTORY + "/Bus.config"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Instance = (Configuration)serializer.Deserialize(file, typeof(Configuration));
                    PeriodSelector.Periods.Periodes = Instance.Periods;
                    Notifications.Instance.Favorites = Instance.Favorites;
                }
            }
            catch (FileNotFoundException)
            {

            }
        }
    }
}
