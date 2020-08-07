using DotnetCorp.Models;

namespace DotnetCorp.Services
{
    public interface IUserService
    {
        UserModel[] GetByName(string namePattern);
        void ResetDatabase();
        void SeedDatabase();
    }
}