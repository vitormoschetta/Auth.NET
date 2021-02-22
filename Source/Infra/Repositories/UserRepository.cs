using System;
using System.Linq;
using Dapper;
using Domain;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public string GetConnection() => AppSettings.ConnectionString;
        

        public User Login(string username, string password)
        {
            return _context.User
                .AsNoTracking()
                .FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public void Register(User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }        
        
        public void EmailValidate(User item)
        {
            string query = "";
            query += $" update UserAuth set EmailConfirm = 1, ";     
            query += $" EmailToken = '{DateTime.Now}' ";            
            query += $" where Username = '{item.Username}' ";

            using (var _dapper = new SqlConnection(GetConnection()))
            {
                _dapper.Execute(query);
            }
        }

        public bool ExistEmail(string email)
        {
            var item = _context.User
                .AsNoTracking()
                .FirstOrDefault(x => x.Email == email);

            if (item != null) return true;
            return false;
        }

        public bool ExistName(string username)
        {
            var item = _context.User
                .AsNoTracking()
                .FirstOrDefault(x => x.Username == username);

            if (item != null) return true;
            return false;
        }

        public User GetByEmailToken(string emailToken)
        {
            var item = _context.User
                .AsTracking()
                .FirstOrDefault(x => x.EmailToken == emailToken && x.EmailConfirm == false);

            return item;
        }

        public User GetByNameOrEmail(string identification)
        {
            var item = _context.User
                .AsTracking()
                .FirstOrDefault(x => x.Email == identification || x.Username == identification);

            return item;
        }

        
        public void ResetPassword(User model)
        {
            string query = "";
            query += $" update UserAuth set Password = '{model.Password}', ";  
            query += $" Salt = '{model.Salt}', ";  
            query += $" ResetPass = 1 ";            
            query += $" where Username = '{model.Username}' ";

            using (var _dapper = new SqlConnection(GetConnection()))
            {
                _dapper.Execute(query);
            }
        }

        public void UpdatePassword(string username, string password)
        {
            string query = "";
            query += $" update UserAuth set Password = '{password}' ";
            query += $" where Username = '{username}' ";

            using (var _dapper = new SqlConnection(GetConnection()))
            {
                _dapper.Execute(query);
            }
        }
    }
}