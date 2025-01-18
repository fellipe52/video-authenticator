namespace Domain.Services
{
    public interface IUserAdapterService
    {
        public string GenerateToken(string name, string email);
    }
}