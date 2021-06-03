using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll(); 
        User Login(string username, string password);  
        User GetByNameOrEmail(string identification);  
        User GetByEmailToken(string emailToken);  
        void Register(User item);        
        void UpdatePassword(string username, string password);        
        void EmailValidate(User item);
        void ResetPassword(User item);
        bool ExistName(string username);
        bool ExistEmail(string email);
    }
}