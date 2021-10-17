using Calendar.Domain.Calendars.Events;
using Calendar.Domain.Users;
using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.Calendars
{
    public class Calendar:Entity,IAggregateRoot
    {
        private Calendar()
        {
            //for EF
        }
        private Calendar(string calendarName, string calendarDescription, UserId owner, bool isPublic, Boolean eventsCanBeModifiedBySubscriber=false)
        {
            CalendarId = new CalendarId(Guid.NewGuid());
            CalendarName = calendarName;
            CalendarDescription = calendarDescription;
            Owner = owner;
            IsPublic = isPublic;
            IsRemoved = false;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            EventsCanBeModifiedBySubscriber= eventsCanBeModifiedBySubscriber;
        }
        public static Calendar CreateNew(string calendarName, string calendarDescription, UserId owner, bool isPublic, Boolean eventsCanBeModifiedBySubscriber = false)
        {
            return new Calendar(calendarName, calendarDescription, owner, isPublic, eventsCanBeModifiedBySubscriber);
        }

        public CalendarId CalendarId { get; protected set; }
        public string CalendarName { get; protected set; }
        public string CalendarDescription { get; protected set; }
        public UserId Owner { get; protected set; }
        public Boolean IsPublic { get; protected set; }
        public Boolean IsRemoved { get; protected set; }
        public Boolean EventsCanBeModifiedBySubscriber { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public CalendarEvents.CalendarEvent AddEvent(string eventName,
            string eventDescription,
            UserId owner,
            DateTime startDate,
            DateTime endDate,
            bool allDayEvent,
            TimeSpan? notifyBefore,
            UserId createBy,
            UserId updateBy
        ) => CalendarEvents.CalendarEvent.CreateNew(
            eventName, 
            eventDescription, 
            owner, 
            this.CalendarId, 
            startDate, 
            endDate, 
            allDayEvent, 
            notifyBefore, 
            createBy, 
            updateBy
         );
        public void ChangeNameAndDescription(string name, string description)
        {
            this.CalendarName = name;
            this.CalendarDescription = description;
            this.AddDomainEvent(new CalendarMainAttributesChangedDomainEvent(this.CalendarId));
        }

        public void Remove()
        {
            this.IsRemoved = true;
            this.AddDomainEvent(new CalendarRemovedDomainEvent(this.CalendarId));
        }
    }
}
