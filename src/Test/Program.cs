using System;
using System.Collections.Generic;
using System.Text;
using TZ4Net;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.MaxValue;
            dt = DateTime.MinValue;

            ZoneInfo.Time t = ZoneInfo.Time.MaxValue;
            t.SetClock(825513193, 0);
            t.SetClock(951868799, 0);
            t.SetClock(852037983, 0);
            t.SetClock(951868801, 0);
            t.SetClock(976623132, 0);
            t.SetClock(883573993, 0);

            t.SetClock(-62167220150, 0);
            t.SetClock(-4758796338344525750, 0);

            ZoneInfo zi = new ZoneInfo("UTC");
            for (long i = -62167219150; i > long.MinValue; i -= 10)
            {
                t.SetClock(i, 0);
                long clk = zi.GetClockFromLocalTime(t);
                Console.WriteLine(t);
                System.Diagnostics.Debug.Assert(clk == i);
            }
        }
    }
}
