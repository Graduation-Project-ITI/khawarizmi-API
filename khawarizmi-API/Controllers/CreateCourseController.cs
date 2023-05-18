using khawarizmi.BL.Dtos;
using khawarizmi.BL.Managers;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace khawarizmi_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreateCourseController : ControllerBase
{
    private readonly ILogger<CreateCourseController> _logger;
    private readonly ITagsManager _tagsManager;
    private readonly ICoursesManager _coursesManager;
    private readonly ICategoriesManager _categoriesManager;

    public CreateCourseController(ICoursesManager coursesManager, ICategoriesManager categoriesManager, ITagsManager tagsManager, ILogger<CreateCourseController> logger)
	{
        _logger = logger;
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
	public async Task<ActionResult<int>> PostNewCourse([FromForm] CourseAddDto newCourse, string userId)
    {
        if (newCourse.File != null)
        {
            IFormFile file = newCourse.File;
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            newCourse.Image = path;

            
        }


        var NewCourseId = _coursesManager.AddNewCourse(userId, newCourse);

		return Ok(NewCourseId);
	}
}
