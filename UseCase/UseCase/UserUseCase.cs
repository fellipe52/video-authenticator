using Core.Notifications;
using Domain.Entities.UserAggregate;
using Domain.Repositories;
using Domain.Services;
using UseCase.Dtos;
using UseCase.UseCase.Interfaces;

namespace UseCase.UseCase
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly NotificationContext _notificationContext;
        public UserUseCase(
            IUserRepository userRepository,
            IUserService userService,
            NotificationContext notificationContext)
        {
            _userRepository = userRepository;
            _userService = userService;
            _notificationContext = notificationContext;
        }

        public async Task CreateUserAsync(UserRequest userRequest)
        {
            var userExist = await _userRepository.GetUserAsync(userRequest.Email);

            if(userExist != null)
            {
                _notificationContext.AssertArgumentNotNull(userExist, $"O usuário já foi cadastrado");
            }

            if (_notificationContext.HasErrors)
            {
                return;
            }

            await _userRepository.CreateUserAsync(new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest.Password,
            });
        }

        public string AuthenticateUserAsync(UserRequest userRequest)
        {
            var user = _userRepository.AuthenticateUserAsync(userRequest.Email, userRequest.Password, default);

            if (user == null)
            {
                _notificationContext.AssertArgumentNotNull(user, $"O usuário {userRequest.Name} não existe.");
            }

            if (_notificationContext.HasErrors)
            {
                return string.Empty;
            }

            string token = _userService.GenerateToken(userRequest.Name, userRequest.Email);

            return token;
        }
    }
}