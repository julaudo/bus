using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus
{
    [Serializable]
    public class Favorite
    {
        public String NomLigne { get; set; }
        public String NomArret { get; set; }
        public String Direction { get; set; }
        public String Destination { get; set; }

        public Favorite(String nomLigne, String nomArret, String direction, String destination)
        {
            NomLigne = nomLigne;
            NomArret = nomArret;
            Direction = direction;
            Destination = destination;
        }
     
    }
}
