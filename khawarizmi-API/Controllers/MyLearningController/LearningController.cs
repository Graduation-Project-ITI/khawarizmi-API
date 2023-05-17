using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers.MyLearningController;

[Route("api/[controller]")]
[ApiController]
public class LearningController : ControllerBase
{
    private readonly ICoursesManager coursesManager;

    public LearningController( ICoursesManager coursesManager )
    {
        this.coursesManager = coursesManager;
    }

    [HttpGet]
    [Route("getAllCourses")]
    public ActionResult GetAllCoursesChecked( string UserId)
    {
        var courses=  coursesManager.GetLearningCoursesById(UserId);
        return Ok(courses);
    }

    [HttpGet]
    [Route("getWishlist")]
    public ActionResult GetAllCoursesinWishList(string UserId)
    {
        var courses = coursesManager.GetLearningCoursesIsBookMarked(UserId);
        return Ok(courses);
    }


    [HttpGet]
    [Route("getLearning")]
    public ActionResult GetAllCoursesinIsLearning(string UserId)
    {
        var courses = coursesManager.GetLearningCoursesIsLearning(UserId);
        return Ok(courses);
    }
}
