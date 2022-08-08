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

        //-------------------------------------------------------------------------------- Authentication --------------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------------- Load lists --------------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------------- Load single --------------------------------------------------------------------------------

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

        //-------------------------------------------------------------------------------- Data insert --------------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------------- Data update --------------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------------- Data delete --------------------------------------------------------------------------------
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
    }
}
