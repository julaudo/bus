using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Lignes
{
    class Ligne
    {
        public String Nom { get; set; }
        public String Sens0 { get; set; }
        public String Sens1 { get; set; }

        public Ligne(String nom)
        {
            Nom = nom;
        }

        public Ligne(String nom, String sens0, String sens1)
        {
            Nom = nom;
            Sens0 = sens0;
            Sens1 = sens1;
        }

        public void SetArrivee(int sens, String arrivee)
        {
            if (sens == 0)
            {
                Sens0 = arrivee;
            }
            else
            {
                Sens1 = arrivee;
            }
        }

        public String GetItineraire()
        {
            return Sens0 + " <-> " + Sens1;
        }
    }
}
