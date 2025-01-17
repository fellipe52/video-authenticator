using Domain.Entities.Exceptions;
using Domain.Helpers;
using Domain.ValueObjects;

namespace Domain.Entities.UserAggregate
{
    public class User
    {
        private readonly Password _password;
        private readonly Email _email;

        private readonly string _name = string.Empty;
        public int Id { get; init; }

        public required string Name
        {
            get => _name;
            init
            {
                EntityArgumentNullException.ThrowIfNullOrWhiteSpace(
                    value,
                    nameof(Name),
                    GetType()
                );

                _name = value;
            }
        }

        public required Email Email
        {
            get => _email;
            init
            {
                EntityArgumentNullException.ThrowIfPropertyNull(
                    value,
                    nameof(Email),
                    GetType()
                );

                _email = value;
            }
        }


        public required Password Password
        {
            get => _password;
            init
            {
                EntityArgumentNullException.ThrowIfPropertyNull(
                    value,
                    nameof(Password),
                    GetType()
                );

                _password = value; 
            }
        }

    }
}