using System;
using System.Linq;
using System.Collections.Generic;

namespace ModasSeedData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // first create Locations list
            List<Location> Locations = new List<Location>()
            {
                //new Location { LocationId = 1, Name = "Front Door"},
                // TODO: Add locations
                new Location {LocationId = 1, Name = "Front Door"},
                new Location {LocationId = 2, Name = "Back Door"},
                new Location {LocationId = 3, Name = "Living Room"},
                new Location {LocationId = 4, Name = "Basement"},
                new Location {LocationId = 5, Name = "Bedroom Door"},
                new Location {LocationId = 6, Name = "Hallway"}

            };
            // create date object containing current date/time
            DateTime localDate = DateTime.Now;
            // TODO: subtract 6 months from date
            DateTime eventDate = localDate.AddMonths(-6);
            // TODO: instantiate Random class
            Random ran = new Random();
            // TODO: create list to store events (Events)
            List<Event> events = new List<Event>();
            // loop for each day in the range from 6 months ago to today
            while (eventDate < localDate)
            {
                int num = ran.Next(0, 6);

                SortedList<DateTime, Event> dailyEvent = new SortedList<DateTime, Event>();


                for (int i = 0; i < num; i++)
                {
                    int hour = ran.Next(0, 24);
                    int min = ran.Next(0, 60);
                    int sec = ran.Next(0, 60);
                    int location = ran.Next(0, Locations.Count);

                    DateTime d = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hour, min, sec);
                    Event e = new Event
                    {
                        Flagged = false,
                        Location = Locations[location],
                        LocationId = Locations[location].LocationId,
                        TimeStamp = d
                    };
                    dailyEvent.Add(d, e);
                }

                foreach(var de in dailyEvent)
                {
                    events.Add(de.Value);
                }

                eventDate = eventDate.AddDays(1);
            }

            foreach(Event e in events)
            {
                Console.WriteLine($"{e.TimeStamp}, {e.Location.Name}");
                
            }
        
        }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }

    public class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        // foreign key for location 
        public int LocationId { get; set; }
        // navigation property
        public Location Location { get; set; }
    }
}
