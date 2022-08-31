﻿using PIK_Library.Model;
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

        //---------------------Worker------------------------------------
        void DeleteWorker(User user);

        //---------------------Author-----------------------------------
        int AddAuthor(Author a);
        IList<Author> LoadAuthors();
        Author LoadAuthorByID(int id);
        Author LoadAuthorByName(string name);
        int UpdateAuthorByName(Author a);
        int UpdateAuthorByID(Author a);
        int DeleteAuthorByName(string name);

        //---------------------Book------------------------------------
        IList<Book> LoadBooks();
        IList<Book> LoadMostPopularBooks();
        Book LoadBook(int id);
        Book LoadBookByTitle(string title);
        Book LoadBookUsed(string title);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);

        //---------------------GetBook------------------------------------
        int AddPurchase(GetBook book);
        int AddBorrow(GetBook book);
        void PayPurchase(int id);
        void PayBorrow(int id);
        GetBook LoadPurchase(int id);
        GetBook LoadBorrow(int id);

        //---------------------ReturnBook------------------------------------
        IList<ReturnBook> LoadReturns();
        ReturnBook LoadReturn(int id);
        void AddReturn(ReturnBook book);

        //---------------------Contact------------------------------------
        IList<ContactUs> LoadContacts();
        void AddContact(ContactUs contact);
        void ContactViewed(int id);

        //---------------------BookStore------------------------------------
        Bookstore LoadBookstore();
        void UpdateBookstore(Bookstore bookstore);
    }
}
