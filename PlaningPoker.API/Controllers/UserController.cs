using Microsoft.AspNetCore.Mvc;
using PlaningPoker.Application.Contract;

namespace PlaningPoker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; 
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost]
        //public 
        
    }
}