using Calendar.Application.Configuration.Queries;
using Dapper;
using Domain.BuildingBlocks.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents.GetCalendarEventsForCalendarQuery
{
    internal class GetCalendarEventsForCalendarQueryHandler : IQueryHandler<GetCalendarEventsForCalendarQuery, List<CalendarEventDto>>
        {
            private readonly ISqlConnectionFactory _sqlConnectionFactory;


            public GetCalendarEventsForCalendarQueryHandler(
                ISqlConnectionFactory sqlConnectionFactory
                )
            {
                _sqlConnectionFactory = sqlConnectionFactory;
            }

            public async Task<List<CalendarEventDto>> Handle(GetCalendarEventsForCalendarQuery request, CancellationToken cancellationToken)
            {
                var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QueryAsync<CalendarEventDto>(
                "SELECT " +
                $"[CalendarEvent].[event_id] AS [{nameof(CalendarEventDto.EventId)}], " +
                $"[CalendarEvent].[event_name] AS [{nameof(CalendarEventDto.EventName)}], " +
                $"[CalendarEvent].[event_description] AS [{nameof(CalendarEventDto.EventDescription)}], " +
                $"[CalendarEvent].[is_all_day_event] AS [{nameof(CalendarEventDto.AllDayEvent)}], " +
                $"[CalendarEvent].[start_date] AS [{nameof(CalendarEventDto.StartDate)}], " +
                $"[CalendarEvent].[end_date] AS [{nameof(CalendarEventDto.EndDate)}], " +
                "FROM [dbo].[calendar_event] AS [CalendarEvent] " +
                "WHERE  [CalendarEvent].[calendar_id]=@CalendarId",
                new
                {
                    CalendarId = request.CalendarId
                }
            )).AsList();
            }
        }
}
