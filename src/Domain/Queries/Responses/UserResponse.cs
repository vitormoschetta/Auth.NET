namespace Domain.Queries.Responses
{
    public class UserResponse
    {
        public UserResponse()
        {            
        }
        public UserResponse(string username, string email, string role, bool active, bool emailConfirm)
        {
            Username = username;
            Email = email;
            Role = role;
            Active = active;
            EmailConfirm = emailConfirm;
        }

        public string Username { get; set; }
        public string Email { get; set; }    
        public string Role { get; set; }
        public bool Active { get; set; }        
        public bool EmailConfirm { get; set; }        
    }
}