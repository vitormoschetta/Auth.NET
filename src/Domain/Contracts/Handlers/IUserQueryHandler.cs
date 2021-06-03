using System.Collections.Generic;
using Domain.Queries.Responses;

namespace Domain.Contracts.Handlers
{
    public interface IUserQueryHandler
    {
        IEnumerable<UserResponse> GetAll();
    }
}