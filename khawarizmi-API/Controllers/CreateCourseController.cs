using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using khawarizmi.BL.Dtos;
using khawarizmi.BL.Managers;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

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
	public ActionResult<int> PostNewCourse([FromForm] CourseAddDto newCourse, string userId)
    {
        if (newCourse.File != null)
        {
            var extension = Path.GetExtension(newCourse.File.FileName);
            var d = DateTime.Now;
            var fileName = $"{d.Year}{d.Month}{d.Day}{d.Hour}{d.Minute}{d.Second}{d.Millisecond}{d.Microsecond}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Images", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                newCourse.File.CopyTo(stream);
            }

            var cloudinary = new Cloudinary(new Account("dohd3qizc", "291665793866531", "k48cbVPUttntt6aMdE0ZMXQTuZQ"));
            ImageUploadParams uploadParams = new() { File = new FileDescription(path), FilenameOverride = fileName };
            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);

            FileSystem.DeleteFile(path);

            newCourse.Image = uploadResult.Url.ToString();
        }


        var NewCourseId = _coursesManager.AddNewCourse(userId, newCourse);

		return Ok(NewCourseId);
	}
}
