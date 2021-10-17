using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Configuration.Commands;
using User.Domain.Users;

namespace User.Application.Users.CreateUserCommand
{
    internal class CreateNewCalendarCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        internal CreateNewCalendarCommandHandler(
            IUserRepository deviceRepository)
        {
            _userRepository = deviceRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(
                User.Domain.Users.User.CreateNew(
                    request.UserName,
                    request.ForName,
                    request.SurName,
                    request.Password
                ));
            await _userRepository.Commit();
            return Unit.Value;
        }
    }
}