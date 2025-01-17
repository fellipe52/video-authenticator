using Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUserAsync(string email);
        public Task CreateUserAsync(User userRequest);
        public Task<User> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken);
    }
}