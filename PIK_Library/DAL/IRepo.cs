using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.Dal
{
    public interface IRepo
    {
        User AuthenticateUser(string username, string password);
        IList<User> LoadUsers();
        User LoadUser(string email);
        User LoadUserId(int id);
        void AddUser(User item);
        void UpdateUser(User user);
        void ResetPassword(User user);
        void DeleteUser(User user);
    }
}
