namespace Domain.Commands
{
    public class UserUpdatePasswordCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}