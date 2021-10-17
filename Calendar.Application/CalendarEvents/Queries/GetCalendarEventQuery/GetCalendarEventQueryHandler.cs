using Calendar.Application.Configuration.Queries;
using Dapper;
using Domain.BuildingBlocks.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents.GetCalendarEventQuery
{
    internal class GetCalendarEventsForCalendarQueryHandler : IQueryHandler<GetCalendarEventQuery, CalendarEventsDetailsDto>
        {
            private readonly ISqlConnectionFactory _sqlConnectionFactory;


            public GetCalendarEventsForCalendarQueryHandler(
                ISqlConnectionFactory sqlConnectionFactory
                )
            {
                _sqlConnectionFactory = sqlConnectionFactory;
            }

            public async Task<CalendarEventsDetailsDto> Handle(GetCalendarEventQuery request, CancellationToken cancellationToken)
            {
                var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QuerySingleAsync<CalendarEventsDetailsDto>(
                "SELECT " +
                $"[CalendarEvent].[event_id] AS [{nameof(CalendarEventsDetailsDto.EventId)}], " +
                $"[CalendarEvent].[calendar_id] AS [{nameof(CalendarEventsDetailsDto.CalendarId)}], " +
                $"[CalendarEvent].[event_name] AS [{nameof(CalendarEventsDetailsDto.EventName)}], " +
                $"[CalendarEvent].[event_description] AS [{nameof(CalendarEventsDetailsDto.EventDescription)}], " +
                $"[CalendarEvent].[owner_id] AS [{nameof(CalendarEventsDetailsDto.Owner)}], " +
                $"[CalendarEvent].[is_removed] AS [{nameof(CalendarEventsDetailsDto.IsRemoved)}], " +
                $"[CalendarEvent].[is_all_day_event] AS [{nameof(CalendarEventsDetailsDto.AllDayEvent)}], " +
                $"[CalendarEvent].[notify_before] AS [{nameof(CalendarEventsDetailsDto.NotifyBefore)}], " +
                $"[CalendarEvent].[start_date] AS [{nameof(CalendarEventsDetailsDto.StartDate)}], " +
                $"[CalendarEvent].[end_date] AS [{nameof(CalendarEventsDetailsDto.EndDate)}], " +
                $"[CalendarEvent].[create_date] AS [{nameof(CalendarEventsDetailsDto.CreateDate)}], " +
                $"[CalendarEvent].[update_date] AS [{nameof(CalendarEventsDetailsDto.UpdateDate)}], " +
                "FROM [dbo].[calendar_event] AS [CalendarEvent] " +
                "WHERE  [CalendarEvent].[event_id]=@EventId",
                new
                {
                     EventId = request.EventId
                }));
            }
        }
}
