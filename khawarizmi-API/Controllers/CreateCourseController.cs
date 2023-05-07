using khawarizmi.BL.Dtos;
using khawarizmi.BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
	public ActionResult<List<TagReadDto>> GetTags(int categoryId)
	{
		return _tagsManager.GetTagsByCategory(categoryId);
    }
	[HttpPost]
	[Route("/CreateCourse/{userId}")]
	public IActionResult PostNewCourse(string userId, CourseAddDto newCourse)
	{
        _coursesManager.AddNewCourse(userId, newCourse);
        return NoContent();
	}
}
