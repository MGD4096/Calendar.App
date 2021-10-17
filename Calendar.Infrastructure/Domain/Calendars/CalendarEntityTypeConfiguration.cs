using System;
using Calendar.Domain.Calendars;
using Calendar.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Calendar.Infrastructure.Domain.Calendars
{
    internal class CalendarEntityTypeConfiguration : IEntityTypeConfiguration<Calendar.Domain.Calendars.Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar.Domain.Calendars.Calendar> builder)
        {
            builder.ToTable("Calendar", "dbo");
            builder.HasKey(x => x.CalendarId);
            builder.Property<CalendarId>(x => x.CalendarId).HasColumnName("calendar_id");
            builder.Property<string>(x => x.CalendarName).HasColumnName("calendar_name");
            builder.Property<string>(x => x.CalendarDescription).HasColumnName("calendar_description");
            builder.Property<UserId>(x => x.Owner).HasColumnName("owner_id");
            builder.Property<Boolean>(x => x.IsPublic).HasColumnName("is_public");
            builder.Property<Boolean>(x => x.IsRemoved).HasColumnName("is_removed");
            builder.Property<DateTime>(x => x.CreateDate).HasColumnName("create_date");
            builder.Property<DateTime?>(x => x.UpdateDate).HasColumnName("update_date");
            builder.Property<Boolean>(x => x.EventsCanBeModifiedBySubscriber).HasColumnName("can_be_modified_by_another_user");
        }
    }
}
