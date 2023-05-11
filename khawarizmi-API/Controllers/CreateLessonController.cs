using khawarizmi.BL.Managers.Lessons;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text.Json;

namespace khawarizmi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateLessonController : ControllerBase
    {
        private readonly ILessonsManager lessonsManager;

        public CreateLessonController(ILessonsManager lessonsManager)
        {
            this.lessonsManager = lessonsManager;
        }

        [HttpPost]
        async public Task<IActionResult> CreateLesson([FromForm]IFormFile video, [FromForm]string metadata)
        {
            string videoPath = await lessonsManager.StoreVideoToUploads(video);
            Lesson? lesson = lessonsManager.VideoMetadataToLesson(metadata, videoPath);

            if (lesson is null) return BadRequest();
            lessonsManager.AddLesson(lesson);

            return Ok("all good");
        }
    }
}
