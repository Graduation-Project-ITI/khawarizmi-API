using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace khawarizmi.BL.Managers.Lessons;

public interface ILessonsManager
{
    public string GetVideoPath(string videoName);
    public string RelativeToAbsolutePath(string relativePath);
    public Task StoreVideoToUploads(IFormFile video, string videoPath);
    public Lesson? VideoMetadataToLesson(string metadata, string videoPath);
    public void AddLesson(Lesson lesson);
    public void DeleteLesson(string userId, int lessonId);
    public Lesson? GetLessonById(int id);
    public LessonDisplayDto ConvertLessonToLessonDisplayDto(Lesson lesson, string host);
    public void DeleteVideo(string videoPath);
    public void ChangeDescription(int id, string description);
    public void ChangeTitle(int id, string title);
    public void ChangeVideo(int id, string videoURL);
}
