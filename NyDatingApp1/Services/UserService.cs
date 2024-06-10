using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NyDatingApp1.Data;
using NyDatingApp1.Models;
using System.Drawing.Printing;

namespace NyDatingApp1.Services
{
    public class UserService : IUserService
    {
        private readonly datingdatabase _datingdatabase;
        private Account _currentUser;
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsLoggedIn { get; set; }

        public UserService(datingdatabase datingdatabase)
        {
            _datingdatabase = datingdatabase;
        }

        public bool Login(string username, string password)
        {
            var user = _datingdatabase.Accounts.FirstOrDefault(u => u.Login == username && u.Password == password);
            if (user != null)
            {
                _currentUser = user;
                return true;
            }
            return false;
        }

        public bool IsUserLoggedIn()
        {
            return _currentUser != null;
        }
        public Account GetUser()
        {
            return _currentUser;
        }
        public void Logout()
        {
            _currentUser = null;
        }
    }
}