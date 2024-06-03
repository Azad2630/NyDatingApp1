using NyDatingApp1.Models;

namespace NyDatingApp1.Services
{
    public interface IUserService
    {
        Account GetUser();
        bool IsUserLoggedIn();
        bool Login(string username, string password);
        void Logout();
    }
}
