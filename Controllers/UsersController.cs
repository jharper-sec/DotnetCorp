using Microsoft.AspNetCore.Mvc;
using DotnetCorp.Services;

namespace DotnetCorp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string searchTermFromUser)
        {
            var users = this.userService.GetByName(searchTermFromUser);
            return View(users);
        }
    }
}