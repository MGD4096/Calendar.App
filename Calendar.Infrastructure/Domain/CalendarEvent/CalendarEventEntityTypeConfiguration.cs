using System;
using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using Calendar.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Calendars.Infrastructure.Domain.CalendarEvent
{
    internal class CalendarEntityTypeConfiguration : IEntityTypeConfiguration<Calendar.Domain.CalendarEvents.CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<Calendar.Domain.CalendarEvents.CalendarEvent> builder)
        {
            builder.ToTable("calendar_event", "dbo");
            builder.HasKey(x => x.EventId);
            builder.Property<CalendarEventId>(x => x.EventId).HasColumnName("event_id");
            builder.Property<string>(x => x.EventName).HasColumnName("event_name");
            builder.Property<string>(x => x.EventDescription).HasColumnName("event_description");
            builder.Property<UserId>(x => x.Owner).HasColumnName("owner_id");
            builder.Property<Boolean>(x => x.IsRemoved).HasColumnName("is_removed");
            builder.Property<DateTime>(x => x.CreateDate).HasColumnName("create_date");
            builder.Property<DateTime?>(x => x.UpdateDate).HasColumnName("update_date");
            builder.Property<UserId>(x => x.UpdateBy).HasColumnName("update_by");
            builder.Property<UserId>(x => x.CreateBy).HasColumnName("create_by");
            builder.Property<Boolean>(x => x.AllDayEvent).HasColumnName("is_all_day_event");
            builder.Property<TimeSpan?>(x => x.NotifyBefore).HasColumnName("notify_before");
            builder.Property<DateTime>(x => x.StartDate).HasColumnName("start_date");
            builder.Property<DateTime>(x => x.EndDate).HasColumnName("end_date");
        }
    }
}
