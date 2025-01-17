using Domain.Entities.UserAggregate;
using Domain.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Adapters
{
    public class UserRepositoryAdapter : IUserRepository
    {
        private readonly IUserMongoRepository _userMongoRepository;
        public UserRepositoryAdapter(IUserMongoRepository userMongoRepository)
        {
            _userMongoRepository = userMongoRepository;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _userMongoRepository.GetUserAsync(email);
        }

        public async Task CreateUserAsync(User userRequest)
        {
            await _userMongoRepository.CreateUserAsync(userRequest);
        }

        public Task<User> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken)
        {
            return _userMongoRepository.AuthenticateUserAsync(email, password);
        }
    }
}