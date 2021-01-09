using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext context;
        public AccountController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("register")] //No API COntrller would mean that we need to specify [from] for parameters
        public async Task<ActionResult<AppUser>> Register(string username, string password){ //API Controller allows us to do this
            using HMACSHA512 hmac = new HMACSHA512(); //using keyword will ensure the new instantiated class HMACSHA512 is disposed correctly after use. (disposed IDisposable)
            AppUser user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}