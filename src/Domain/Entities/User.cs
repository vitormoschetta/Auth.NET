using System;
using Domain.Utils;

namespace Domain.Entities
{
    public class User : Notifiable
    {
        public User() { }
        public User(
            string username, string email, string password,
            string role = "user", bool active = true,
            bool emailConfirm = false)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
            Active = active;
            EmailConfirm = emailConfirm;

            Validate();
        }        

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }
        public string EmailToken { get; private set; }
        public bool EmailConfirm { get; private set; }
        public bool ResetPass { get; private set; }


        public void AddEmailToken() => EmailToken = Guid.NewGuid().ToString();
        public void EmailConfirmate() => EmailConfirm = true;
        public void PasswordGenerate() => Password = PasswordGenerator.Generate();
        public void AddPassword(string password) => Password = password;
        public void HideEmailToken() => EmailToken = string.Empty;
        public void Activate() => Active = true;
        public void Inactivate() => Active = false;
        public void AddHash(string hash, string salt)
        {
            Password = hash;
            Salt = salt;
        }
        public void HidePassword()
        {
            Password = string.Empty;
            Salt = string.Empty;
        }
        public void UpdatePassword(string password)
        {
            Password = password;
            Validate();
        }


        public void Validate()
        {
            if (string.IsNullOrEmpty(Username))
            {
                AddNotification("Username é obrigatório! ");
                return;
            }
            if (string.IsNullOrEmpty(Email))
            {
                AddNotification("Email é obrigatório! ");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                AddNotification("Senha é obrigatória! ");
                return;
            }

            if (Username.Length < 4)
                AddNotification("Username deve conter pelo menos 4 caracteres. ");

            if (Password.Length < 6)
                AddNotification("Senha deve conter no mínimo 6 caracteres. ");
        }
    }

}