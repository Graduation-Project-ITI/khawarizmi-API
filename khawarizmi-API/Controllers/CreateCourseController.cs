using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using khawarizmi.BL.Dtos;
using khawarizmi.BL.Managers;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace khawarizmi_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreateCourseController : ControllerBase
{
    private readonly ITagsManager _tagsManager;
    private readonly ICoursesManager _coursesManager;
    private readonly ICategoriesManager _categoriesManager;

    public CreateCourseController(ICoursesManager coursesManager, ICategoriesManager categoriesManager, ITagsManager tagsManager)
	{
        _tagsManager = tagsManager;
        _coursesManager = coursesManager;
		_categoriesManager = categoriesManager;
    }

	[HttpGet]
	[Route("/CreateCourse/categories")]
	public ActionResult<List<CategoryReadDto>> GetCategories()
	{
		return _categoriesManager.GetAllCategories();
    }

	[HttpGet]
	[Route("/CreateCourse/{categoryId}/tags")]
    public ActionResult<List<TagReadDto>?> GetTags(int categoryId)
	{
		return _tagsManager.GetTagsByCategory(categoryId);
    }

    [HttpPost]
	[Route("/CreateCourse/{userId}")]
	public ActionResult<int> PostNewCourse([FromForm] CourseAddDto newCourse, string userId)
    {
        newCourse.Image = Helper.UploadImageOnCloudinary(newCourse.File);
        
        var NewCourseId = _coursesManager.AddNewCourse(userId, newCourse);

		return Ok(NewCourseId);
	}
}
