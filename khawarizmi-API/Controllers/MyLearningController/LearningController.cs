using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers.MyLearningController;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LearningController : ControllerBase
{
    private readonly ICoursesManager coursesManager;

    public LearningController( ICoursesManager coursesManager )
    {
        this.coursesManager = coursesManager;
    }

    [HttpGet]
    [Route("allcourses/{UserId}")]
    public ActionResult GetAllCoursesChecked( string UserId, int pagenumber=1)
    {
        var courses=  coursesManager.GetLearningCoursesById(UserId,pagenumber);
        return Ok(courses);
    }

    [HttpGet]
    [Route("wishlist/{UserId}")]
    public ActionResult GetAllCoursesinWishList(string UserId)
    {
        var courses = coursesManager.GetLearningCoursesIsBookMarked(UserId);
        return Ok(courses);
    }


    [HttpGet]
    [Route("mylist/{UserId}")]
    public ActionResult GetAllCoursesinIsLearning(string UserId)
    {
        var courses = coursesManager.GetLearningCoursesIsLearning(UserId);
        return Ok(courses);
    }
}
