using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("peysar/[controller]")]
    public class Peysar : ControllerBase
    {
        private readonly DataContext context;
        public Peysar(DataContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public ActionResult<string> GetPeyOfYear(){
            return "You are the peysar of the year!";
        }
    }
}