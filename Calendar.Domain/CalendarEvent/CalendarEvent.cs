using Calendar.Domain.CalendarEvent.Events;
using Calendar.Domain.CalendarEvent.Rules;
using Calendar.Domain.Calendars;
using Calendar.Domain.Users;
using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.CalendarEvents
{
    public class CalendarEvent:Entity
    {
        private CalendarEvent()
        {

        }
        private CalendarEvent(string eventName, string eventDescription, UserId owner, CalendarId calendarId, DateTime startDate, DateTime endDate, bool allDayEvent, TimeSpan? notifyBefore, UserId createBy, UserId updateBy)
        {
            EventId = new CalendarEventId(Guid.NewGuid());
            EventName = eventName;
            EventDescription = eventDescription;
            Owner = owner;
            CalendarId = calendarId;
            IsRemoved = false;
            StartDate = startDate;
            EndDate = endDate;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            AllDayEvent = allDayEvent;
            NotifyBefore = notifyBefore;
            CreateBy = createBy;
            UpdateBy = updateBy;
        }
        public static CalendarEvent CreateNew(
            string eventName, 
            string eventDescription, 
            UserId owner, 
            CalendarId calendarId, 
            DateTime startDate, 
            DateTime endDate,
            bool allDayEvent, 
            TimeSpan? notifyBefore, 
            UserId createBy, 
            UserId updateBy
            )
        {
            return new CalendarEvent( eventName, eventDescription, owner, calendarId, startDate, endDate, allDayEvent, notifyBefore, createBy, updateBy);
        }

        public CalendarEventId EventId { get; protected set; }
        public string EventName { get; protected set; }
        public string EventDescription { get; protected set; }
        public UserId Owner { get; protected set; }
        public CalendarId CalendarId { get; protected set; }
        public Boolean IsRemoved { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public bool AllDayEvent { get; protected set; }
        public TimeSpan? NotifyBefore { get; protected set; }
        public UserId CreateBy { get; protected set; }
        public UserId UpdateBy { get; protected set; }
        public void ChangeMainAttributes(string eventName,string eventDescription, UserId user)
        {
            EventDescription = eventDescription;
            EventName = eventName;
            UpdateDate = DateTime.Now;
            this.UpdateBy = user;
            this.AddDomainEvent(new MainAttributeChandedDomainEvent(this.EventId));
        }
        public void ChangeDatesOfEvent(DateTime startDate,DateTime endDate, UserId user)
        {
            this.CheckRule(new StartDateMustBeBeforeEndDateRule(startDate, endDate));
            StartDate = startDate;
            EndDate = endDate;
            UpdateDate = DateTime.Now;
            this.UpdateBy = user;
            this.AddDomainEvent(new DatesOfEventChangesDomainEvent(this.EventId));
        }
        public void RemoveEvent(UserId user)
        {
            this.IsRemoved = true;
            this.UpdateBy = user;
            UpdateDate = DateTime.Now;
            this.AddDomainEvent(new EventWasRemovedDomainEvent(this.EventId));
        }
    }
}
