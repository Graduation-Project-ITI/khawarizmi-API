using khawarizmi.BL.Dtos;
using khawarizmi.BL.Managers;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseOverviewController : ControllerBase
    {
        private readonly ICoursesManager _coursesManager;
        public CourseOverviewController(ICoursesManager coursesManager)
        {
            _coursesManager = coursesManager;
        }

        [HttpGet]
        [Route("/CoursePage/{courseId}")]
        public ActionResult<CourseDisplayDto?> GetCourseInfo(int courseId) 
        {
            CourseDisplayDto? course = _coursesManager.GetCourseById(courseId);
            if (course is null) return NotFound(new { message = "Can not find this course" });

            return _coursesManager.GetCourseById(courseId);
        }

        [HttpPut]
        [Route("/CoursePage/Edit")]
        public async Task<IActionResult> PutCourse([FromForm] CourseEditDto course)
        {
            course.CourseImage = await Helper.UploadImageOnCloudinary(course.File);
            _coursesManager.EditCourse(course);
            return Ok(course.Id);
        }

        [HttpDelete]
        [Route("/CoursePage/Delete/{courseId}")]
        public IActionResult DeleteCourse(int courseId)
        {
            _coursesManager.DeleteCourse(courseId);
            return Ok();
        }

        [HttpPatch]
        [Route("/CoursePage/userVote")]
        public IActionResult PatchUserCourseVote(UserCourseEditDto edit)
        {
            _coursesManager.UpdateUserCourseVote(edit.CourseId, edit.UserId, edit.Boolean);
            return Ok();
        }
        
        [HttpPatch]
        [Route("/CoursePage/userLearn")]
        public IActionResult PatchUserCourseLearn(UserCourseEditDto edit)
        {
            _coursesManager.UpdateUserCourseLearn(edit.CourseId, edit.UserId, edit.Boolean);
            return Ok();
        }
        
        [HttpPatch]
        [Route("/CoursePage/userBookmark")]
        public IActionResult PatchUserCourseBookmark(UserCourseEditDto edit)
        {
            _coursesManager.UpdateUserCourseBookmark(edit.CourseId, edit.UserId, edit.Boolean);
            return Ok();
        }

        [HttpPatch]
        [Route("/CoursePage/Publish")]
        public IActionResult PatchCoursePublish(UserCourseEditDto edit)
        {
            _coursesManager.UpdateCoursePublish(edit.CourseId, edit.UserId, edit.Boolean);
            return Ok();
        }

        [HttpPost]
        [Route("/CoursePage/Feedback")]
        public IActionResult PostCourseFeedback(FeedbackAddDto data)
        {
            _coursesManager.AddCourseFeedback(data.CourseId, data.UserId, data.Feedback);
            return Ok();
        }
    }
}
