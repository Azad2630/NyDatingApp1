using NyDatingApp1.Models;

namespace NyDatingApp1.Services
{
    public interface IUserService
    {
        Account GetUser();
        bool IsUserLoggedIn();
        bool Login(string username, string password);
        void Logout();
        //Account GetUser();
        //bool IsUserLoggedIn();
        //bool Login(string username, string password);
        //void Logout();
        //Task<bool> CreateUserAsync(string username, string password, string email, string firstName, string lastName, string profileName, DateTime birthDate, int height, string aboutMe);
    }
}
