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
        User ResetPasswordUser(string email);
        void UpdateUser(User user);
        void ResetPassword(User user);
        void DeleteUser(User user);

        int AddAuthor(Author a);
        IList<Author> LoadAuthors();
        Author LoadAuthorByName(string name);
        int UpdateAuthorByName(Author a);
        int DeleteAuthorByName(string name);
    }
}
