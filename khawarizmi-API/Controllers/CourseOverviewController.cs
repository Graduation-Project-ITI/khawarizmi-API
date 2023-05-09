using khawarizmi.BL.Dtos;
using khawarizmi.BL.Managers;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseOverviewController : ControllerBase
    {
        private readonly ICoursesManager _coursesManager;
        public CourseOverviewController(ICoursesManager coursesManager)
        {
            _coursesManager = coursesManager;
        }
        [HttpGet]
        [Route("/CourseOverview/{courseId}")]
        public ActionResult<CourseDisplayDto?> GetCourseInfo(int courseId) 
        {
            return _coursesManager.GetCourseById(courseId);
        }
    }
}
