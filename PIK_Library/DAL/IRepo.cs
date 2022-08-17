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
        //---------------------User-----------------------------

        User AuthenticateUser(string username, string password);
        IList<User> LoadUsers();
        User LoadUser(string email);
        User LoadUserId(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void ResetPassword(User user);
        void DeleteUser(User user);
        string GetPersonNumber();

        //---------------------Author-----------------------------------
        int AddAuthor(Author a);
        IList<Author> LoadAuthors();
        Author LoadAuthor(int id);
        Author LoadAuthorByName(string name);
        int UpdateAuthorByName(Author a);
        int DeleteAuthorByName(string name);


        //---------------------Book------------------------------------
        IList<Book> LoadBooks();
        Book LoadBook(int id);
        Book LoadBookUsed(string title);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);

        //---------------------Worker------------------------------------
        void DeleteWorker(User user);

        //---------------------Contact------------------------------------
        IList<ContactUs> LoadContacts();
        void AddContact(ContactUs contact);
        void ContactViewed(int id);
    }
}
