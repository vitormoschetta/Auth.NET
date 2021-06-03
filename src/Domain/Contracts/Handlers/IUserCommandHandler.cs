using Domain.Commands;

namespace Domain.Contracts.Handlers
{
    public interface IUserCommandHandler
    {
        CommandResultToken Login(UserLoginCommand command);
        CommandResult Register(UserRegisterCommand command);
        CommandResult EmailValidate(string emailToken);
        CommandResult UpdatePassword(UserUpdatePasswordCommand command, string currentUser);
        CommandResult ResetPassword(string email);
    }
}