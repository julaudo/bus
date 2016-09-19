using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Lignes
{
    class Stop
    {
        public  int Id { get; set; }
        public String Name { get; set; }

        public Stop(int id, String name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public SortedSet<string> Correspondances
        {
            get
            {
                return LignesService.GetCorrespondances(Name);
            }
        }
    }
}
