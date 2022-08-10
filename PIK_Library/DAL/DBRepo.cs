using Microsoft.ApplicationBlocks.Data;
using PIK_Library.Dal;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.DAL
{
    public class DBRepo : IRepo
    {
        private static readonly string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        //-------------------------------------------------------------------------------- User --------------------------------------------------------------------------------
        public User AuthenticateUser(string username, string password)
        {
            var tblAuthenticate = SqlHelper.ExecuteDataset(CS, nameof(AuthenticateUser), username, password).Tables[0];
            if (tblAuthenticate.Rows.Count == 0) return null;

            DataRow row = tblAuthenticate.Rows[0];
            return new User
            {
                IdUser = (int)row[nameof(User.IdUser)],
                PersonCode = row[nameof(User.PersonCode)].ToString(),
                FirstName = row[nameof(User.FirstName)].ToString(),
                LastName = row[nameof(User.LastName)].ToString(),
                Email = row[nameof(User.Email)].ToString(),
                Password = row[nameof(User.Password)].ToString(),
                City = row[nameof(User.City)].ToString(),
                ZipCode = row[nameof(User.ZipCode)].ToString(),
                StreetName = row[nameof(User.StreetName)].ToString(),
                StreetNumber = row[nameof(User.StreetNumber)].ToString(),
                OIB = row[nameof(User.OIB)].ToString(),
                Workplace = row[nameof(User.Workplace)].ToString()
            };
        }

        public void ResetPassword(User user)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(ResetPassword),
                user.Email,
                user.Password);
        }

        public IList<User> LoadUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadUsers)).Tables[0];

            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(
                    new User
                    {
                        IdUser = (int)row[nameof(User.IdUser)],
                        PersonCode = row[nameof(User.PersonCode)].ToString(),
                        FirstName = row[nameof(User.FirstName)].ToString(),
                        LastName = row[nameof(User.LastName)].ToString(),
                        Email = row[nameof(User.Email)].ToString(),
                        Password = row[nameof(User.Password)].ToString(),
                        City = row[nameof(User.City)].ToString(),
                        ZipCode = row[nameof(User.ZipCode)].ToString(),
                        StreetName = row[nameof(User.StreetName)].ToString(),
                        StreetNumber = row[nameof(User.StreetNumber)].ToString(),
                        OIB = row[nameof(User.OIB)].ToString(),
                        Workplace = row[nameof(User.Workplace)].ToString()
                    });
            }

            return users;
        }


        public User LoadUser(string email)
        {
            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadUser), email).Tables[0];

            if (tblUsers.Rows.Count == 0) return null;

            DataRow row = tblUsers.Rows[0];
            return new User
            {
                IdUser = (int)row[nameof(User.IdUser)],
                PersonCode = row[nameof(User.PersonCode)].ToString(),
                FirstName = row[nameof(User.FirstName)].ToString(),
                LastName = row[nameof(User.LastName)].ToString(),
                Email = row[nameof(User.Email)].ToString(),
                Password = row[nameof(User.Password)].ToString(),
                City = row[nameof(User.City)].ToString(),
                ZipCode = row[nameof(User.ZipCode)].ToString(),
                StreetName = row[nameof(User.StreetName)].ToString(),
                StreetNumber = row[nameof(User.StreetNumber)].ToString(),
                OIB = row[nameof(User.OIB)].ToString(),
                Workplace = row[nameof(User.Workplace)].ToString()
            };
        }

        public User LoadUserId(int id)
        {
            var tblUsers = SqlHelper.ExecuteDataset(CS, nameof(LoadUserId), id).Tables[0];

            if (tblUsers.Rows.Count == 0) return null;

            DataRow row = tblUsers.Rows[0];
            return new User
            {
                IdUser = (int)row[nameof(User.IdUser)],
                PersonCode = row[nameof(User.PersonCode)].ToString(),
                FirstName = row[nameof(User.FirstName)].ToString(),
                LastName = row[nameof(User.LastName)].ToString(),
                Email = row[nameof(User.Email)].ToString(),
                Password = row[nameof(User.Password)].ToString(),
                City = row[nameof(User.City)].ToString(),
                ZipCode = row[nameof(User.ZipCode)].ToString(),
                StreetName = row[nameof(User.StreetName)].ToString(),
                StreetNumber = row[nameof(User.StreetNumber)].ToString(),
                OIB = row[nameof(User.OIB)].ToString(),
                Workplace = row[nameof(User.Workplace)].ToString()
            };
        }
        
        public void UpdateUser(User user)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(UpdateUser),
                user.IdUser,
                user.PersonCode,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.City,
                user.ZipCode,
                user.StreetName,
                user.StreetNumber,
                user.OIB,
                user.Workplace);
        }

        public void AddUser(User user)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(AddUser),
                user.PersonCode,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.City,
                user.ZipCode,
                user.StreetName,
                user.StreetNumber,
                user.OIB,
                user.Workplace);
        }

        public void DeleteUser(User user)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(DeleteUser),
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.ZipCode,
                user.StreetName,
                user.StreetNumber);
        }

        //-------------------------------------------------------------------------------- Author --------------------------------------------------------------------------------
        public int AddAuthor(Author a)
        {
            int i = 0;
            try
            {
                i = SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "AddAuthor",
               new System.Data.SqlClient.SqlParameter("@FirstName", a.FirstName),
               new System.Data.SqlClient.SqlParameter("@LastName", a.LastName),
               new System.Data.SqlClient.SqlParameter("@Description", a.Description),
               new System.Data.SqlClient.SqlParameter("@Biography", a.Biography));

            }

            catch
            {
                return -1;
            }
            return i;
        }

        public IList<Author> LoadAuthors()
        {
            IList<Author> authors = new List<Author>();
            var tblAuthors = SqlHelper.ExecuteDataset(CS, nameof(LoadAuthors)).Tables[0];
            if (tblAuthors.Rows.Count == 0) return null;

            DataRow row = tblAuthors.Rows[0];
            authors.Add(
                new Author
                {
                    ID = row["IDAuthor"].ToString(),
                    FirstName = row.IsNull("FirstName") ? string.Empty : row[nameof(Author.FirstName)].ToString(),
                    LastName = row.IsNull("LastName") ? string.Empty : row[nameof(Author.LastName)].ToString(),
                    Biography = row.IsNull("Biography") ? string.Empty : row[nameof(Author.Biography)].ToString(),
                    Description = row.IsNull("Description") ? string.Empty : row[nameof(Author.Description)].ToString(),


                });
            return authors;
        }

        public int UpdateAuthorByName(Author a)
        {
            int i = 0;
            try
            {
                i = SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, nameof(UpdateAuthorByName),
                  new System.Data.SqlClient.SqlParameter("@FirstName", a.FirstName),
                  new System.Data.SqlClient.SqlParameter("@LastName", a.LastName),
                  new System.Data.SqlClient.SqlParameter("@Description", a.Description),
                  new System.Data.SqlClient.SqlParameter("@Biography", a.Biography));
            }
            catch
            {
                return -1;
            }
            return i;
        }

        public Author LoadAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Author LoadAuthorByName(string name)
        {
            string FirstName = name.Split(' ')[0];
            string LastName = name.Split(' ').Length > 1 ? name.Split(' ')[1] : string.Empty;
            IList<Author> a = new List<Author>();
            var tblauthor = SqlHelper.ExecuteDataset(CS, nameof(LoadAuthorByName),
                new System.Data.SqlClient.SqlParameter("@FirstName", FirstName),
                new System.Data.SqlClient.SqlParameter("@LastName", LastName)).Tables[0];
            foreach (DataRow dr in tblauthor.Rows)
            {
                a.Add(new Author
                {
                    ID = dr["IDAuthor"].ToString(),
                    FirstName = dr[nameof(Author.FirstName)].ToString(),
                    LastName = dr[nameof(Author.LastName)].ToString(),
                    Description = dr[nameof(Author.Description)].ToString(),
                    Biography = dr[nameof(Author.Biography)].ToString(),

                });
            }
            return a.FirstOrDefault();
        }

        public int DeleteAuthorByName(string name)
        {
            int i = 0;
            Author a = LoadAuthorByName(name);
            try
            {
                i = SqlHelper.ExecuteNonQuery(CS, CommandType.StoredProcedure, "DeleteAuthor", new System.Data.SqlClient.SqlParameter(@"ID", a.ID));
            }
            catch
            {
                return -1;
            }

            return i;
        }

        //-------------------------------------------------------------------------------- User --------------------------------------------------------------------------------

        public IList<Book> LoadBooks()
        {
            IList<Book> books = new List<Book>();

            var tblBooks = SqlHelper.ExecuteDataset(CS, nameof(LoadBooks)).Tables[0];

            foreach (DataRow row in tblBooks.Rows)
            {
                books.Add(
                    new Book
                    {
                        IdBook = (int)row[nameof(Book.IdBook)],
                        Title = row[nameof(Book.IdBook)].ToString(),
                        Author = LoadAuthor((int)row[nameof(Book.Author)]),
                        Description = row[nameof(Book.IdBook)].ToString(),
                        IBAN = row[nameof(Book.IdBook)].ToString(),
                        Info = row[nameof(Book.IdBook)].ToString(),
                        Other = row[nameof(Book.IdBook)].ToString(),
                        Price = (double)row[nameof(Book.IdBook)]
                    });
            }

            return books;
        }

        public Book LoadBook(int id)
        {
            var tblBook = SqlHelper.ExecuteDataset(CS, nameof(LoadBook), id).Tables[0];

            if (tblBook.Rows.Count == 0) return null;

            DataRow row = tblBook.Rows[0];
            return new Book
            {
                IdBook = (int)row[nameof(Book.IdBook)],
                Title = row[nameof(Book.IdBook)].ToString(),
                Author = LoadAuthor((int)row[nameof(Book.Author)]),
                Description = row[nameof(Book.IdBook)].ToString(),
                IBAN = row[nameof(Book.IdBook)].ToString(),
                Info = row[nameof(Book.IdBook)].ToString(),
                Other = row[nameof(Book.IdBook)].ToString(),
                Price = (double)row[nameof(Book.IdBook)]
            };
        }

        public void AddBook(Book book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(AddBook),
                book.Title,
                book.Author,
                book.Description,
                book.IBAN,
                book.Info,
                book.Other,
                book.Price);
        }

        public void UpdateBook(Book book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(UpdateBook),
                book.IdBook,
                book.Title,
                book.Author,
                book.Description,
                book.IBAN,
                book.Info,
                book.Other,
                book.Price);
        }

        public void DeleteBook(Book book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(UpdateBook),
                book.IdBook);
        }
    }
}
