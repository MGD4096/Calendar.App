using System;
using Calendar.Domain.Calendars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MG.Device.Infrastructure.Domain.Device
{
    internal class CalendarEntityTypeConfiguration : IEntityTypeConfiguration<Calendar.Domain.Calendars.Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar.Domain.Calendars.Calendar> builder)
        {
            builder.ToTable("Calendar", "dbo");
            //builder.HasKey(x => x.Id);
            //builder.Property<string>(x => x.Ip).HasColumnName("Id");
            //builder.OwnsOne<CalendarEvent>(y => y.Events, l =>
            //{
            //    l.Property<Guid>(x => x.CalendarEventId).HasColumnName("Id");
            //});
        }
    }
}
