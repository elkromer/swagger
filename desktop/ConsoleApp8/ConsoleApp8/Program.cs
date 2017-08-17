using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;


namespace ConsoleApp8
{
  class Program
  {
    static void Main(string[] args)
    {
      Configuration c = new Configuration();
      c.AccessToken = "ya29.GluUBItqK38qVJWkkDnENokRd6ookgpzXugfhjuaccQD7aOilts6FQhCXa_CnMi0CArqNHBI7xBvmGCWxtDyj-3TTV2huIW_Ibspt8Zb885-SkCLqpRGOz8ZFf7D";
      CalendarListApi cla = new CalendarListApi(c);
      EventsApi ea = new EventsApi(c);
      SettingsApi sa = new SettingsApi(c);
      try
      {
        //Debug.WriteLine(cla.CalendarCalendarListList(10, null, null, true, true, null, null, null, null, "Bearer ya29.GluSBHJUYN7Me9-REuvG0VroRIPjEIkgb8_n2fdYbNDowc8r_WQ-hQfDDjDzxfBjrbvp2qebASh5UvvQ-5cMrhU86dlnYX3zTewbQf1h6andqlEy1HE2UQaux2NA", true, null, null).Items[4].ToString());
        List<InlineResponse2003Items> earray = ea.CalendarEventsList("primary", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null).Items;
        Console.WriteLine("==================== LIST CAL EVENTS ====================");
        foreach (InlineResponse2003Items item in earray) {
          Console.WriteLine("Event: " + item.Start.DateTime + " -> " + item.Summary);
        }

        List<InlineResponse2006Items> carray = cla.CalendarCalendarListList(null, null, null, null, null, null, null, null, null, null, true, null, null).Items;
        Console.WriteLine("==================== LIST CALENDARS ====================");
        foreach (InlineResponse2006Items item in carray)
        {
          Console.WriteLine("Calendar: " + item.Id + " -> " + item.Description);
        }

        List<InlineResponse2007Items> sarray = sa.CalendarSettingsList(null, null, null, null,null, null, null, true, null, null).Items;
        Console.WriteLine("==================== LIST SETTINGS ====================");
        foreach (InlineResponse2007Items item in sarray)
        {
          Console.WriteLine("Setting: " + item.Id + " -> " + item.Value);
        }
      }
      catch (ApiException e)
      {
        Console.WriteLine(e.StackTrace.ToString());
      }

      Console.ReadLine();
    }
  }
}
