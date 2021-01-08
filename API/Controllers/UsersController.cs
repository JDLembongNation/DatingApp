using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet] //When making database calls, always make asynchronous calls. 
        //Use Task<>, await keyword will wait till the result is returned. If more users make calls, a new thread is spun up.
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //IEnumerable allows to use simple iteration over collection (can use List)
        {
            return await context.Users.ToListAsync(); //await the result of the task while it is fetching the data.
        }

        [HttpGet("{id}")] //api/users/3
        public async Task<ActionResult<AppUser>> GetUser(int id) //IEnumerable allows to use simple iteration over collection (can use List)
        {
            return await context.Users.FindAsync(id);
        }
    }
}