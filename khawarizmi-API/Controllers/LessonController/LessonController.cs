using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.BL.Managers.Lessons;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text.Json;

namespace khawarizmi_API.Controllers.LessonController
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
        async public Task<IActionResult> CreateLesson([FromForm] IFormFile video, [FromForm] string metadata)
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
            var lesson = lessonsManager.GetLessonById(id);
            if (lesson is null) return NotFound();

            // delete prev video by full path
            string videoFullPath = lessonsManager.RelativeToAbsolutePath(lesson.VideoURL);
            lessonsManager.DeleteVideo(videoFullPath);


            // store the new video
            await lessonsManager.StoreVideoToUploads(video, videoFullPath);
            //lessonsManager.ChangeVideo(id, videoFullPath);

            // return new videoURL
            return Ok(new { videoURL = lesson.VideoURL });
        }
    }
}
