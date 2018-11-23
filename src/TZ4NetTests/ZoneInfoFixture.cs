using System;
using NUnit.Framework;
using TZ4Net;

namespace TZ4NetTests
{
	/// <summary>
	/// Summary description for UtilsFixture.
	/// </summary>
	[TestFixture]
	public class ZoneInfoFixture
	{
		
		[SetUp]
		public void Setup()
		{
		}


		[TearDown]
		public void Teardown() 
		{
		}

		[Test]
		public void ZoneInfoTimeConstruction()
		{
			DateTime dt = DateTime.Now;
			ZoneInfo.Time t = new ZoneInfo.Time(dt);
			Assert.AreEqual(dt.Year, t.Year);
			Assert.AreEqual(dt.Month, t.Mon);
			Assert.AreEqual(dt.Day, t.MDay);
			Assert.AreEqual(dt.Hour, t.Hour);
			Assert.AreEqual(dt.Minute, t.Min);
			Assert.AreEqual(dt.Second, t.Sec);
		}

		[Test]
		public void AllDirs()
		{
			string[] allDirs = ZoneInfo.AllDirs;
			Assert.IsTrue(Array.IndexOf(allDirs, ZoneInfo.DefaultDir) >= 0);
		}


		[Test, ExpectedException(typeof(ArgumentNullException))]
		public void NameNull()
		{
			ZoneInfo zi = new ZoneInfo(null as string);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void NameEmpty()
		{
			Assert.IsNotNull(this);
			ZoneInfo zi = new ZoneInfo(string.Empty);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void NameUnknown()
		{
			ZoneInfo zi = new ZoneInfo("{0CC2C22D-0368-49b2-AF7E-4C261D336B01}");
		}


		[Test]
		public void AllNames() 
		{
			string[] names = ZoneInfo.AllNames;
			Assert.IsTrue(Array.IndexOf(names, "Europe/Amsterdam") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Warsaw") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Sofia") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "America/Chicago") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "America/New_York") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "{0CC2C22D-0368-49b2-AF7E-4C261D336B01}") < 0);
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// At 03:14:08 UTC on January 19, 2038 (+2^31), a 32-bit signed integer representation of Unix time 
		// will overflow. Systems using a 32-bit signed integer Unix time_t will therefore be unable to 
		// represent that time, or any later [...]
		[Test]
		public void ClockMaxToUTCLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(ZoneInfo.MaxClock);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.MaxValue) == 0);
		}


		[Test]
		public void UTCLocalTimeMaxToClock()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			long t1 = zi.GetClockFromLocalTime(ZoneInfo.Time.MaxValue);
			Assert.IsTrue(t1 == ZoneInfo.MaxClock);
			long t2 = zi.GetClockFromLocalTime(ZoneInfo.Time.MaxValue);
			Assert.IsTrue(t2 == ZoneInfo.MaxClock);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void UTCLocalTimeOverflowedToClock()
		{
			ZoneInfo.Time time = new ZoneInfo.Time(292277026596, 12, 04, 15, 30, 08);
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromLocalTime(time);
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// [...] and will likely wrap around to 20:45:52 UTC on December 13, 1901, 
		// with integer value -2^31. This is known as the year 2038 problem.
		[Test]
		public void ClockMinToUTCLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(ZoneInfo.MinClock);
			Assert.IsTrue(t.CompareTo(ZoneInfo.Time.MinValue) == 0);
		}


		[Test]
		public void UTCLocalTimeMinToClock()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			long t1 = zi.GetClockFromLocalTime(ZoneInfo.Time.MinValue);
			Assert.IsTrue(t1 == ZoneInfo.MinClock);
			long t2 = zi.GetClockFromUtc(ZoneInfo.Time.MinValue);
			Assert.IsTrue(t2 == ZoneInfo.MinClock);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void UTCLocalTimeUnderflowedToClock()
		{
            ZoneInfo.Time time = new ZoneInfo.Time(-292277022656, 09, 30, 08, 29, 51);
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromLocalTime(time);
		}


		[Test, ExpectedException(typeof(ArgumentException))]
		public void UTCLocalTimeWithLeapSecondToClock()
		{
			ZoneInfo.Time time = new ZoneInfo.Time(1998, 12, 31, 23, 59, 60);
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromLocalTime(time);
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// "At 01:58:31 UTC on March 18, 2005, the Unix time number reached 1111111111. A large celebration was held
		// on IRC in the Freenode channel #1111111111. At its peak the channel held over 200 people and averaged up 
		// to 24 messages in a single second".
		[Test]
		public void Clock1111111111ToUTCLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(1111111111);
			Assert.IsTrue(t.CompareTo(new ZoneInfo.Time(2005, 03, 18, 01, 58, 31)) == 0);
		}


		[Test]
		public void Utc20050318015831TimeToClock()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromUtc(new ZoneInfo.Time(2005, 03, 18, 01, 58, 31));
			Assert.IsTrue(t == 1111111111);
		}


		// From http://en.wikipedia.org/wiki/Unix_timestamp :
		// At 23:31:30 UTC on February 13, 2009, a celebration is expected as the Unix time 
		// number reaches 1234567890 seconds.
		[Test]
		public void Clock1234567890ToUTCLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(1234567890);
			Assert.IsTrue(t.CompareTo(new ZoneInfo.Time(2009, 02, 13, 23, 31, 30)) == 0);
		}


		[Test]
		public void Utc20090213233130TimeToClock()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromUtc(new ZoneInfo.Time(2009, 02, 13, 23, 31, 30));
			Assert.IsTrue(t == 1234567890);
		}


		// From http://slashdot.org/articles/01/04/17/1915221.shtml
        // "If my calculations are correct, on Thursday, April 19, 2001, at 04:25:21 UTC (00:25:21 EDT and 
		// late Wednesday at 21:25:21 PDT), the UNIX clock will read 987654321, which is pretty cool. 
		// This will be the first of two such "significant" events in 2001,  
		[Test]
		public void Clock987654321ToUTCLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(987654321);
			Assert.IsTrue(t.CompareTo(new ZoneInfo.Time(2001, 04, 19, 04, 25, 21)) == 0);
		}


		[Test]
		public void Utc20010419042521TimeToClock()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromUtc(new ZoneInfo.Time(2001, 04, 19, 04, 25, 21));
			Assert.IsTrue(t == 987654321);
		}


        // From http://slashdot.org/articles/01/04/17/1915221.shtml
		// [...] the second being 01:46:39 UTC on 2001-09-09, when the clock will read 999999999 
		// (and then of course "roll over" to 1000000000 one second later). Use the Time Zone 
		// Converter to help you figure out when this will occur in your area, or read up on other 
		// critical dates (such as when the 32-bit signed UNIX clock overflows in 2038)."
		[Test]
		public void Local999999999ToUTCLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			ZoneInfo.Time t = zi.GetLocalTime(999999999);
			Assert.IsTrue(t.CompareTo(new ZoneInfo.Time(2001, 09, 09, 01, 46, 39)) == 0);
		}


		[Test]
		public void Utc20010909014639TimeToClock()
		{
			ZoneInfo zi = new ZoneInfo("UTC");
			long t = zi.GetClockFromUtc(new ZoneInfo.Time(2001, 09, 09, 01, 46, 39));
			Assert.IsTrue(t == 999999999);
		}


		// According to www.timezoneconverter.com :
		//04:25:11 Thursday April 19, 2001 in UCT converts to
		//06:25:11 Thursday April 19, 2001 in Europe/Amsterdam 
		[Test]
		public void Clock987654321ToEuropeAmsterdamLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Amsterdam");
			ZoneInfo.Time t = zi.GetLocalTime(987654321);
			Assert.IsTrue(t.CompareTo(new ZoneInfo.Time(2001, 04, 19, 06, 25, 21)) == 0);
		}


		[Test]
		public void EuropeAmsterdamUtc20010419042521TimeToUnixTime()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Amsterdam");
			long t = zi.GetClockFromUtc(new ZoneInfo.Time(2001, 04, 19, 04, 25, 21));
			Assert.IsTrue(t == 987654321);
		}
		

		// According to www.timezoneconverter.com :
		// 01:46:39 Sunday September 9, 2001 in UCT converts to
		// 03:46:39 Sunday September 9, 2001 in Europe/Amsterdam  
		[Test]
		public void Clock999999999ToEuropeAmsterdamLocalTime()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Amsterdam");
			ZoneInfo.Time t = zi.GetLocalTime(999999999);
			Assert.IsTrue(t.CompareTo(new ZoneInfo.Time(2001, 09, 09, 03, 46, 39)) == 0);
		}


		[Test]
		public void EuropeAmsterdamUtc20010909014639TimeToClock()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Amsterdam");
			long t = zi.GetClockFromUtc(new ZoneInfo.Time(2001, 09, 09, 01, 46, 39));
			Assert.IsTrue(t == 999999999);
		}


		[Test]
		public void EuropeWarsawTransitions()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Warsaw");
			long[] times = zi.AllTransitionClocks;
			Assert.IsTrue(times.Length > 0);
			long time1 = zi.GetClockFromUtc(new ZoneInfo.Time(2006, 03, 26, 01, 00, 00));
			long time2 = zi.GetClockFromUtc(new ZoneInfo.Time(2006, 10, 29, 01, 00, 00));
			Assert.IsTrue(Array.IndexOf(times, time1) > 0);
			Assert.IsTrue(Array.IndexOf(times, time2) > 0);
		}


		[Test]
		public void EuropeWarsawLocalTime20061029015959ToClock()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Warsaw");
			long t = zi.GetClockFromLocalTime(new ZoneInfo.Time(2006, 10, 29, 01, 59, 59));
			Assert.IsTrue(t == 1162079999);
			t = zi.GetClockFromLocalTime(new ZoneInfo.Time(2006, 10, 29, 02, 12, 29));
			Assert.IsTrue(t == 1162080749 || t == 1162084349);
			t = zi.GetClockFromLocalTime(new ZoneInfo.Time(2006, 10, 29, 02, 12, 30));
			Assert.IsTrue(t == 1162080750 || t == 1162084350);
			t = zi.GetClockFromLocalTime(new ZoneInfo.Time(2006, 10, 29, 02, 12, 31));
			Assert.IsTrue(t == 1162080751 || t == 1162084351);
			t = zi.GetClockFromLocalTime(new ZoneInfo.Time(2006, 10, 29, 02, 12, 32));
			Assert.IsTrue(t == 1162080752 || t == 1162084352);
		}


		// Transition to summer time in Europe/Warsaw occurs on 2006-03-26 01:00:00 UTC time 
		// and back to winter time on 2006-10-29 01:00:00 UTC time.
		[Test]
		public void TransitionClocksOfEuropeWarsawIn2006()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Warsaw");
			long[] clocks = zi.GetTransitionClocks(2006);
			Assert.IsTrue(clocks.Length == 2);
			Assert.IsTrue(clocks[0] == 1143334800); //2006-03-26 01:00:00 UTC
			Assert.IsTrue(clocks[1] == 1162083600); //2006-10-29 01:00:00 UTC
		}


		// Transition to summer time in Europe/Warsaw occurs on 2006-03-26 02:00:00 local time 
		// and back to winter time on 2006-10-29 03:00:00 local time.
		[Test]
		public void InDaylightTimeOfEuropeWarsawIn2006()
		{
			ZoneInfo zi = new ZoneInfo("Europe/Warsaw");
			Assert.IsFalse(zi.InDaylightTime(new ZoneInfo.Time(2006, 03, 26, 01, 59, 59)));
			Assert.IsTrue(zi.InDaylightTime(new ZoneInfo.Time(2006, 03, 26, 03, 00, 00)));
			Assert.IsTrue(zi.InDaylightTime(new ZoneInfo.Time(2006, 10, 29, 01, 59, 59)));
			Assert.IsFalse(zi.InDaylightTime(new ZoneInfo.Time(2006, 10, 29, 03, 00, 00)));
			Assert.IsFalse(zi.InDaylightTime(new ZoneInfo.Time(2006, 10, 29, 03, 00, 01)));
		}
	}
}