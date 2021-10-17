using Dapper;
using Domain.BuildingBlocks.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Configuration.Queries;
using User.Application.Users;

namespace User.Application.Users.GetUserQuery
{
    internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
        {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;


        public GetUserQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory
            )
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            return (await connection.QuerySingleAsync<UserDto>(
                "SELECT " +
                $"[User].[user_id] AS [{nameof(UserDto.UserId)}], " +
                $"[User].[user_name] AS [{nameof(UserDto.UserName)}], " +
                $"[User].[for_name] AS [{nameof(UserDto.ForName)}], " +
                $"[User].[sur_name] AS [{nameof(UserDto.SurName)}], " +
                $"[User].[password] AS [{nameof(UserDto.Password)}], " +
                "FROM [dbo].[user] AS [User] " +
                "WHERE [User].[user_name] = @UserName AND [User].[password]=@Paswword",
                new
                {
                    UserName = request.UserName,
                    Password=request.Password
                }));
        }
    }
}
