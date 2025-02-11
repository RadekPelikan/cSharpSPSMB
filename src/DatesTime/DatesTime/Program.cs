using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;


// days until
#if false
int HowManyDaysUntil(DateTime dateTime)
{
    if (dateTime > DateTime.Now)
        return dateTime.Subtract(DateTime.Now).Days + 1;
    return dateTime.Subtract(DateTime.Now).Days;
}

var now = DateTime.Now;
var dateUntil = now.AddDays(-40);
Console.WriteLine($"{dateUntil} will be in {HowManyDaysUntil(dateUntil)} day");
#endif

// timezones
#if false
Console.WriteLine(TimeZoneInfo.FindSystemTimeZoneById("Montevideo Standard Time"));

foreach (var systemTimeZone in TimeZoneInfo.GetSystemTimeZones())
{
    Console.WriteLine(systemTimeZone.Id);
}
#endif

// datetime string formatting
#if false
var now = DateTime.Now;
#if false
foreach (var dateTimeFormat in now.GetDateTimeFormats())
    Console.WriteLine(dateTimeFormat);
#endif
Console.WriteLine(now.ToString("MMMM dd, yyyy", 
    CultureInfo.GetCultureInfo("en-us")));
Console.WriteLine($"{now:dd.MM.yy H:mm:ss zzz}");
#endif

// Timezone exercise
#if false
var tz = TimeZoneInfo.GetSystemTimeZones()[10];
Console.WriteLine(tz.Id);

List<TimeZoneInfo> GetTimeZonesWithOffset(TimeSpan offset)
{
    return new List<TimeZoneInfo>();
}
#endif

string GetFormattedTimeNowInTimeZone(TimeZoneInfo timeZoneInfo, string format = "MMMM dd, yyyy")
{
    return "time in timezone";
}



