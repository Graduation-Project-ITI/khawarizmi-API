using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Lessons;

public interface ILessonsManager
{
    public Task<string> StoreVideoToUploads(IFormFile video);
    public Lesson? VideoMetadataToLesson(string metadata, string videoPath);
    public void AddLesson(Lesson lesson);
}
