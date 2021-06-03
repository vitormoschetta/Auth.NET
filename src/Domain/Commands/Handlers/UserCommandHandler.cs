using System;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Utils;

namespace Domain.Commands.Handlers
{
    public class UserCommandHandler : Notifiable, IUserCommandHandler
    {
        private readonly IUserRepository _repository;
        public UserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public CommandResultToken Login(UserLoginCommand command)
        {
            var user = _repository.GetByNameOrEmail(command.Username);
            if (user == null)
                return new CommandResultToken(false, "Login inválido! ");

            var salt_tabela = user.Salt;
            byte[] salt = Convert.FromBase64String(salt_tabela);
            var hashPassword = HashGenerator.Generate(command.Password, salt); // <-- monta hash para comparação / login

            user = _repository.Login(command.Username, hashPassword);
            if (user == null)
                return new CommandResultToken(false, "Login inválido! ");
            else if (user.EmailConfirm == false)
                return new CommandResultToken(false, "Necessário validar seu e-mail! ");
            else if (user.Active == false)
                return new CommandResultToken(false, "Usuário inativo. Contacte o Administrador. ");

            user.HidePassword();

            return new CommandResultToken(true, "Login efetuado com sucesso! ", user);
        }

        public CommandResult Register(UserRegisterCommand command)
        {
            bool exist = _repository.ExistName(command.Username);
            if (exist)
                return new CommandResult(false, "Este nome já está cadastrado! ");

            exist = _repository.ExistEmail(command.Email);
            if (exist)
                return new CommandResult(false, "Este email já está cadastrado! ");

            var user = new User(command.Username, command.Email, command.Password);
            if (user.Invalid)
                return new CommandResult(false, string.Join(". ", Notifications));

            // Add Hash and Salt
            var salt = SaltGenerator.Generate();
            var hash = HashGenerator.Generate(user.Password, salt);

            user.AddHash(hash, Convert.ToBase64String(salt));
            user.AddEmailToken();

            _repository.Register(user);

            user.HidePassword();

            return new CommandResult(true, "Cadastro realizado! Valide seu e-mail. ", user);
        }

        public CommandResult EmailValidate(string emailToken)
        {
            var user = _repository.GetByEmailToken(emailToken);
            if (user == null)
                return new CommandResult(false, "Token invalido! ");

            user.EmailConfirmate();

            _repository.EmailValidate(user);

            user.HidePassword();

            return new CommandResult(true, "Email verificado com sucesso! ", user);
        }

        public CommandResult UpdatePassword(UserUpdatePasswordCommand command, string currentUser)
        {
            var user = _repository.GetByNameOrEmail(command.Username);
            if (user == null)
                return new CommandResult(false, "Login inválido! ");

            var salt_tabela = user.Salt;
            byte[] salt = Convert.FromBase64String(salt_tabela);
            var hashPassword = HashGenerator.Generate(command.Password, salt);

            if (user.Password != hashPassword)
                return new CommandResult(false, "Senha antiga não confere. ");

            // add new hash and salt
            hashPassword = HashGenerator.Generate(command.NewPassword, salt);

            user.UpdatePassword(command.NewPassword);

            if (user.Invalid)
                return new CommandResult(false, string.Join(". ", Notifications));

            _repository.UpdatePassword(user.Username, hashPassword);

            user.HidePassword();

            return new CommandResult(true, "Senha alterada com sucesso! ", user);
        }

        public CommandResult ResetPassword(string email)
        {
            var user = _repository.GetByNameOrEmail(email);
            if (user == null)
                return new CommandResult(false, "Email não encontrado. ");

            user.PasswordGenerate();
            var randomPassword = user.Password;

            // Add new Hash and Salt
            var salt = SaltGenerator.Generate();
            var hash = HashGenerator.Generate(user.Password, salt);

            user.AddHash(hash, Convert.ToBase64String(salt));

            _repository.ResetPassword(user);

            user.AddPassword(randomPassword);

            return new CommandResult(true, "Senha temporária enviada no e-mail! ", user);
        }
    }
}