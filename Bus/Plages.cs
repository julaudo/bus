using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus.Util;

namespace Bus
{
    public partial class Plages : UserControl
    {
        public Plages()
        {
            InitializeComponent();
            FormUtil.SetDoubleBuffered(this.periodSelector);
            periodSelector.Begin = new TimeSpan(8, 0, 0);
            periodSelector.End = new TimeSpan(20, 0, 0);

        }
    }
}
