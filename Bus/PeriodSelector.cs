using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Bus
{
    public partial class PeriodSelector : UserControl
    {
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }
        public int RowCount { get { return 7; } }
        public int HeaderHeight { get { return 20; } }
        public int LeftWidth { get { return 70; } }
        public int DayHeight { get; set; }
        public static Periods Periods { get { return periods; } }

        private static readonly Brush SelectionBrush = new SolidBrush(Color.FromArgb(80, 105, 181, 231));
        private static readonly Brush SelectionBrushDelete = new SolidBrush(Color.FromArgb(64, 233, 119, 50));
        private static readonly Brush PeriodBrush = SelectionBrush;
        private static readonly Pen GridPen = new Pen(Color.FromArgb(192, 192, 192));
        private static readonly Pen DarkGridPen = new Pen(Color.FromArgb(128, 128, 128));
        private Period tmpPeriod;
        private HashSet<int> tmpDays;
        private MouseButtons lastMouseButton;
        private Point captureStart;
        private static Periods periods = new Periods(7);

        public int MinutesCount
        {
            get
            {
                return (int)End.Subtract(Begin).TotalMinutes;
            }
        }

        public PeriodSelector()
        {
            InitializeComponent();
        }

        int Ceiling(int x, int y)
        {
            if(x % y != 0)
            {
                return x / y + 1;
            }
            else
            {
                return x / y;
            }
        }

        private String getDay(int day)
        {
            switch(day)
            {
                case 0:
                    return "LUNDI";
                case 1:
                    return "MARDI";
                case 2:
                    return "MERCREDI";
                case 3:
                    return "JEUDI";
                case 4:
                    return "VENDREDI";
                case 5:
                    return "SAMEDI";
                default:
                    return "DIMANCHE";
            }
        }

        public int ColumnDuration { get; set; }
        public int ColumnCount { get; set; }
        public int ColumnWidth { get; set; }

        private void PeriodSelector_Paint(object sender, PaintEventArgs e)
        {
            if (Begin == End)
            {
                return;
            }

            Point pt = this.PointToClient(Cursor.Position);

            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
            Rectangle client = new Rectangle(LeftWidth, HeaderHeight, Width - LeftWidth - 1, Height - HeaderHeight - 1);
            e.Graphics.DrawRectangle(DarkGridPen, client);

            int pointX = pt.X - (pt.X % ColumnWidth);

            tmpPeriod = null;
            tmpDays = new HashSet<int>();

            int left = Math.Min(captureStart.X, pt.X);
            int right = Math.Max(captureStart.X, pt.X);
            int top = Math.Min(captureStart.Y, pt.Y);
            int bottom = Math.Max(captureStart.Y, pt.Y);

            left = left - (left - LeftWidth) % ColumnWidth;
            top = top - (top - HeaderHeight) % DayHeight;
            if (right % ColumnWidth != 0)
            {
                right = right + ColumnWidth - (right - LeftWidth) % ColumnWidth;
            }
            if (bottom % DayHeight != 0)
            {
                bottom = bottom + DayHeight - (bottom - HeaderHeight) % DayHeight;
            }

            {
                TimeSpan ts = Begin;
                int x = LeftWidth;
                for (int i = 0; i < ColumnCount; i++)
                {
                    if(ts.Minutes == 0)
                    {
                        e.Graphics.DrawString(ts.Hours.ToString(), this.Font, Brushes.Black, x, 4);
                    }
                    x += ColumnWidth;
                    ts = ts.Add(new TimeSpan(0, ColumnDuration, 0));
                }
            }
            int y = HeaderHeight;
            for (int row = 0; row < RowCount; row++)
            {
                TimeSpan ts = Begin;

                Rectangle leftRect = new Rectangle(0, y, LeftWidth - 5, DayHeight);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(getDay(row), this.Font, Brushes.Black, leftRect, sf);

                int x = LeftWidth;
                Rectangle dayRect = new Rectangle(LeftWidth, y, Width - LeftWidth - 1, DayHeight);
                e.Graphics.DrawRectangle(DarkGridPen, dayRect);
                for (int i = 0; i < ColumnCount; i++)
                {
                    Rectangle cellRect = new Rectangle(x, y + 1, ColumnWidth, DayHeight - 1);
                    lastMouseButton = MouseButtons;
                    Brush selBrush = lastMouseButton == MouseButtons.Right ? SelectionBrushDelete : SelectionBrush;
                    if (Capture)
                    {
                        if (left <= x && x + ColumnWidth <= right && top <= y && y + DayHeight <= bottom)
                        {
                            if (tmpPeriod == null)
                            {
                                tmpPeriod = new Period();
                                tmpPeriod.Begin = ts;
                            }
                            tmpDays.Add(row);
                            tmpPeriod.End = ts.Add(new TimeSpan(0, ColumnDuration - 1, 59));
                            e.Graphics.FillRectangle(selBrush, cellRect);
                        }
                    }
                    else
                    {
                        if (pt.X >= x && pt.X < x + ColumnWidth && pt.Y > y && pt.Y < y + DayHeight)
                        {
                            e.Graphics.FillRectangle(selBrush, cellRect);
                        }
                    }
                    foreach (Period period in periods.GetPeriods(row))
                    {
                        if (period.Contains(ts))
                        {

                            e.Graphics.FillRectangle(PeriodBrush, cellRect);
                            break;
                        }
                    }

                    if (ts.Minutes == 0)
                    {
                        e.Graphics.DrawLine(DarkGridPen, x, y + 1 - HeaderHeight + 4, x, y + DayHeight - 1);
                    }
                    else
                    {
                        e.Graphics.DrawLine(GridPen, x, y + 1, x, y + DayHeight - 1);
                    }
                    x += ColumnWidth;
                    ts = ts.Add(new TimeSpan(0, ColumnDuration, 0));
                }

                y += DayHeight;

                e.Graphics.DrawLine(DarkGridPen, 4, y, LeftWidth, y);
            }
        }

        private void PeriodSelector_MouseMove(object sender, MouseEventArgs e)
        {
            Repaint();
        }

        private void PeriodSelector_MouseLeave(object sender, EventArgs e)
        {
            Repaint();
        }

        private void PeriodSelector_MouseDown(object sender, MouseEventArgs e)
        {
            captureStart = e.Location;
            Capture = true;
            Repaint();
        }

        private void PeriodSelector_MouseUp(object sender, MouseEventArgs e)
        {
            if(Capture)
            {
                Capture = false;
                if (tmpPeriod != null)
                {
                    if (lastMouseButton == MouseButtons.Right)
                    {
                        foreach (int day in tmpDays)
                        {
                            periods.RemovePeriod(day, tmpPeriod.copy());
                        }
                    }
                    else
                    {
                        foreach (int day in tmpDays)
                        {
                            List<Period> newPeriod = new List<Period>();
                            newPeriod.Add(tmpPeriod.copy());
                            periods.AddPeriod(day, newPeriod);
                        }
                    }
                }
            }
            Repaint();
        }

        private void Repaint()
        {
            Invalidate();
            Update();
        }

        private void PeriodSelector_Resize(object sender, EventArgs e)
        {
            if (Parent != null && Begin != End)
            {
                ColumnDuration = 15;
                ColumnCount = Ceiling(MinutesCount, ColumnDuration);
                ColumnWidth = (Parent.Width - LeftWidth) / ColumnCount;
                this.Width = LeftWidth + ColumnCount * ColumnWidth;


                DayHeight = Ceiling(Height - HeaderHeight, RowCount);
                this.Height = HeaderHeight + DayHeight * RowCount;
            }
        }
    }
}
