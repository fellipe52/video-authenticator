using Domain.Services;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Adapters
{
    public class UserServiceAdapter : IUserAdapterService
    {
        private readonly IUserService _userService;

        public UserServiceAdapter(IUserService userService)
        {
            _userService = userService;
        }
        public string GenerateToken(string name, string email)
        {
            return _userService.GenerateTokenAsync(name, email, default);
        }
    }
}