using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Lessons;
public class LessonsManager : ILessonsManager
{
    private readonly ILessonRepo lessonRepo;

    public LessonsManager(ILessonRepo lessonRepo)
    {
        this.lessonRepo = lessonRepo;
    }
    public string GetVideoPath(string videoName)
    {
        string directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Videos");
        string fullVideoName = DateTime.Now.Ticks + videoName;
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        string path = Path.Combine(directory, fullVideoName);

        return path;
    }
    public string RelativeToAbsolutePath(string relativePath)
    {
        // video stored in relative path in database.
        // we get full path to delete the video if needed
        return Path.Combine(Directory.GetCurrentDirectory(), relativePath);
    }

    async public Task StoreVideoToUploads(IFormFile video, string videoPath)
    {
        using (var stream = new FileStream(videoPath, FileMode.Create))
        {
            await video.CopyToAsync(stream);
        }

        return;
    }
    public void DeleteVideo(string videoPath)
    {
        if (File.Exists(videoPath))
        {
            File.Delete(videoPath);
        }
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
            CourseId = lessonObj.courseId,
            VideoURL= videoPath
        };
    }

    public void AddLesson(Lesson lesson)
    {
        lessonRepo.Add(lesson);
        lessonRepo.SaveChanges();
    }

    public Lesson? GetLessonById(int id)
    {
        return lessonRepo.Get(id);
    }

    public LessonDisplayDto ConvertLessonToLessonDisplayDto(Lesson lesson, string host)
    {
        var videoURLWithHostName = $"https://{host}/{lesson.VideoURL}";

        return new LessonDisplayDto
        (
            lesson.Name,
            videoURLWithHostName, 
            lesson.Description
        );
    }

    public void ChangeDescription(int id, string description)
    {
        var lesson = lessonRepo.Get(id);
        if (lesson is null) return;
        lesson.Description = description;
        lessonRepo.SaveChanges();
    }

    public void ChangeTitle(int id, string title)
    {
        var lesson = lessonRepo.Get(id);
        if (lesson is null) return;
        lesson.Name = title;
        lessonRepo.SaveChanges();
    }
    public void ChangeVideo(int id, string videoURL)
    {
        var lesson = lessonRepo.Get(id);
        if (lesson is null) return;
        lesson.VideoURL = videoURL;
        lessonRepo.SaveChanges();
    }
}
