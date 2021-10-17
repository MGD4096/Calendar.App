using Calendar.Application.Configuration.Queries;
using Dapper;
using Domain.BuildingBlocks.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.GetCalendarsForUserQuery
{
    internal class GetDeviceLogsQueryHandler : IQueryHandler<GetCalendarsForUserQuery, List<CalendarDto>>
        {
            private readonly ISqlConnectionFactory _sqlConnectionFactory;


            public GetDeviceLogsQueryHandler(
                ISqlConnectionFactory sqlConnectionFactory
                )
            {
                _sqlConnectionFactory = sqlConnectionFactory;
            }

            public async Task<List<CalendarDto>> Handle(GetCalendarsForUserQuery request, CancellationToken cancellationToken)
            {
                var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QueryAsync<CalendarDto>(
                "SELECT " +
                $"[Calendar].[calendar_id] AS [{nameof(CalendarDto.CalendarId)}], " +
                $"[Calendar].[calendar_name] AS [{nameof(CalendarDto.Name)}], " +
                $"[Calendar].[calendar_description] AS [{nameof(CalendarDto.Description)}], " +
                $"[Calendar].[is_public] AS [{nameof(CalendarDto.IsPublic)}], " +
                "FROM [dbo].[calendar] AS [Calendar] " +
                "WHERE  [Calendar].[is_removed]=@IsRemoved AND ([Calendar].[owner_id] = @Owner OR [Calendar].[is_public] =@IsPublic)",
                new
                {
                     Owner = request.UserId,
                    IsPublic=true,
                    IsRemoved=false
                })).AsList();
            }
        }
}
