using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICoursesManager coursemanager;

        public AdminController(ICoursesManager _coursemanager)
        {
            coursemanager = _coursemanager;
        }

        // endpoint for getting adming statistics
        [HttpGet]
        [Route("statistics")]
        public IActionResult CardStatistics()
        {

            return Ok();
        }
        [HttpGet]
        public IActionResult GetDashInfo()
        {
            var Data=coursemanager.GetAdminDashbordinfo();
            return Ok(Data);

        }
    }
}
