using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.BL.Dtos.Users;
using khawarizmi.BL.Managers.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersManager _userManager;

        public UserController(IUsersManager userManager)
        {
            _userManager = userManager;
        }

        // get all users
        [HttpGet]
        public ActionResult<PaginationDisplayDto<UsersDisplayDto>> GetUsers(int pageIndex, int pageSize, string searchBy = "", string orderBy = "")
        {
            Console.WriteLine(pageIndex);
            Console.WriteLine(pageSize);
            Console.WriteLine(searchBy);
            Console.WriteLine(orderBy);

            return _userManager.UserPaginator(pageIndex, searchBy, orderBy, pageSize);
        }

        [HttpDelete]
        [Route("delete-user")]
        public IActionResult Delete(string id)
        {
            _userManager.DeleteUser(id);
            return NoContent();
        }
    }
}
