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
        [HttpPost]
        async public Task<IActionResult> CreateLesson([FromForm]IFormFile video, [FromForm]string metadata)
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Videos");
            string videoName = DateTime.Now.Ticks + video.FileName;
            if(!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, videoName);
            
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await video.CopyToAsync(stream);
            }

            //object metadataObj = JsonSerializer.Deserialize<object>(metadata)!;
            
            return Ok("all good");
        }
    }
}
