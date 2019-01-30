C# /.NET implementation of timezone class based on Olson database (often called tz or zoneinfo). As opposite to Win32/.NET API, it allows to perform conversion of arbitrary time between arbitrary time zones.

**Key features:**
OlsonTimeZone class which subclasses System.TimeZone
Leapsecond support
Time validation against "spring forward" and "fall back" regions
Unicode CLDR v.27.0.1 based mapping between Win32 Id and Olson name
Multiple naming scheme: TZIDs, aliases, abbreviations, Win32 ids and names, military letters and names
Latest version of tz package - 2018d
Zone explorer in demo application to allow browsing timezone data
100% managed code
ASP.NET hosting, No-touch and Click-once deployment friendly: no access to file system or registry needed, allows partially trusted callers
Freeware
