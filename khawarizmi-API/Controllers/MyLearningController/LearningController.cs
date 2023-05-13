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
    [Route("allcourses/{UserId}")]
    public async Task<ActionResult> GetAllCoursesChecked( string UserId)
    {
        var courses=  coursesManager.GetLearningCoursesById(UserId);
        return Ok(courses);
    }

    [HttpGet]
    [Route("wishlist/{UserId}")]
    public async Task<ActionResult> GetAllCoursesinWishList(string UserId)
    {
        var courses = coursesManager.GetLearningCoursesIsBookMarked(UserId);
        return Ok(courses);
    }


    [HttpGet]
    [Route("mylist/{UserId}")]
    public async Task<ActionResult> GetAllCoursesinIsLearning(string UserId)
    {
        var courses = coursesManager.GetLearningCoursesIsLearning(UserId);
        return Ok(courses);
    }
}
