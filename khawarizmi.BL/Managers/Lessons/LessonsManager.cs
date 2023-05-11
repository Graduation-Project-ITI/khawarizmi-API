using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories.Lessons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Lessons;
public class LessonsManager : LessonRepo, ILessonsManager
{
    private readonly ILessonRepo lessonRepo;

    public LessonsManager(KhawarizmiContext context, ILessonRepo lessonRepo) : base(context)
    {
        this.lessonRepo = lessonRepo;
    }

    async public Task<string> StoreVideoToUploads(IFormFile video)
    {
        string directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Videos");
        string videoName = DateTime.Now.Ticks + video.FileName;
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        string path = Path.Combine(directory, videoName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await video.CopyToAsync(stream);
        }

        return $"Uploads/Videos/{videoName}";
    }

    public Lesson? VideoMetadataToLesson(string metadata, string videoPath)
    {
        LessonAddDto? lessonObj = JsonSerializer.Deserialize<LessonAddDto>(metadata);
        if (lessonObj is null) return null;
        return new Lesson
        {
            Name = lessonObj.title,
            Description = lessonObj.description,
            IsPublished = lessonObj.isPublish,
            CourseId = int.Parse(lessonObj.courseId),
            VideoURL= videoPath,
        };
    }

    public void AddLesson(Lesson lesson)
    {
        if (lesson == null) return;
        lessonRepo.Add(lesson);
        lessonRepo.SaveChanges();
    }
}
