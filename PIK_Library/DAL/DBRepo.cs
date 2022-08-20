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
        
        public string GetPersonNumber()
        {
            var tblNumber = SqlHelper.ExecuteDataset(CS, nameof(GetPersonNumber)).Tables[0];

            if (tblNumber.Rows.Count == 0) return "0001";

            DataRow row = tblNumber.Rows[0];

            string lastcode = row[nameof(User.PersonCode)].ToString();

            int number = int.Parse(lastcode.Substring(lastcode.Length - 4));
            number ++;

            string returnNum = number.ToString();
            while (returnNum.Length != 4)
            {
                returnNum = "0" + returnNum;
            }

            return returnNum;
        }

        //-------------------------------------------------------------------------------- Worker --------------------------------------------------------------------------------

        public void DeleteWorker(User user)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(DeleteWorker),
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.OIB,
                user.Workplace);
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
            foreach (DataRow row in tblAuthors.Rows)
            {
               
                authors.Add(
                    new Author
                    {
                        ID = row["IDAuthor"].ToString(),
                        FirstName = row.IsNull("FirstName") ? string.Empty : row[nameof(Author.FirstName)].ToString(),
                        LastName = row.IsNull("LastName") ? string.Empty : row[nameof(Author.LastName)].ToString(),
                        Biography = row.IsNull("Biography") ? string.Empty : row[nameof(Author.Biography)].ToString(),
                        Description = row.IsNull("Description") ? string.Empty : row[nameof(Author.Description)].ToString(),


                    });
            }
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
            return new Author
            {
                ID = "1",
                FirstName = "pero",
                LastName = "peric"
            };
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

        //-------------------------------------------------------------------------------- Book --------------------------------------------------------------------------------

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
                        Title = row[nameof(Book.Title)].ToString(),
                        AuthorId = (int)row[nameof(Book.AuthorId)],
                        Author = LoadAuthor((int)row[nameof(Book.AuthorId)]),
                        Description = row[nameof(Book.Description)].ToString(),
                        ISBN = row[nameof(Book.ISBN)].ToString(),
                        Used = (bool)row[nameof(Book.Used)],
                        InStock = (int)row[nameof(Book.InStock)],
                        Price = (decimal)row[nameof(Book.Price)],
                        BorrowPrice = (decimal)row[nameof(Book.Price)] / 10,
                        Cover = row[nameof(Book.Cover)].ToString(),
                        Publisher = row[nameof(Book.Publisher)].ToString(),
                        Ganre = row[nameof(Book.Ganre)].ToString(),
                        Tags = row[nameof(Book.Tags)].ToString()
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
                Title = row[nameof(Book.Title)].ToString(),
                AuthorId = (int)row[nameof(Book.AuthorId)],
                Author = LoadAuthor((int)row[nameof(Book.AuthorId)]),
                Description = row[nameof(Book.Description)].ToString(),
                ISBN = row[nameof(Book.ISBN)].ToString(),
                Used = (bool)row[nameof(Book.Used)],
                InStock = (int)row[nameof(Book.InStock)],
                Price = (decimal)row[nameof(Book.Price)],
                BorrowPrice = (decimal)row[nameof(Book.Price)] / 10,
                Cover = row[nameof(Book.Cover)].ToString(),
                Publisher = row[nameof(Book.Publisher)].ToString(),
                Ganre = row[nameof(Book.Ganre)].ToString(),
                Tags = row[nameof(Book.Tags)].ToString()
            };
        }
        public Book LoadBookUsed(string title)
        {
            var tblBook = SqlHelper.ExecuteDataset(CS, nameof(LoadBookUsed), title).Tables[0];

            if (tblBook.Rows.Count == 0) return null;

            DataRow row = tblBook.Rows[0];
            return new Book
            {
                IdBook = (int)row[nameof(Book.IdBook)],
                Title = row[nameof(Book.Title)].ToString(),
                AuthorId = (int)row[nameof(Book.AuthorId)],
                Author = LoadAuthor((int)row[nameof(Book.AuthorId)]),
                Description = row[nameof(Book.Description)].ToString(),
                ISBN = row[nameof(Book.ISBN)].ToString(),
                Used = (bool)row[nameof(Book.Used)],
                InStock = (int)row[nameof(Book.InStock)],
                Price = (decimal)row[nameof(Book.Price)],
                BorrowPrice = (decimal)row[nameof(Book.Price)] / 10,
                Cover = row[nameof(Book.Cover)].ToString(),
                Publisher = row[nameof(Book.Publisher)].ToString(),
                Ganre = row[nameof(Book.Ganre)].ToString(),
                Tags = row[nameof(Book.Tags)].ToString()
            };
        }

        public void AddBook(Book book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(AddBook),
                book.Title,
                book.AuthorId,
                book.Description,
                book.ISBN,
                book.InStock,
                book.Price,
                book.Cover,
                book.Publisher,
                book.Ganre,
                book.Tags);
        }

        public void UpdateBook(Book book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(UpdateBook),
                book.IdBook,
                book.Title,
                book.AuthorId,
                book.Description,
                book.ISBN,
                book.InStock,
                book.Price,
                book.Cover,
                book.Publisher,
                book.Ganre,
                book.Tags);
        }

        public void DeleteBook(Book book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(UpdateBook),
                book.IdBook);
        }

        //-------------------------------------------------------------------------------- PurchaseBook --------------------------------------------------------------------------------
        
        public void AddPurchase(GetBook book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(AddPurchase),
                book.InStorePayment,
                book.Delivery,
                book.User.IdUser,
                book.Book.IdBook);
        }

        public void AddBorrow(GetBook book)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(AddPurchase),
                book.ReturnDate,
                book.InStorePayment,
                book.Delivery,
                book.User.IdUser,
                book.Book.IdBook);
        }

        //-------------------------------------------------------------------------------- Return Book --------------------------------------------------------------------------------

        public IList<ReturnBook> LoadReturns()
        {
            IList<ReturnBook> returnBooks = new List<ReturnBook>();

            var tblBooks = SqlHelper.ExecuteDataset(CS, nameof(LoadReturns)).Tables[0];

            foreach (DataRow row in tblBooks.Rows)
            {
                returnBooks.Add(
                    new ReturnBook
                    {
                        IdBorrow = (int)row[nameof(ReturnBook.IdBorrow)],
                        CreatedAt = DateTime.Parse(row[nameof(ReturnBook.CreatedAt)].ToString()),
                        ReturnDate = DateTime.Parse(row[nameof(ReturnBook.ReturnDate)].ToString()),
                        InStorePayment = (bool)row[nameof(ReturnBook.InStorePayment)],
                        Delivery = (bool)row[nameof(ReturnBook.Delivery)],
                        UserId = (int)row[nameof(ReturnBook.UserId)],
                        User = LoadUserId((int)row[nameof(ReturnBook.UserId)]),
                        BookId = (int)row[nameof(ReturnBook.BookId)],
                        Book = LoadBook((int)row[nameof(ReturnBook.BookId)])
                    });
            }

            return returnBooks;
        }

        public void AddReturn(ReturnBook book)
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------------------------------------------- Contact --------------------------------------------------------------------------------

        public IList<ContactUs> LoadContacts()
        {
            IList<ContactUs> contacts = new List<ContactUs>();

            var tblContacts = SqlHelper.ExecuteDataset(CS, nameof(LoadContacts)).Tables[0];

            foreach (DataRow row in tblContacts.Rows)
            {
                contacts.Add(
                    new ContactUs
                    {
                        IdContact = (int)row[nameof(ContactUs.IdContact)],
                        Name = row[nameof(ContactUs.Name)].ToString(),
                        Email = row[nameof(ContactUs.Email)].ToString(),
                        Message = row[nameof(ContactUs.Message)].ToString(),
                        Viewed = (bool)row[nameof(ContactUs.Viewed)]
                    });
            }

            return contacts;
        }

        public void AddContact(ContactUs contact)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(AddContact),
                contact.Name,
                contact.Email,
                contact.Message);
        }

        public void ContactViewed(int id)
        {
            SqlHelper.ExecuteDataset(
                CS,
                nameof(ContactViewed),
                id);
        }

        //-------------------------------------------------------------------------------- Bookstore --------------------------------------------------------------------------------

        public Bookstore LoadBookstore()
        {
            var tblBookstore = SqlHelper.ExecuteDataset(CS, nameof(LoadBookstore)).Tables[0];

            if (tblBookstore.Rows.Count == 0) return null;

            DataRow row = tblBookstore.Rows[0];

            return new Bookstore
            {
                IdBookstore = (int)row[nameof(Bookstore.IdBookstore)],
                Name = row[nameof(Bookstore.Name)].ToString(),
                Address = row[nameof(Bookstore.Address)].ToString(),
                IBAN = row[nameof(Bookstore.IBAN)].ToString()
            };
        }

        public void UpdateBookstore(Bookstore bookstore)
        {
            SqlHelper.ExecuteNonQuery(
                CS,
                nameof(UpdateBookstore),
                bookstore.IdBookstore,
                bookstore.Name,
                bookstore.Address,
                bookstore.IBAN);
        }
    }
}
