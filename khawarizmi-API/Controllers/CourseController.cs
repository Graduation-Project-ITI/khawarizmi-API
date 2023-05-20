using khawarizmi.BL.Dtos;
using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
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
        public ActionResult <List<AllCoursesDto>> GetPaginationCourse(int PageNumber)
        {
            return _courseManager.GetPaginationCourse(PageNumber);
        }

        // for Admin courses
        [HttpGet]
        [Route("AdminCourses")]
        public ActionResult <PaginationDisplayDto<AdminCoursesDisplayDto>> GetAdminCourses(int pageIndex, int pageSize, string searchBy="", string orderBy="")
        {
            return _courseManager.CoursePaginator(pageIndex, searchBy, orderBy, pageSize);
        }
       
    }
}
