using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class Period
    {
        static TimeSpan sec = new TimeSpan(0, 0, 1);

        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }

        static TimeSpan Min(TimeSpan ts1, TimeSpan ts2)
        {
            return ts1 < ts2 ? ts1 : ts2;
        }

        static TimeSpan Max(TimeSpan ts1, TimeSpan ts2)
        {
            return ts1 > ts2 ? ts1 : ts2;
        }

        public Period()
        {

        }

        public Period(TimeSpan begin, TimeSpan end)
        {
            this.Begin = begin;
            this.End = end;
        }

        public Period copy()
        {
            return new Period(Begin, End);
        }

        public Boolean Contains(TimeSpan ts)
        {
            return Begin <= ts && End >= ts;
        }

        public Boolean Add(Period other)
        {
            TimeSpan begin1 = Begin;
            TimeSpan begin2 = other.Begin;
            TimeSpan end1 = End.Subtract(sec);
            TimeSpan end2 = other.End.Subtract(sec);

            if (begin1 <= end2 && begin2 <= end1)
            {
                Begin = Min(begin1, begin2);
                End = Max(end1, end2);
                return true;
            }
            return false;
        }

        public Boolean Intersect(Period other)
        {
            TimeSpan begin1 = Begin;
            TimeSpan begin2 = other.Begin;
            TimeSpan end1 = End;
            TimeSpan end2 = other.End;

            return begin1 <= end2 && begin2 <= end1;
        }

        public override String ToString()
        {
            return Begin + "-" + End;
        }
    }
}