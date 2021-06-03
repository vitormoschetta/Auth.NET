using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Domain.Queries.Responses;

namespace Domain.Queries.Handlers
{
    public class UserQueryHandler : IUserQueryHandler
    {
        private readonly IUserRepository _repository;
        public UserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserResponse> GetAll()
        {
            return from user in _repository.GetAll().ToList()
                   select new UserResponse(
                       user.Username,
                       user.Email,
                       user.Role,
                       user.Active,
                       user.EmailConfirm);

        }
    }
}