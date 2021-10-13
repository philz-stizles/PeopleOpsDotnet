using PeopleOps.Domain.Entities;
using System.Collections.Generic;

namespace PeopleOps.Application.Contracts.Services
{
    public interface IJwtService
    {
        public string CreateToken(Employee user, IList<string> roles);
    }
}
