using System;
using System.Globalization;
using Microsoft.Win32;
using NUnit.Framework;
using TZ4Net;

namespace TZ4NetTests
{
	/// <summary>
	/// Summary description for UtilsFixture.
	/// </summary>
	[TestFixture]
	public class OlsonTimeZoneFixture
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
		public void AllNames() 
		{
			string[] names = OlsonTimeZone.AllNames;
			Assert.IsTrue(Array.IndexOf(names, "Europe/Amsterdam") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Warsaw") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Sofia") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "America/Chicago") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "America/New_York") >= 0);
			Assert.IsTrue(Array.IndexOf(names, "{0CC2C22D-0368-49b2-AF7E-4C261D336B01}") < 0);
		}


		[Test]
		public void NamesOfEuropeWarsaw()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw");
			string daylightName = tz.DaylightName;
			Assert.IsTrue(daylightName.IndexOf(tz.Name) >= 0);
			string standardName = tz.StandardName;
			Assert.IsTrue(standardName.IndexOf(tz.Name) >= 0);
		}


		[Test]
		public void CurrentTimeZone()
		{
            Assert.IsNotNull(OlsonTimeZone.CurrentTimeZone);
		}


		[Test]
		public void DaylightChangesOfEuropeWarsawIn2006()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw");
			DaylightTime dt = tz.GetDaylightChanges(2006);
			Assert.IsTrue(dt.Start == new DateTime(2006, 03, 26, 02, 00, 00));
			Assert.IsTrue(dt.End == new DateTime(2006, 10, 29, 03, 00, 00));
			Assert.IsTrue(dt.Delta.TotalSeconds == 3600);
		}


		[Test]
		public void UtcOffsetsOfEuropeWarsawIn2006()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw");
			TimeSpan offset = tz.GetUtcOffset(new DateTime(2006, 03, 26, 01, 59, 59));
			Assert.IsTrue(offset.TotalSeconds == 3600);
			Assert.IsTrue(tz.CheckLocalTime(new DateTime(2006, 03, 26, 02, 00, 00)) == TimeCheckResult.InSpringForwardGap);
			offset = tz.GetUtcOffset(new DateTime(2006, 03, 26, 03, 00, 00));
			Assert.IsTrue(offset.TotalSeconds == 7200);
			offset = tz.GetUtcOffset(new DateTime(2006, 10, 29, 01, 59, 59));
			Assert.IsTrue(offset.TotalSeconds == 7200);
			Assert.IsTrue(tz.CheckLocalTime(new DateTime(2006, 10, 29, 02, 00, 00)) == TimeCheckResult.InFallBackRange);
			offset = tz.GetUtcOffset(new DateTime(2006, 10, 29, 03, 00, 00));
			Assert.IsTrue(offset.TotalSeconds == 3600);
		}


		// Transition to summer time in Europe/Warsaw occurs on 2006-03-26 02:00:00 local time 
		// and back to winter time on 2006-10-29 03:00:00 local time.
		[Test]
		public void IsDaylightSavingTimeOfEuropeWarsawIn2006()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw");
			Assert.IsFalse(tz.IsDaylightSavingTime(new DateTime(2006, 03, 26, 01, 59, 59)));
			Assert.IsTrue(tz.CheckLocalTime(new DateTime(2006, 03, 26, 02, 00, 00)) == TimeCheckResult.InSpringForwardGap);
			Assert.IsTrue(tz.CheckLocalTime(new DateTime(2006, 03, 26, 02, 59, 59)) == TimeCheckResult.InSpringForwardGap);
			Assert.IsTrue(tz.IsDaylightSavingTime(new DateTime(2006, 03, 26, 03, 00, 00)));
			Assert.IsTrue(tz.IsDaylightSavingTime(new DateTime(2006, 10, 29, 01, 59, 59)));
			Assert.IsTrue(tz.CheckLocalTime(new DateTime(2006, 10, 29, 02, 00, 00)) == TimeCheckResult.InFallBackRange);
			Assert.IsTrue(tz.CheckLocalTime(new DateTime(2006, 10, 29, 02, 59, 59)) == TimeCheckResult.InFallBackRange);
			Assert.IsFalse(tz.IsDaylightSavingTime(new DateTime(2006, 10, 29, 03, 00, 00)));
		}

		
		// According to www.timezoneconverter.com :
		// 14:11:48 Friday August 5, 2005 in UCT converts to
		// 16:11:48 Friday August 5, 2005 in Europe/Amsterdam  
		[Test]
		public void ConvertUtc20050805141148ToEuropeAmsterdam()
		{
			Assert.IsTrue(OlsonTimeZone.Convert("UCT", new DateTime(2005, 08, 05, 14, 11, 48), "Europe/Amsterdam") == new DateTime(2005, 08, 05, 16, 11, 48));
		}

		 
		// According to www.timezoneconverter.com :
		// 15:15:15 Thursday March 17, 2005 in UCT converts to
		// 16:15:15 Thursday March 17, 2005 in Europe/Amsterdam 
		[Test]
		public void ConvertUtc20050317151515ToEuropeAmsterdam()
		{
			Assert.IsTrue(OlsonTimeZone.Convert("UCT", new DateTime(2005, 03, 17, 15, 15, 15), "Europe/Amsterdam") == new DateTime(2005, 03, 17, 16, 15, 15));
		}


		/// According to www.timezoneconverter.com :
		/// 11:15:00 Saturday October 24, 1992 in Europe/Warsaw converts to
		/// 05:15:00 Saturday October 24, 1992 in America/Chicago
		/// DST* is not in effect on this date/time in Europe/Warsaw 
		/// DST* is in effect on this date/time in America/Chicago
		[Test]
		public void ConvertEuropeWarsaw19921024111500ToAmericaChicago()
		{
			Assert.IsTrue(OlsonTimeZone.Convert("Europe/Warsaw", new DateTime(1992, 10, 24, 11, 15, 00), "America/Chicago") == new DateTime(1992, 10, 24, 05, 15, 00));
			Assert.IsFalse(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw").IsDaylightSavingTime(new DateTime(1992, 10, 24, 11, 15, 00)));
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Chicago").IsDaylightSavingTime(new DateTime(1992, 10, 24, 05, 15, 00)));
		}


		// From http://www.infoplease.com/spot/daylight1.html :
		// "But just months after Indiana got in step with the rest of the country, the federal government announced 
		// a major change in Daylight Saving Time. In Aug. 2005, Congress passed an energy bill that included 
		// extending Daylight Saving Time by about a month. Beginning in 2007, DST will start the second Sunday 
		// of March and end on the first Sunday of November."
		// So, March 17 should NOT be in DST in 2006, but should be in DST in 2007 in New York....

		// According to www.timezoneconverter.com :
		// 13:13:13 Friday March 17, 2006 in UCT converts to
		// 08:13:13 Friday March 17, 2006 in America/New_York  
		// DST* is not in effect on this date/time in UCT 
		// DST* is not in effect on this date/time in America/New_York
		[Test]
		public void ConvertUtc20060317131313ToAmericaNewYork()
		{
			Assert.IsTrue(OlsonTimeZone.Convert("UTC", new DateTime(2006, 03, 17, 13, 13, 13), "America/New_York") == new DateTime(2006, 03, 17, 08, 13, 13));
			Assert.IsFalse(OlsonTimeZone.GetInstanceFromOlsonName("UTC").IsDaylightSavingTime(new DateTime(2006, 03, 17, 13, 13, 13)));
			Assert.IsFalse(OlsonTimeZone.GetInstanceFromOlsonName("America/New_York").IsDaylightSavingTime(new DateTime(2006, 03, 17, 08, 13, 13)));
		}

		
		// According to www.timezoneconverter.com :
		// 13:13:13 Saturday March 17, 2007 in UCT converts to
		// 09:13:13 Saturday March 17, 2007 in America/New_York  
		// DST* is not in effect on this date/time in UCT 
		// DST* is in effect on this date/time in America/New_York  
		[Test]
		public void ConvertUtc20070317131313ToAmericaNewYork()
		{
			Assert.IsTrue(OlsonTimeZone.Convert("UTC", new DateTime(2007, 03, 17, 13, 13, 13), "America/New_York") == new DateTime(2007, 03, 17, 09, 13, 13));
			Assert.IsFalse(OlsonTimeZone.GetInstanceFromOlsonName("UTC").IsDaylightSavingTime(new DateTime(2007, 03, 17, 13, 13, 13)));
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/New_York").IsDaylightSavingTime(new DateTime(2007, 03, 17, 09, 13, 13)));
		}


		[Test]
		public void AllDaylightChangesOfAllTimeZones()
		{
			string[] allNames = OlsonTimeZone.AllNames;
			foreach (string name in allNames) 
			{
				OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName(name);
				DaylightTime[] times = tz.AllTimeChanges;
				System.Console.WriteLine(string.Format("{0} has {1} changes.", tz.Name, times.Length));
			}
		}


		[Test]
		public void CheckBoundaryTimesInUtc()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("UTC");
			TimeCheckResult res = tz.CheckLocalTime(DateTime.MinValue);
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(ZoneInfo.Time.MinValue.DateTime.Subtract(new TimeSpan(0, 0, 1)));
			Assert.IsTrue(res == TimeCheckResult.LessThanUnixMin);
			res = tz.CheckLocalTime(ZoneInfo.Time.MinValue.DateTime);
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(ZoneInfo.Time.MinValue.DateTime.Add(new TimeSpan(0, 0, 1)));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(ZoneInfo.Time.MaxValue.DateTime.Subtract(new TimeSpan(0, 0, 1)));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(ZoneInfo.Time.MaxValue.DateTime);
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(ZoneInfo.Time.MaxValue.DateTime.Add(new TimeSpan(0, 0, 1)));
			Assert.IsTrue(res == TimeCheckResult.GreaterThanUnixMax);
			res = tz.CheckLocalTime(DateTime.MaxValue);
			Assert.IsTrue(res == TimeCheckResult.GreaterThanUnixMax);	
		}


		[Test]
		public void CheckTimesOfEuropeWarsaw2006Transitions()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw");
			TimeCheckResult res = tz.CheckLocalTime(new DateTime(2006, 03, 26, 01, 59, 59));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(2006, 03, 26, 02, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.InSpringForwardGap);
			res = tz.CheckLocalTime(new DateTime(2006, 03, 26, 02, 00, 01));
			Assert.IsTrue(res == TimeCheckResult.InSpringForwardGap);
			res = tz.CheckLocalTime(new DateTime(2006, 10, 29, 01, 59, 59));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(2006, 10, 29, 02, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.InFallBackRange);
			res = tz.CheckLocalTime(new DateTime(2006, 10, 29, 02, 00, 01));
			Assert.IsTrue(res == TimeCheckResult.InFallBackRange);
			res = tz.CheckLocalTime(new DateTime(2006, 10, 29, 02, 59, 59));
			Assert.IsTrue(res == TimeCheckResult.InFallBackRange);
			res = tz.CheckLocalTime(new DateTime(2006, 10, 29, 03, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(2006, 10, 29, 03, 00, 01));
			Assert.IsTrue(res == TimeCheckResult.Valid);
		}


		[Test]
		public void CheckTimesOfEuropeWarsaw1915And1916Transitions()
		{
			OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName("Europe/Warsaw");
			TimeCheckResult res = tz.CheckLocalTime(new DateTime(1915, 08, 04, 23, 59, 59));
			Assert.IsTrue(res == TimeCheckResult.InFallBackRange);
			res = tz.CheckLocalTime(new DateTime(1915, 08, 05, 00, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(1915, 08, 05, 00, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(1916, 08, 05, 00, 00, 01));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(1916, 04, 30, 22, 59, 59));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(1916, 04, 30, 23, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.InSpringForwardGap);
			res = tz.CheckLocalTime(new DateTime(1916, 04, 30, 23, 00, 01));
			Assert.IsTrue(res == TimeCheckResult.InSpringForwardGap);
			res = tz.CheckLocalTime(new DateTime(1916, 10, 01, 00, 59, 59));
			Assert.IsTrue(res == TimeCheckResult.InFallBackRange);
			res = tz.CheckLocalTime(new DateTime(1916, 10, 01, 01, 00, 00));
			Assert.IsTrue(res == TimeCheckResult.Valid);
			res = tz.CheckLocalTime(new DateTime(1916, 10, 01, 01, 00, 01));
			Assert.IsTrue(res == TimeCheckResult.Valid);
		}


		[Test]
		public void MaxTimeOfAllTimeZones() 
		{
			string[] names = OlsonTimeZone.AllNames;
			foreach(string name in names) 
			{
				OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName(name);
				TimeCheckResult res = tz.CheckLocalTime(OlsonTimeZone.MaxTime);
				Assert.IsTrue(res == TimeCheckResult.Valid || res == TimeCheckResult.InSpringForwardGap);
				if (res == TimeCheckResult.Valid) 
				{
					long clock = tz.ZoneInfo.GetClockFromLocalTime(new ZoneInfo.Time(OlsonTimeZone.MaxTime));
				} 
				else if (res == TimeCheckResult.InSpringForwardGap) 
				{
					try 
					{
						long clock = tz.ZoneInfo.GetClockFromLocalTime(new ZoneInfo.Time(OlsonTimeZone.MaxTime));
						Assert.Fail(string.Format("{0} exception was expected.", typeof(System.ArgumentException).Name));
					} 
					catch (ArgumentException) 
					{
					}
				}
			}
		}

		[Test]
		public void LastChangeOfAllTimeZones() 
		{
			string[] names = OlsonTimeZone.AllNames;
			foreach(string name in names) 
			{
				OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName(name);
				Assert.IsTrue(tz.AllTimeChanges.Length > 0);
				Assert.IsTrue(tz.AllTimeChanges[tz.AllTimeChanges.Length - 1].End == OlsonTimeZone.MaxTime);
				DaylightTime change = tz.AllTimeChanges[tz.AllTimeChanges.Length - 1];

				DateTime[] times = new DateTime[4];
				times[0] = change.End.Subtract(new TimeSpan(0, 0, 1));
				times[1] = change.End.Subtract(new TimeSpan(0, 0, (int)Math.Abs(tz.ZoneInfo.GetRule(ZoneInfo.MaxClock).Offset)));
                times[2] = OlsonTimeZone.SafeAdd(times[1], TimeSpan.FromSeconds(1));
                times[3] = OlsonTimeZone.SafeAdd(times[1], TimeSpan.FromSeconds(-1));

				foreach(DateTime time in times)
				{
					Assert.IsTrue(time >= change.Start);
					TimeCheckResult res = tz.CheckLocalTime(time);
					Assert.IsTrue(res == TimeCheckResult.Valid || res == TimeCheckResult.InSpringForwardGap || res == TimeCheckResult.GreaterThanUnixMax);
					if (res == TimeCheckResult.Valid) 
					{
						long clock = tz.ZoneInfo.GetClockFromLocalTime(new ZoneInfo.Time(time));
					} 
					else if (res == TimeCheckResult.InSpringForwardGap)
					{
						try 
						{
							long clock = tz.ZoneInfo.GetClockFromLocalTime(new ZoneInfo.Time(time));
							Assert.Fail(string.Format("{0} exception was expected.", typeof(System.ArgumentException).Name));
						} 
						catch (ArgumentException) 
						{
						}
					}
					else if (res == TimeCheckResult.GreaterThanUnixMax)
					{
						// ignore
					} 
				}
			}
		}

		[Test, Category("Long running")]
		public void AllChangesOfAllTimeZones() 
		{
			string[] names = OlsonTimeZone.AllNames;
			foreach(string name in names) 
			{
				OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromOlsonName(name);
				Assert.IsTrue(tz.AllTimeChanges.Length > 0);
				Assert.IsTrue(tz.AllTimeChanges[tz.AllTimeChanges.Length - 1].End == OlsonTimeZone.MaxTime);
				for (int i = 0; i < tz.AllTimeChanges.Length; i++)
				{
					DaylightTime change = tz.AllTimeChanges[i];
					TimeSpan nextDelta = i < tz.AllTimeChanges.Length - 1 ? tz.AllTimeChanges[i + 1].Delta : new TimeSpan(0);
					DateTime[] times = new DateTime[12];
					times[0] = change.Start;
					times[1] = change.Start.Add(new TimeSpan(0, 0, 1));
					times[2] = change.Start.Add(new TimeSpan(0, 0, -1));
					times[3] = change.Start.Add(change.Delta);
					times[4] = change.Start.Add( change.Delta).Add(new TimeSpan(0, 0, 1));
					times[5] = change.Start.Add(change.Delta).Add(new TimeSpan(0, 0, -1));
					times[6] = change.End;
					times[7] = change.End.Add(new TimeSpan(0, 0, 1));
					times[8] = change.End.Add(new TimeSpan(0, 0, -1));
					times[9] = change.End.Add(nextDelta);
					times[10] = change.End.Add(nextDelta).Add(new TimeSpan(0, 0, 1));
					times[11] = change.End.Add(nextDelta).Add(new TimeSpan(0, 0, -1));

					foreach(DateTime time in times)
					{
						TimeCheckResult res = tz.CheckLocalTime(time);
						if (res == TimeCheckResult.Valid || res == TimeCheckResult.InFallBackRange) 
						{
							long clock = tz.ZoneInfo.GetClockFromLocalTime(new ZoneInfo.Time(time));
						} 
						else if (res == TimeCheckResult.InSpringForwardGap)
						{
							try 
							{
								long clock = tz.ZoneInfo.GetClockFromLocalTime(new ZoneInfo.Time(time));
								Assert.Fail(string.Format("{0} exception was expected.", typeof(System.ArgumentException).Name));
							} 
							catch (ArgumentException) 
							{
							}
						} 
						else if (res == TimeCheckResult.LessThanUnixMin || res == TimeCheckResult.GreaterThanUnixMax)
						{
							// ignore
						} 
					}
				}
			}
		}


		[Test]
		public void AllPrimaryNames() 
		{
			string[] names = OlsonTimeZone.AllPrimaryNames;
			Assert.IsNotNull(names);

			Assert.IsTrue(Array.IndexOf(names, "CST") == -1);
			Assert.IsTrue(Array.IndexOf(names, "US/Central") == -1);
			Assert.IsTrue(Array.IndexOf(names, "CST6CDT") == -1);
			Assert.IsTrue(Array.IndexOf(names, "SystemV/CST6CDT") == -1);
			Assert.IsTrue(Array.IndexOf(names, "America/Chicago") >= 0);

			Assert.IsTrue(Array.IndexOf(names, "PST") == -1);
			Assert.IsTrue(Array.IndexOf(names, "US/Pacific") == -1);
			Assert.IsTrue(Array.IndexOf(names, "US/Pacific-New") == -1);
			Assert.IsTrue(Array.IndexOf(names, "PST8PDT") == -1);
			Assert.IsTrue(Array.IndexOf(names, "SystemV/PST8PDT") == -1);
			Assert.IsTrue(Array.IndexOf(names, "America/Los_Angeles") >= 0);

			Assert.IsTrue(Array.IndexOf(names, "GB") == -1);
			Assert.IsTrue(Array.IndexOf(names, "GB-Eire") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Europe/London") >= 0);

			Assert.IsTrue(Array.IndexOf(names, "Poland") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Warsaw") >= 0);

			Assert.IsTrue(Array.IndexOf(names, "Portugal") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Europe/Lisbon") >= 0);

			Assert.IsTrue(Array.IndexOf(names, "UTC") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Zulu") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/Zulu") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Universal") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/Universal") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/UTC") >= 0);

			Assert.IsTrue(Array.IndexOf(names, "Etc/GMT+0") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/GMT-0") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/GMT0") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/Greenwich") == -1);
			Assert.IsTrue(Array.IndexOf(names, "GMT") == -1);
			Assert.IsTrue(Array.IndexOf(names, "GMT+0") == -1);
			Assert.IsTrue(Array.IndexOf(names, "GMT-0") == -1);
			Assert.IsTrue(Array.IndexOf(names, "GMT0") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Greenwich") == -1);
			Assert.IsTrue(Array.IndexOf(names, "Etc/GMT") >= 0);
		}


		[Test]
		public void AllForeignAliases() 
		{
			string[] aliases = OlsonTimeZone.AllForeignAliases;
			Assert.IsNotNull(aliases);

			Assert.IsTrue(Array.IndexOf(aliases, "AST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "BST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "CST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "EST") == -1);
			Assert.IsTrue(Array.IndexOf(aliases, "IST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "JST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "MST") == -1);
			Assert.IsTrue(Array.IndexOf(aliases, "NST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "PST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "VST") >= 0);

			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/AST4") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/AST4ADT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/CST6") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/CST6CDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/EST5") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/EST5EDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/HST10") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/MST7") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/MST7MDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/PST8") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/PST8PDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/YST9") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/YST9YDT") >= 0);
		}

        [Test]
        public void AllWin32Ids()
        {
            string[] ids = OlsonTimeZone.AllWin32Ids;
            Assert.IsNotNull(ids);

            Assert.IsTrue(Array.IndexOf(ids, "Eastern Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Central Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Mountain Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Pacific Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "US Mountain Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "US Eastern Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Atlantic Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Central Europe Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Tasmania Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Vladivostok Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Azerbaijan Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Central Brazilian Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Central Standard Time (Mexico)") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Georgian Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Jordan Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Middle East Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Montevideo Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Mountain Standard Time (Mexico)") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Namibia Standard Time") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "Pacific Standard Time (Mexico)") >= 0);
        }

        [Test]
        public void AllWin32Names()
        {
            string[] ids = OlsonTimeZone.AllWin32Names;
            Assert.IsNotNull(ids);

            Assert.IsTrue(ids.Length >= 75);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-07:00) Arizona") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-05:00) Indiana (East)") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-04:00) Atlantic Time (Canada)") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+10:00) Hobart") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+11:00) Vladivostok") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+04:00) Baku") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-06:00) Guadalajara, Mexico City, Monterrey") >= 0);	// -> "Central Standard Time (Mexico)"
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+04:00) Tbilisi") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+02:00) Amman") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+02:00) Beirut") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-03:00) Montevideo") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-07:00) Chihuahua, La Paz, Mazatlan") >= 0);			// -> "Mountain Standard Time (Mexico)"
            Assert.IsTrue(Array.IndexOf(ids, "(UTC+01:00) Windhoek") >= 0);
            Assert.IsTrue(Array.IndexOf(ids, "(UTC-08:00) Baja California") >= 0);				// -> "Pacific Standard Time (Mexico)"
        }

        [Test]
        public void GetNameFromWin32Id()
        {
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("US Mountain Standard Time") == "America/Phoenix");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Atlantic Standard Time") == "America/Halifax");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Central Europe Standard Time") == "Europe/Budapest");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Tasmania Standard Time") == "Australia/Hobart");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Vladivostok Standard Time") == "Asia/Vladivostok");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Eastern Standard Time") == "America/New_York");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Central Standard Time") == "America/Chicago");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Mountain Standard Time") == "America/Denver");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Pacific Standard Time") == "America/Los_Angeles");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("US Mountain Standard Time") == "America/Phoenix");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Atlantic Standard Time") == "America/Halifax");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Central Europe Standard Time") == "Europe/Budapest");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Tasmania Standard Time") == "Australia/Hobart");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Vladivostok Standard Time") == "Asia/Vladivostok");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Azerbaijan Standard Time") == "Asia/Baku");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Jordan Standard Time") == "Asia/Amman");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Middle East Standard Time") == "Asia/Beirut");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Montevideo Standard Time") == "America/Montevideo");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Id("Namibia Standard Time") == "Africa/Windhoek");
        }

		[Test]
		public void Win32Id() 
		{
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Phoenix").Win32Id == "US Mountain Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Halifax").Win32Id == "Atlantic Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Budapest").Win32Id == "Central Europe Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Australia/Hobart").Win32Id == "Tasmania Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Vladivostok").Win32Id == "Vladivostok Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/New_York").Win32Id == "Eastern Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Chicago").Win32Id == "Central Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Denver").Win32Id == "Mountain Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Los_Angeles").Win32Id == "Pacific Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Baku").Win32Id == "Azerbaijan Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Amman").Win32Id == "Jordan Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Beirut").Win32Id == "Middle East Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Montevideo").Win32Id == "Montevideo Standard Time");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Chihuahua").Win32Id == "Mountain Standard Time (Mexico)");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Africa/Windhoek").Win32Id == "Namibia Standard Time");
		}

		[Test]
		public void Win32Name() 
		{
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Baku").Win32Name == "(UTC+04:00) Baku");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Amman").Win32Name == "(UTC+02:00) Amman");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Chihuahua").Win32Name == "(UTC-07:00) Chihuahua, La Paz, Mazatlan");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Asia/Beirut").Win32Name == "(UTC+02:00) Beirut");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Montevideo").Win32Name == "(UTC-03:00) Montevideo");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Africa/Windhoek").Win32Name == "(UTC+01:00) Windhoek");
        }

        [Test]
        public void GetNameFromWin32Name()
        {
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC-07:00) Arizona") == "America/Phoenix");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC-04:00) Atlantic Time (Canada)") == "America/Halifax");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague") == "Europe/Budapest");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+10:00) Hobart") == "Australia/Hobart");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+11:00) Vladivostok") == "Asia/Vladivostok");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+04:00) Baku") == "Asia/Baku");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+02:00) Amman") == "Asia/Amman");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC-07:00) Chihuahua, La Paz, Mazatlan") == "America/Chihuahua");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+02:00) Beirut") == "Asia/Beirut");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC-03:00) Montevideo") == "America/Montevideo");
            Assert.IsTrue(OlsonTimeZone.GetNameFromWin32Name("(UTC+01:00) Windhoek") == "Africa/Windhoek");
        }

        [Test]
        public void GetWin32NameFromWin32Id()
        {
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("US Mountain Standard Time") == "(UTC-07:00) Arizona");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("US Eastern Standard Time") == "(UTC-05:00) Indiana (East)");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Atlantic Standard Time") == "(UTC-04:00) Atlantic Time (Canada)");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Central Europe Standard Time") == "(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Tasmania Standard Time") == "(UTC+10:00) Hobart");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Vladivostok Standard Time") == "(UTC+11:00) Vladivostok");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Azerbaijan Standard Time") == "(UTC+04:00) Baku");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Central Standard Time (Mexico)") == "(UTC-06:00) Guadalajara, Mexico City, Monterrey");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Georgian Standard Time") == "(UTC+04:00) Tbilisi");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Jordan Standard Time") == "(UTC+02:00) Amman");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Middle East Standard Time") == "(UTC+02:00) Beirut");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Montevideo Standard Time") == "(UTC-03:00) Montevideo");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Mountain Standard Time (Mexico)") == "(UTC-07:00) Chihuahua, La Paz, Mazatlan");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Namibia Standard Time") == "(UTC+01:00) Windhoek");
            Assert.IsTrue(OlsonTimeZone.GetWin32NameFromWin32Id("Pacific Standard Time (Mexico)") == "(UTC-08:00) Baja California");
        }

        [Test]
        public void GetInstanceFromWin32Id()
        {
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Eastern Standard Time").Name == "America/New_York");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Central Standard Time").Name == "America/Chicago");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Mountain Standard Time").Name == "America/Denver");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Pacific Standard Time").Name == "America/Los_Angeles");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("US Mountain Standard Time").Name == "America/Phoenix");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Atlantic Standard Time").Name == "America/Halifax");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Central Europe Standard Time").Name == "Europe/Budapest");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Tasmania Standard Time").Name == "Australia/Hobart");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Vladivostok Standard Time").Name == "Asia/Vladivostok");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Azerbaijan Standard Time").Name == "Asia/Baku");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Jordan Standard Time").Name == "Asia/Amman");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Middle East Standard Time").Name == "Asia/Beirut");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Montevideo Standard Time").Name == "America/Montevideo");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Mountain Standard Time (Mexico)").Name == "America/Chihuahua");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Id("Namibia Standard Time").Name == "Africa/Windhoek");
        }

        [Test]
        public void GetInstanceFromWin32Name()
        {
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC-07:00) Arizona").Name == "America/Phoenix");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC-04:00) Atlantic Time (Canada)").Name == "America/Halifax");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague").Name == "Europe/Budapest");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+10:00) Hobart").Name == "Australia/Hobart");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+11:00) Vladivostok").Name == "Asia/Vladivostok");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+04:00) Baku").Name == "Asia/Baku");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+02:00) Amman").Name == "Asia/Amman");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC-06:00) Guadalajara, Mexico City, Monterrey").Name == "America/Mexico_City");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC-07:00) Chihuahua, La Paz, Mazatlan").Name == "America/Chihuahua");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+02:00) Beirut").Name == "Asia/Beirut");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC-03:00) Montevideo").Name == "America/Montevideo");
            Assert.IsTrue(OlsonTimeZone.GetInstanceFromWin32Name("(UTC+01:00) Windhoek").Name == "Africa/Windhoek");
        }

		[Test]
		public void AllAliases() 
		{
			string[] aliases = OlsonTimeZone.AllAliases;
			Assert.IsNotNull(aliases);

			Assert.IsTrue(Array.IndexOf(aliases, "AST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "BST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "CST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "EST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "IST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "JST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "MST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "NST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "PST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SST") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "VST") >= 0);

			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/AST4") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/AST4ADT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/CST6") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/CST6CDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/EST5") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/EST5EDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/HST10") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/MST7") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/MST7MDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/PST8") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/PST8PDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/YST9") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/YST9YDT") >= 0);

			Assert.IsTrue(Array.IndexOf(aliases, "US/Central") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "CST6CDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/CST6CDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "America/Chicago") == -1);

			Assert.IsTrue(Array.IndexOf(aliases, "US/Pacific") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "US/Pacific-New") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "PST8PDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "SystemV/PST8PDT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "America/Los_Angeles") == -1);

			Assert.IsTrue(Array.IndexOf(aliases, "GB") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "GB-Eire") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Europe/London") == -1);

			Assert.IsTrue(Array.IndexOf(aliases, "Poland") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Europe/Warsaw") == -1);

			Assert.IsTrue(Array.IndexOf(aliases, "Portugal") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Europe/Lisbon") == -1);

			Assert.IsTrue(Array.IndexOf(aliases, "UTC") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Zulu") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/Zulu") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Universal") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/Universal") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/UTC") == -1);

			Assert.IsTrue(Array.IndexOf(aliases, "Etc/GMT+0") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/GMT-0") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/GMT0") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/Greenwich") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "GMT") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "GMT+0") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "GMT-0") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "GMT0") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Greenwich") >= 0);
			Assert.IsTrue(Array.IndexOf(aliases, "Etc/GMT") == -1);
		}


		[Test]
		public void FindNameFromAlias() 
		{
			foreach (string alias in OlsonTimeZone.AllAliases) 
			{
				Assert.IsNotNull(OlsonTimeZone.FindNameFromAlias(alias));
			}

			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias(string.Empty) == null);

			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("CST") == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("EST") == "America/Indianapolis");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("MST") == "America/Phoenix");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("PST") == "America/Los_Angeles");

			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("UTC") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Zulu") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/Zulu") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Universal") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/Universal") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/UTC") == null);

			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/GMT+0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/GMT-0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/GMT0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/Greenwich") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("GMT") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("GMT+0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("GMT-0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("GMT0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Greenwich") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias("Etc/GMT") == null);
		}


		[Test]
		public void GetNameFromAlias() 
		{
			foreach (string alias in OlsonTimeZone.AllAliases) 
			{
				Assert.IsNotNull(OlsonTimeZone.GetNameFromAlias(alias));
			}

			Assert.IsTrue(OlsonTimeZone.FindNameFromAlias(string.Empty) == null);

			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("CST") == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("EST") == "America/Indianapolis");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("MST") == "America/Phoenix");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("PST") == "America/Los_Angeles");

			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("UTC") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Zulu") == "Etc/Zulu");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/Zulu") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Universal") == "Etc/Universal");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/Universal") == "Etc/UTC");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/UTC") == null);

			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/GMT+0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/GMT-0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/GMT0") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/Greenwich") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("GMT") == "Etc/GMT");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("GMT+0") == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("GMT-0") == "Etc/GMT-0");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("GMT0") == "Etc/GMT0");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Greenwich") == "Etc/Greenwich");
			Assert.IsTrue(OlsonTimeZone.GetNameFromAlias("Etc/GMT") == null);
		}


		[Test]
		public void GetInstanceFromAlias() 
		{
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAlias("ACT").Name == "Australia/Darwin");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAlias("CST").Name == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAlias("EST").Name == "America/Indianapolis");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAlias("MST").Name == "America/Phoenix");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAlias("PST").Name == "America/Los_Angeles");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAlias("Zulu").Name == "Etc/UTC");
		}


		[Test]
		public void LookupName() 
		{
			Assert.IsTrue(OlsonTimeZone.LookupName(string.Empty) == null);
			Assert.IsTrue(OlsonTimeZone.LookupName("CST") == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.LookupName("EST") == "EST");
			Assert.IsTrue(OlsonTimeZone.LookupName("MST") == "MST");
			Assert.IsTrue(OlsonTimeZone.LookupName("PST") == "America/Los_Angeles");

			Assert.IsTrue(OlsonTimeZone.LookupName("Eastern Standard Time") == "America/New_York");
			Assert.IsTrue(OlsonTimeZone.LookupName("Central Standard Time") == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.LookupName("Mountain Standard Time") == "America/Denver");
			Assert.IsTrue(OlsonTimeZone.LookupName("Pacific Standard Time") == "America/Los_Angeles");
			Assert.IsTrue(OlsonTimeZone.LookupName("US Mountain Standard Time") == "America/Phoenix");

			Assert.IsTrue(OlsonTimeZone.LookupName("(UTC-05:00) Eastern Time (US & Canada)") == "America/New_York");
			Assert.IsTrue(OlsonTimeZone.LookupName("(UTC-06:00) Central Time (US & Canada)") == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.LookupName("(UTC-07:00) Mountain Time (US & Canada)") == "America/Denver");
			Assert.IsTrue(OlsonTimeZone.LookupName("(UTC-08:00) Pacific Time (US & Canada)") == "America/Los_Angeles");
			Assert.IsTrue(OlsonTimeZone.LookupName("(UTC-07:00) Arizona") == "America/Phoenix");

			Assert.IsTrue(OlsonTimeZone.LookupName("EEST") == "Europe/Istanbul");
			Assert.IsTrue(OlsonTimeZone.LookupName("CEST") == "Europe/Rome");
			Assert.IsTrue(OlsonTimeZone.LookupName("WEST") == "Europe/Lisbon");
			Assert.IsTrue(OlsonTimeZone.LookupName("MSD") == "Europe/Moscow");

			Assert.IsTrue(OlsonTimeZone.LookupName("ADT") == "America/Halifax");
			Assert.IsTrue(OlsonTimeZone.LookupName("EDT") == "America/New_York");
			Assert.IsTrue(OlsonTimeZone.LookupName("CDT") == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.LookupName("MDT") == "America/Denver");
			Assert.IsTrue(OlsonTimeZone.LookupName("PDT") == "America/Vancouver");
			Assert.IsTrue(OlsonTimeZone.LookupName("AKDT") == "America/Anchorage");
			Assert.IsTrue(OlsonTimeZone.LookupName("HADT") == "America/Adak");

			Assert.IsTrue(OlsonTimeZone.LookupName("N") == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.LookupName("Z") == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.LookupName("A") == "Etc/GMT-1");

			Assert.IsTrue(OlsonTimeZone.LookupName("November Time Zone") == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.LookupName("Zulu Time Zone") == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.LookupName("Alpha Time Zone") == "Etc/GMT-1");
		}


		[Test]
		public void GetInstance() 
		{
			Assert.IsTrue(OlsonTimeZone.GetInstance("CST").Name == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.GetInstance("EST").Name == "EST");
			Assert.IsTrue(OlsonTimeZone.GetInstance("MST").Name == "MST");
			Assert.IsTrue(OlsonTimeZone.GetInstance("PST").Name == "America/Los_Angeles");

			Assert.IsTrue(OlsonTimeZone.GetInstance("Eastern Standard Time").Name == "America/New_York");
			Assert.IsTrue(OlsonTimeZone.GetInstance("Central Standard Time").Name == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.GetInstance("Mountain Standard Time").Name == "America/Denver");
			Assert.IsTrue(OlsonTimeZone.GetInstance("Pacific Standard Time").Name == "America/Los_Angeles");
			Assert.IsTrue(OlsonTimeZone.GetInstance("US Mountain Standard Time").Name == "America/Phoenix");

			Assert.IsTrue(OlsonTimeZone.GetInstance("(UTC-05:00) Eastern Time (US & Canada)").Name == "America/New_York");
			Assert.IsTrue(OlsonTimeZone.GetInstance("(UTC-06:00) Central Time (US & Canada)").Name == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.GetInstance("(UTC-07:00) Mountain Time (US & Canada)").Name == "America/Denver");
			Assert.IsTrue(OlsonTimeZone.GetInstance("(UTC-08:00) Pacific Time (US & Canada)").Name == "America/Los_Angeles");
			Assert.IsTrue(OlsonTimeZone.GetInstance("(UTC-07:00) Arizona").Name == "America/Phoenix");

			Assert.IsTrue(OlsonTimeZone.GetInstance("EEST").Name == "Europe/Istanbul");
			Assert.IsTrue(OlsonTimeZone.GetInstance("CEST").Name == "Europe/Rome");
			Assert.IsTrue(OlsonTimeZone.GetInstance("WEST").Name == "Europe/Lisbon");
			Assert.IsTrue(OlsonTimeZone.GetInstance("MSD").Name == "Europe/Moscow");

			Assert.IsTrue(OlsonTimeZone.GetInstance("ADT").Name == "America/Halifax");
			Assert.IsTrue(OlsonTimeZone.GetInstance("EDT").Name == "America/New_York");
			Assert.IsTrue(OlsonTimeZone.GetInstance("CDT").Name == "America/Chicago");
			Assert.IsTrue(OlsonTimeZone.GetInstance("MDT").Name == "America/Denver");
			Assert.IsTrue(OlsonTimeZone.GetInstance("PDT").Name == "America/Vancouver");
			Assert.IsTrue(OlsonTimeZone.GetInstance("AKDT").Name == "America/Anchorage");
			Assert.IsTrue(OlsonTimeZone.GetInstance("HADT").Name == "America/Adak");

			Assert.IsTrue(OlsonTimeZone.GetInstance("N").Name == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.GetInstance("Z").Name == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.GetInstance("A").Name == "Etc/GMT-1");

			Assert.IsTrue(OlsonTimeZone.GetInstance("November Time Zone").Name == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.GetInstance("Zulu Time Zone").Name == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.GetInstance("Alpha Time Zone").Name == "Etc/GMT-1");
		}


		[Test]
		public void AllRegistryDisplayNames() 
		{
			string[] regDisplayNames = OlsonTimeZone.AllRegistryWin32Names;
			Assert.IsNotNull(regDisplayNames);
			foreach(string regDisplayName in regDisplayNames) 
			{
				string olsonName = OlsonTimeZone.GetNameFromRegistryWin32Name(regDisplayName);
				Assert.IsNotNull(olsonName);
				OlsonTimeZone tz = OlsonTimeZone.GetInstanceFromRegistryWin32Name(regDisplayName);
				Assert.IsNotNull(tz);
				Assert.AreEqual(olsonName, tz.Name);
			}
		}

		[Test]
		public void	AllPrimaryAbbreviations() 
		{
			// Europe
			string[] abbreviations = OlsonTimeZone.AllPrimaryAbbreviations;
			Assert.IsTrue(Array.IndexOf(abbreviations, "EET") >= 0);		// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "EEST") >= 0);		// Eastern European Summer Time Europe UTC + 3 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CET") >= 0);		// Central European Time Europe UTC + 1 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CEST") >= 0);		// Central European Summer Time Europe UTC + 2 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "WET") >= 0);		// Western European Time Europe UTC 
			Assert.IsTrue(Array.IndexOf(abbreviations, "WEST") >= 0);		// Western European Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "GMT") >= 0);		// Greenwich Mean Time Europe UTC 
			Assert.IsTrue(Array.IndexOf(abbreviations, "BST") >= 0);		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "MSK") >= 0);		// Moscow Time Europe UTC + 3 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "MSD") >= 0);		// Moscow Summer Time Europe UTC + 4 hour 

			// North America
			Assert.IsTrue(Array.IndexOf(abbreviations, "AST") >= 0);		// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "ADT") >= 0);		// Atlantic Daylight Time North America UTC - 3 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "EST") >= 0);		// Eastern Standard Time North America UTC - 5 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "EDT") >= 0);		// Eastern Daylight Time North America UTC - 4 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CST") >= 0);		// Central Daylight Time North America UTC - 5 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CDT") >= 0);		// Central Standard Time North America UTC - 6 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "MST") >= 0);		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(Array.IndexOf(abbreviations, "MDT") >= 0);		// Mountain Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "PST") >= 0);		// Pacific Standard Time North America UTC - 8 hours   
			Assert.IsTrue(Array.IndexOf(abbreviations, "PDT") >= 0);		// Pacific Daylight Time North America UTC - 7 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "AKST") >= 0);		// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "AKDT") >= 0);		// Alaska Daylight Time North America UTC - 8 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "HAST") >= 0);		// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "HADT") >= 0);		// Hawaii-Aleutian Daylight Time North America UTC - 9 hours 
		}

		[Test]
		public void	AllAbbreviations() 
		{
			// Europe
			string[] abbreviations = OlsonTimeZone.AllAbbreviations;
			Assert.IsTrue(Array.IndexOf(abbreviations, "EET+02:00") >= 0);		// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "EEST+03:00") >= 0);		// Eastern European Summer Time Europe UTC + 3 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CET+01:00") >= 0);		// Central European Time Europe UTC + 1 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CEST+02:00") >= 0);		// Central European Summer Time Europe UTC + 2 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "WET+00:00") >= 0);		// Western European Time Europe UTC 
			Assert.IsTrue(Array.IndexOf(abbreviations, "WEST+01:00") >= 0);		// Western European Summer Time Europe UTC + 1 hour
			Assert.IsTrue(Array.IndexOf(abbreviations, "GMT+00:00") >= 0);		// Greenwich Mean Time Europe UTC 
			Assert.IsTrue(Array.IndexOf(abbreviations, "BST+01:00") >= 0);		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "MSK+03:00") >= 0);		// Moscow Time Europe UTC + 3 hour 
			Assert.IsTrue(Array.IndexOf(abbreviations, "MSD+04:00") >= 0);		// Moscow Summer Time Europe UTC + 4 hour 


			// North America
			Assert.IsTrue(Array.IndexOf(abbreviations, "AST-04:00") >= 0);		// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "ADT-03:00") >= 0);		// Atlantic Daylight Time North America UTC - 3 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "EST-05:00") >= 0);		// Eastern Standard Time North America UTC - 5 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "EDT-04:00") >= 0);		// Eastern Daylight Time North America UTC - 4 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CST-06:00") >= 0);		// Central Standard Time North America UTC - 6 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "CDT-05:00") >= 0);		// Central Daylight Time North America UTC - 5 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "MST-07:00") >= 0);		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(Array.IndexOf(abbreviations, "MDT-06:00") >= 0);		// Mountain Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "PST-08:00") >= 0);		// Pacific Standard Time North America UTC - 8 hours   
			Assert.IsTrue(Array.IndexOf(abbreviations, "PDT-07:00") >= 0);		// Pacific Daylight Time North America UTC - 7 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "AKST-09:00") >= 0);		// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "AKDT-08:00") >= 0);		// Alaska Daylight Time North America UTC - 8 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "HAST-10:00") >= 0);		// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
			Assert.IsTrue(Array.IndexOf(abbreviations, "HADT-09:00") >= 0);		// Hawaii-Aleutian Daylight Time North America UTC - 9 hours 
		}

		[Test]
		public void	GetNameFromAbbreviation() 
		{
			//Europe
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EET") == "Europe/Istanbul");		// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EEST") == "Europe/Istanbul");		// Eastern European Summer Time Europe UTC + 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CET") == "Europe/Rome");			// Central European Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CEST") == "Europe/Rome");			// Central European Summer Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("WET") == "Europe/Lisbon");			// Western European Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("WEST") == "Europe/Lisbon");		// Western European Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("GMT") == "Europe/Belfast");		// Greenwich Mean Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("BST") == "Europe/Belfast");		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MSK") == "Europe/Moscow");			// Moscow Time Europe UTC + 3 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MSD") == "Europe/Moscow");			// Moscow Summer Time Europe UTC + 4 hour 

			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EET+02:00") == "Europe/Istanbul");		// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EEST+03:00") == "Europe/Istanbul");	// Eastern European Summer Time Europe UTC + 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CET+01:00") == "Europe/Rome");			// Central European Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CEST+02:00") == "Europe/Rome");		// Central European Summer Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("WET+00:00") == "Europe/Lisbon");		// Western European Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("WEST+01:00") == "Europe/Lisbon");		// Western European Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("GMT+00:00") == "Europe/Belfast");		// Greenwich Mean Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("BST+01:00") == "Europe/Belfast");		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MSK+03:00") == "Europe/Moscow");		// Moscow Time Europe UTC + 3 hour 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MSD+04:00") == "Europe/Moscow");		// Moscow Summer Time Europe UTC + 4 hour 

			//America
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("AST") == "America/Halifax");		// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("ADT") == "America/Halifax");		// Atlantic Daylight Time North America UTC - 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EST") == "America/New_York");		// Eastern Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EDT") == "America/New_York");		// Eastern Daylight Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CST") == "America/Chicago");		// Central Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CDT") == "America/Chicago");		// Central Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MST") == "America/Denver");		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MDT") == "America/Denver");		// Mountain Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("PST") == "America/Vancouver");		// Pacific Standard Time North America UTC - 8 hours   
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("PDT") == "America/Vancouver");		// Pacific Daylight Time North America UTC - 7 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("AKST") == "America/Anchorage");	// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("AKDT") == "America/Anchorage");	// Alaska Daylight Time North America UTC - 8 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("HAST") == "America/Adak");			// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("HADT") == "America/Adak");			// Hawaii-Aleutian Daylight Time North America UTC - 9 hours 

			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("AST-04:00") == "America/Halifax");		// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("ADT-03:00") == "America/Halifax");		// Atlantic Daylight Time North America UTC - 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EST-05:00") == "America/New_York");	// Eastern Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("EDT-04:00") == "America/New_York");	// Eastern Daylight Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CST-06:00") == "America/Chicago");		// Central Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("CDT-05:00") == "America/Chicago");		// Central Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MST-07:00") == "America/Denver");		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("MDT-06:00") == "America/Denver");		// Mountain Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("PST-08:00") == "America/Vancouver");	// Pacific Daylight Time North America UTC - 8 hours
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("PDT-07:00") == "America/Vancouver");	// Pacific Daylight Time North America UTC - 7 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("AKST-09:00") == "America/Anchorage");	// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("AKDT-08:00") == "America/Anchorage");	// Alaska Daylight Time North America UTC - 8 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("HAST-10:00") == "America/Adak");		// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
			Assert.IsTrue(OlsonTimeZone.GetNameFromAbbreviation("HADT-09:00") == "America/Adak");		// Hawaii-Aleutian Daylight Time North America UTC - 9 hours 
		}

		[Test]
		public void	GetInstanceFromAbbreviation() 
		{
			//Europe
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EET").Name == "Europe/Istanbul");		// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EEST").Name == "Europe/Istanbul");		// Eastern European Summer Time Europe UTC + 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CET").Name == "Europe/Rome");			// Central European Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CEST").Name == "Europe/Rome");			// Central European Summer Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("WET").Name == "Europe/Lisbon");		// Western European Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("WEST").Name == "Europe/Lisbon");		// Western European Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("GMT").Name == "Europe/Belfast");		// Greenwich Mean Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("BST").Name == "Europe/Belfast");		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MSK").Name == "Europe/Moscow");		// Moscow Time Europe UTC + 3 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MSD").Name == "Europe/Moscow");		// Moscow Summer Time Europe UTC + 4 hour 

			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EET+02:00").Name == "Europe/Istanbul");	// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EEST+03:00").Name == "Europe/Istanbul");	// Eastern European Summer Time Europe UTC + 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CET+01:00").Name == "Europe/Rome");		// Central European Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CEST+02:00").Name == "Europe/Rome");		// Central European Summer Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("WET+00:00").Name == "Europe/Lisbon");		// Western European Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("WEST+01:00").Name == "Europe/Lisbon");		// Western European Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("GMT+00:00").Name == "Europe/Belfast");		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("BST+01:00").Name == "Europe/Belfast");		// British Summer Time Europe UTC + 1 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MSK+03:00").Name == "Europe/Moscow");		// Moscow Time Europe UTC + 3 hour 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MSD+04:00").Name == "Europe/Moscow");		// Moscow Summer Time Europe UTC + 4 hour 

			//America
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("AST").Name == "America/Halifax");		// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("ADT").Name == "America/Halifax");		// Atlantic Daylight Time North America UTC - 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EST").Name == "America/New_York");		// Eastern Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EDT").Name == "America/New_York");		// Eastern Daylight Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CST").Name == "America/Chicago");		// Central Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CDT").Name == "America/Chicago");		// Central Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MST").Name == "America/Denver");		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MDT").Name == "America/Denver");		// Mountain Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("PST").Name == "America/Vancouver");	// Pacific Standard Time North America UTC - 8 hours   
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("PDT").Name == "America/Vancouver");	// Pacific Daylight Time North America UTC - 7 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("AKST").Name == "America/Anchorage");	// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("AKDT").Name == "America/Anchorage");	// Alaska Daylight Time North America UTC - 8 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("HAST").Name == "America/Adak");		// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("HADT").Name == "America/Adak");		// Hawaii-Aleutian Daylight Time North America UTC - 9 hours 

			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("AST-04:00").Name == "America/Halifax");	// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("ADT-03:00").Name == "America/Halifax");	// Atlantic Daylight Time North America UTC - 3 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EST-05:00").Name == "America/New_York");	// Eastern Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("EDT-04:00").Name == "America/New_York");	// Eastern Daylight Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CST-06:00").Name == "America/Chicago");	// Central Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("CDT-05:00").Name == "America/Chicago");	// Central Standard Time North America UTC - 5 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MST-07:00").Name == "America/Denver");		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("MDT-06:00").Name == "America/Denver");		// Mountain Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("PST-08:00").Name == "America/Vancouver");	// Pacific Daylight Time North America UTC - 8 hours
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("PDT-07:00").Name == "America/Vancouver");	// Pacific Daylight Time North America UTC - 7 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("AKST-09:00").Name == "America/Anchorage");	// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("AKDT-08:00").Name == "America/Anchorage");	// Alaska Daylight Time North America UTC - 8 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("HAST-10:00").Name == "America/Adak");		// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromAbbreviation("HADT-09:00").Name == "America/Adak");		// Hawaii-Aleutian Daylight Time North America UTC - 9 hours 
		}

		[Test]
		public void	StandardAbbreviation() 
		{
			//Europe
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Istanbul").StandardAbbreviation == "EET");		// Eastern European Time Europe UTC + 2 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Rome").StandardAbbreviation == "CET");			// Central European Time Europe UTC + 1 hour 	
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Lisbon").StandardAbbreviation == "WET");		// Western European Time Europe UTC 	
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Belfast").StandardAbbreviation == "GMT");		// Greenwich Mean Time Europe UTC 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("Europe/Moscow").StandardAbbreviation == "MSK");		// Moscow Time Europe UTC + 3 hour 

			//America
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Halifax").StandardAbbreviation == "AST");		// Atlantic Standard Time North America UTC - 4 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/New_York").StandardAbbreviation == "EST");	// Eastern Standard Time North America UTC - 5 hours 		
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Chicago").StandardAbbreviation == "CST");		// Central Daylight Time North America UTC - 6 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Denver").StandardAbbreviation == "MST");		// Mountain Standard Time North America UTC - 7 hours  
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Vancouver").StandardAbbreviation == "PST");	// Pacific Standard Time North America UTC - 8 hours   
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Anchorage").StandardAbbreviation == "AKST");	// Alaska Standard Time North America UTC - 9 hours 
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromOlsonName("America/Adak").StandardAbbreviation == "HAST");		// Hawaii-Aleutian Standard Time North America UTC - 10 hours 
		}

		[Test]
		public void	AbbreviationOfAllInstances() 
		{
			foreach(string olsonName in OlsonTimeZone.AllNames) 
			{
				Assert.IsNotNull(OlsonTimeZone.GetInstanceFromOlsonName(olsonName).StandardAbbreviation);
			}
		}

		[Test]
		public void	AllMilitaryLetters()
		{
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "Y") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "X") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "W") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "V") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "U") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "T") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "S") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "R") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "Q") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "P") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "O") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "N") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "Z") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "A") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "B") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "C") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "D") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "E") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "F") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "G") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "H") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "I") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "K") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "L") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryLetters, "M") >= 0);
		}

		[Test]
		public void	AllMilitaryNames()
		{
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Romeo Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Sierra Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Papa Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Quebec Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Victor Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Whiskey Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Tango Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Uniform Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Kilo Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Hotel Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "India Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "November Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Oscar Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Lima Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Mike Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Bravo Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Charlie Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Alpha Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Foxtrot Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Golf Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Delta Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Echo Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Zulu Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "X-ray Time Zone") >= 0);
			Assert.IsTrue(Array.IndexOf(OlsonTimeZone.AllMilitaryNames, "Yankee Time Zone") >= 0);
		}

		[Test]
		public void GetNameFromMilitaryLetter()
		{
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("Y") == "Etc/GMT+12");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("X") == "Etc/GMT+11");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("W") == "Etc/GMT+10");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("V") == "Etc/GMT+9");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("U") == "Etc/GMT+8");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("T") == "Etc/GMT+7");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("S") == "Etc/GMT+6");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("R") == "Etc/GMT+5");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("Q") == "Etc/GMT+4");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("P") == "Etc/GMT+3");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("O") == "Etc/GMT+2");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("N") == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("Z") == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("A") == "Etc/GMT-1");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("B") == "Etc/GMT-2");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("C") == "Etc/GMT-3");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("D") == "Etc/GMT-4");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("E") == "Etc/GMT-5");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("F") == "Etc/GMT-6");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("G") == "Etc/GMT-7");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("H") == "Etc/GMT-8");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("I") == "Etc/GMT-9");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("K") == "Etc/GMT-10");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("L") == "Etc/GMT-11");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryLetter("M") == "Etc/GMT-12");
		}

		[Test]
		public void GetNameFromMilitaryName()
		{
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Yankee Time Zone") == "Etc/GMT+12");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("X-ray Time Zone") == "Etc/GMT+11");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Whiskey Time Zone") == "Etc/GMT+10");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Victor Time Zone") == "Etc/GMT+9");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Uniform Time Zone") == "Etc/GMT+8");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Tango Time Zone") == "Etc/GMT+7");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Sierra Time Zone") == "Etc/GMT+6");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Romeo Time Zone") == "Etc/GMT+5");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Quebec Time Zone") == "Etc/GMT+4");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Papa Time Zone") == "Etc/GMT+3");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Oscar Time Zone") == "Etc/GMT+2");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("November Time Zone") == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Zulu Time Zone") == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Alpha Time Zone") == "Etc/GMT-1");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Bravo Time Zone") == "Etc/GMT-2");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Charlie Time Zone") == "Etc/GMT-3");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Delta Time Zone") == "Etc/GMT-4");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Echo Time Zone") == "Etc/GMT-5");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Foxtrot Time Zone") == "Etc/GMT-6");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Golf Time Zone") == "Etc/GMT-7");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Hotel Time Zone") == "Etc/GMT-8");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("India Time Zone") == "Etc/GMT-9");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Kilo Time Zone") == "Etc/GMT-10");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Lima Time Zone") == "Etc/GMT-11");
			Assert.IsTrue(OlsonTimeZone.GetNameFromMilitaryName("Mike Time Zone") == "Etc/GMT-12");			
		}

		[Test]
		public void GetInstanceFromMilitaryLetter()
		{
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("Y").Name == "Etc/GMT+12");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("X").Name == "Etc/GMT+11");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("W").Name == "Etc/GMT+10");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("V").Name == "Etc/GMT+9");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("U").Name == "Etc/GMT+8");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("T").Name == "Etc/GMT+7");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("S").Name == "Etc/GMT+6");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("R").Name == "Etc/GMT+5");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("Q").Name == "Etc/GMT+4");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("P").Name == "Etc/GMT+3");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("O").Name == "Etc/GMT+2");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("N").Name == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("Z").Name == "Etc/GMT+0");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("A").Name == "Etc/GMT-1");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("B").Name == "Etc/GMT-2");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("C").Name == "Etc/GMT-3");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("D").Name == "Etc/GMT-4");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("E").Name == "Etc/GMT-5");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("F").Name == "Etc/GMT-6");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("G").Name == "Etc/GMT-7");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("H").Name == "Etc/GMT-8");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("I").Name == "Etc/GMT-9");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("K").Name == "Etc/GMT-10");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("L").Name == "Etc/GMT-11");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryLetter("M").Name == "Etc/GMT-12");
		}

		[Test]
		public void GetInstanceFromMilitaryName()
		{
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Alpha Time Zone").Name == "Etc/GMT-1");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Bravo Time Zone").Name == "Etc/GMT-2");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Charlie Time Zone").Name == "Etc/GMT-3");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Delta Time Zone").Name == "Etc/GMT-4");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Echo Time Zone").Name == "Etc/GMT-5");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Foxtrot Time Zone").Name == "Etc/GMT-6");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Golf Time Zone").Name == "Etc/GMT-7");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Hotel Time Zone").Name == "Etc/GMT-8");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("India Time Zone").Name == "Etc/GMT-9");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Kilo Time Zone").Name == "Etc/GMT-10");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Lima Time Zone").Name == "Etc/GMT-11");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Mike Time Zone").Name == "Etc/GMT-12");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("November Time Zone").Name == "Etc/GMT+1");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Oscar Time Zone").Name == "Etc/GMT+2");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Papa Time Zone").Name == "Etc/GMT+3");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Quebec Time Zone").Name == "Etc/GMT+4");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Romeo Time Zone").Name == "Etc/GMT+5");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Sierra Time Zone").Name == "Etc/GMT+6");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Tango Time Zone").Name == "Etc/GMT+7");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Uniform Time Zone").Name == "Etc/GMT+8");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Victor Time Zone").Name == "Etc/GMT+9");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Whiskey Time Zone").Name == "Etc/GMT+10");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("X-ray Time Zone").Name == "Etc/GMT+11");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Yankee Time Zone").Name == "Etc/GMT+12");
			Assert.IsTrue(OlsonTimeZone.GetInstanceFromMilitaryName("Zulu Time Zone").Name == "Etc/GMT+0");
		}

		[Test]
		public void	GetMilitaryNameFromLetter()
		{
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("Y") == "Yankee Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("X") == "X-ray Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("W") == "Whiskey Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("V") == "Victor Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("U") == "Uniform Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("T") == "Tango Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("S") == "Sierra Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("R") == "Romeo Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("Q") == "Quebec Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("P") == "Papa Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("O") == "Oscar Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("N") == "November Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("Z") == "Zulu Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("A") == "Alpha Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("B") == "Bravo Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("C") == "Charlie Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("D") == "Delta Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("E") == "Echo Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("F") == "Foxtrot Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("G") == "Golf Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("H") == "Hotel Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("I") == "India Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("K") == "Kilo Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("L") == "Lima Time Zone");
			Assert.IsTrue(OlsonTimeZone.GetMilitaryNameFromLetter("M") == "Mike Time Zone");
		}
	}
}
