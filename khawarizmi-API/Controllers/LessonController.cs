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
    public class LessonController : ControllerBase
    {
        private readonly ILessonsManager lessonsManager;

        public LessonController(ILessonsManager lessonsManager)
        {
            this.lessonsManager = lessonsManager;
        }

        [HttpPost]
        async public Task<IActionResult> CreateLesson([FromForm]IFormFile video, [FromForm]string metadata)
        {
            //prepare video by providing path to uploads
            string path = lessonsManager.GetVideoPath(video.FileName);

            await lessonsManager.StoreVideoToUploads(video, path);
            Lesson? lesson = lessonsManager.VideoMetadataToLesson(metadata, path);

            if (lesson is null) return BadRequest();
            lessonsManager.AddLesson(lesson);

            return NoContent();
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
        [Route("api/[controller]/update-description")]
        public IActionResult ChangeDescription(int id, [FromBody] string description)
        {
            lessonsManager.ChangeDescription(id, description);

            return Ok();
        }

        // update title
        [HttpPut]
        [Route("api/[controller]/update-title")]
        public IActionResult ChangeTitle(int id, string title)
        {
            lessonsManager.ChangeTitle(id, title);

            return Ok();
        }

        // update video
        [HttpPut]
        [Route("api/[controller]/update-video")]
        async public Task<IActionResult> ChangeVideo(int id, [FromForm] IFormFile video)
        {
            var lesson = lessonsManager.GetLessonById(id);
            if (lesson is null) return NotFound();
            
            string videoFullPath = lessonsManager.RelativeToAbsolutePath(lesson.VideoURL);
            lessonsManager.DeleteVideo(videoFullPath);

            // store the new video
            await lessonsManager.StoreVideoToUploads(video, videoFullPath);
            lessonsManager.ChangeVideo(id, videoFullPath);
            
            // return new videoURL
            return Ok();
        }
    }
}
