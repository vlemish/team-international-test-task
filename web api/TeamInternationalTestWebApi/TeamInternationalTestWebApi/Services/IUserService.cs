using System.Collections.Generic;
using TeamInternationalTestEf.Models;
using TeamInternationalTestWebApi.Models;

namespace TeamInternationalTestWebApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}
