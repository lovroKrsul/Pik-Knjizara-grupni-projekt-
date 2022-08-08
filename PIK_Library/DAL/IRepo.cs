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
        void AddUser(User item);
        User ResetPasswordUser(string email);

        int AddAuthor(Author a);
        IList<Author> LoadAuthors();
        Author LoadAuthorByName(string name);
        int UpdateAuthorByName(Author a);
        int DeleteAuthorByName(string name);
        
    }
}
