using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters
{
    public class UserServiceAdapter : IUserService
    {
        private readonly IUserService _userService;

        public UserServiceAdapter(IUserService userService)
        {
            _userService = userService;
        }
        public string GenerateToken(string name, string email)
        {
            return _userService.GenerateToken(name, email);
        }
    }
}