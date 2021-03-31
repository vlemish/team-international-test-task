using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TeamInternationalTestEf.Models;
using TeamInternationalTestEf.Repos;

namespace TeamInternationalTestWebApi.Middlwares
{
    public class DbInitialiationMiddleware
    {
        private readonly RequestDelegate _next;

        //private readonly IRepo<User> _repo;


        public DbInitialiationMiddleware(RequestDelegate next)
        //, IRepo<User> repo
        {
            //_repo = repo;
            _next = next;
        }


        public async Task Invoke(HttpContext context, IRepo<User> repo)
        {
            var user = new User("john", "doe", "admin", "admin");

            var isUserExist = (repo as UserRepo).GetByUsername(user.Username) != null;
            if (!isUserExist)
                (repo as UserRepo).Add(user);

            await _next(context);
        }
    }
}
