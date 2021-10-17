using Calendar.Application.Configuration.Queries;
using Dapper;
using Domain.BuildingBlocks.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.GetCalendarQuery
{
    internal class GetCalendarQueryHandler : IQueryHandler<GetCalendarQuery, CalendarDetailsDto>
        {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;


        public GetCalendarQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<CalendarDetailsDto> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QuerySingleAsync<CalendarDetailsDto>(
                "SELECT " +
                $"[Calendar].[calendar_id] AS [{nameof(CalendarDetailsDto.CalendarId)}], " +
                $"[Calendar].[calendar_name] AS [{nameof(CalendarDetailsDto.Name)}], " +
                $"[Calendar].[calendar_description] AS [{nameof(CalendarDetailsDto.Description)}], " +
                $"[Calendar].[is_public] AS [{nameof(CalendarDetailsDto.IsPublic)}], " +
                "FROM [dbo].[calendar] AS [Calendar] " +
                "WHERE [Calendar].[calendar_id] = @CalendarId",
                new
                {
                    CalendarId = request.CalendarId
                }));
        }
    }
}
