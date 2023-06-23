using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.BL.Managers.Lessons;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Drawing;
using System.Text.Json;

namespace khawarizmi_API.Controllers.LessonController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private readonly ILessonsManager lessonsManager;

        public LessonController(ILessonsManager lessonsManager)
        {
            this.lessonsManager = lessonsManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromForm] IFormFile video, [FromForm] string metadata)
        {
            string videoPath = await Helper.UploadvideoOnCloudinary(video);

            Lesson? lessonToAdd = lessonsManager.VideoMetadataToLesson(metadata, videoPath);
            if(lessonToAdd is null) return BadRequest();

            lessonsManager.AddLesson(lessonToAdd);

            return Ok(new {message = "Lesson added successfully"});
        }

        [HttpDelete]
        [Route("delete/{lessonId}/{userId}")]
        public IActionResult DeleteLesson(string userId, int lessonId)
        {
            lessonsManager.DeleteLesson(userId, lessonId);

            return Ok(new { message = "Lesson deleted successfully" });
        }

        [HttpGet]
        public IActionResult GetLesson(int id)
        {
            var lesson = lessonsManager.GetLessonById(id);
            if (lesson is null) return NotFound();
            string host = Request.Headers.Host.ToString();

            return Ok(lessonsManager.ConvertLessonToLessonDisplayDto(lesson, host));
        }

        // update descriptoin
        [HttpPut]
        [Route("update-description/{id}")]
        public IActionResult ChangeDescription(int id, [FromBody] ChangeDescriptionDto body)
        {
            lessonsManager.ChangeDescription(id, body.description);

            return Ok();
        }

        // update title
        [HttpPut]
        [Route("update-title")]
        public IActionResult ChangeTitle(int id, string title)
        {
            Console.WriteLine(id);
            Console.WriteLine(title);
            lessonsManager.ChangeTitle(id, title);

            return Ok();
        }

        // update video
        [HttpPut]
        [Route("update-video/{id}")]
        async public Task<IActionResult> ChangeVideo(int id, [FromForm] IFormFile video)
        {
            string videoPath = await Helper.UploadvideoOnCloudinary(video);

            lessonsManager.ChangeVideo(id, videoPath);

            return Ok(new { message = "Video updated successfully" });
        }
    }
}
