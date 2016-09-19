using Bus.Util;
using System;
using System.Collections.Generic;

namespace Bus
{
    public class Periods
    {
        static TimeSpan sec = new TimeSpan(0, 0, 1);

        public Dictionary<int, List<Period>> Periodes { get; set; }

        public Periods(int count)
        {
            Periodes = new Dictionary<int, List<Period>>();
            for (int i = 0; i < count; i++)
            {
                Periodes[i] = new List<Period>();
            }
        }

        public List<Period> GetPeriods(int index)
        {
            return Periodes[index];
        }

        public void RemovePeriod(int day, Period period)
        {
            List<Period> newPeriodes = new List<Period>();
            foreach (Period p in Periodes[day])
            {
                Boolean add = true;
                Period newPeriod = null;
                if (period.Intersect(p))
                {
                    if (period.Begin <= p.Begin)
                    {
                        if (period.End >= p.End)
                        {
                            add = false;
                        }
                        else
                        {
                            p.Begin = period.End;
                        }
                    }
                    else
                    {
                        if (period.End < p.End)
                        {
                            newPeriod = new Period(period.End.Add(sec), p.End);
                        }
                        p.End = period.Begin.Subtract(sec);
                    }
                    if (add)
                    {
                        newPeriodes.Add(p);
                        if (newPeriod != null)
                        {
                            newPeriodes.Add(newPeriod);
                        }
                    }
                }
                else
                {
                    newPeriodes.Add(p);
                }

                Periodes[day] = newPeriodes;
            }
        }

        public void AddPeriod(int day, List<Period> newPeriods)
        {
            foreach (Period p in Periodes[day])
            {
                Boolean added = false;
                foreach (Period np in newPeriods)
                {
                    if (np.Add(p))
                    {
                        added = true;
                        break;
                    }
                }
                if (!added)
                {
                    newPeriods.Add(p);
                }
            }
            Boolean again = Periodes[day].Count != newPeriods.Count;
            Periodes[day] = newPeriods;
            if (again)
            {
                AddPeriod(day, new List<Period>(newPeriods));
            }
        }


    }
}
