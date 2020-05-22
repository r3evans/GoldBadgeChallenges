using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class CompanyOuting
    {
        public EventType EventType { get; set; }
        public int AttendeeTotal { get; set; }
        public string EventDate { get; set; }
        public double Cost { get; set; }
        public double TotalEventCost
        {
            get
            {
                return AttendeeTotal * Cost;
            }
        }
   

        public CompanyOuting()
        {

        }

        public CompanyOuting
         (EventType eventType, int attendeeTotal, string eventDate, double cost)

        {
            EventType = eventType;
            AttendeeTotal = attendeeTotal;
            EventDate = eventDate;
            Cost = cost;
            
            
        }
    }
}
