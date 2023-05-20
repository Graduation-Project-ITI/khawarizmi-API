using khawarizmi.BL.Dtos;
using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesManager _courseManager;

        public CourseController(ICoursesManager courseManager)
        {
            _courseManager = courseManager;
        }
        [HttpGet]  
        [Route("/CoursesPage")]
        public ActionResult <List<AllCoursesDto>> GetAll()
        {
            return _courseManager.GetAll();

        }

        [HttpGet]
        [Route("/CoursesPerPage")]
        public ActionResult <AllAndCountDto> GetPaginationCourse(int PageNumber)
        {
            return _courseManager.GetPaginationCourse(PageNumber);
        }

        [HttpGet]
        [Route("/CourseSearch")]
        public ActionResult<AllAndCountDto> Search(string kerWord)
        {
            var x = _courseManager.Search(kerWord);
            if(x.Count ==0)
            {
                return BadRequest(new { message = "No Courses Found" });
            }
            else if (kerWord == "")
            {
                return BadRequest(new { message = "please enter text to search" });
            }
            return x;
        }
    }
}
