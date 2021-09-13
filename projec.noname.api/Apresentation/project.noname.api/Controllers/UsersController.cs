using Microsoft.AspNetCore.Mvc;
using project.noname.service.Interface;

namespace project.noname.api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private IUserService service;

        public UsersController(IUserService userService)
        {
            service = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = service.GetUser();

            return Response(result);

        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUser(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult AlterUser(int id)
        {
            return View();
        }
    }
}
