using khawarizmi.BL.Dtos;
using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.BL.Dtos.Courses;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using Microsoft.AspNetCore.Http.Authentication.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public class CoursesManager : ICoursesManager
{
    private readonly string DefaultCourseImage = "https://chemonics.com/wp-content/uploads/2017/08/JobsPages_GenericBanner.jpg";
    private readonly ITagsRepo _tagsRepo;
    private readonly ICoursesRepo _coursesRepo;
    private readonly ICategoriesRepo _categoriesRepo;

    public CoursesManager(ICoursesRepo coursesRepo, ICategoriesRepo categoriesRepo, ITagsRepo tagsRepo)
    {
        _tagsRepo = tagsRepo;
        _coursesRepo = coursesRepo;
        _categoriesRepo = categoriesRepo;
    }
    public void AddNewCourse(string userId, CourseAddDto newCourse)
    {
        var tags = _tagsRepo.GetTagsByCategoryId(newCourse.CategoryId);

        Category? category = _categoriesRepo.GetCategoryByIdWithTags(newCourse.CategoryId);
        if (category == null) { return; }

        Course CourseToAdd = new()
        {
            Name = newCourse.Title,
            Description = newCourse.Description,
            CourseImage = newCourse.Image ?? DefaultCourseImage,
            Date = DateTime.Now,
            UpVotes = 0,
            DownVotes = 0,
            IsPublished = false,
            CategoryId = newCourse.CategoryId,
            PublisherId = userId,
            Tags = tags.Where(t => newCourse.TagsIds.Contains(t.Id.ToString())).ToList()
        };

        _coursesRepo.AddNewCourse(CourseToAdd);
    }

    public CourseDisplayDto? GetCourseById(int courseId)
    {
        Course? c = _coursesRepo.GetCourseById(courseId);

        IEnumerable<TagReadDto>? tags = c?.Tags?.Select(t => new TagReadDto(t.Id, t.Name));
        IEnumerable<FeedbackReadDto>? feedbacks = c?.Feedbacks?.Select(t => new FeedbackReadDto(t.Id, t.body));
        IEnumerable<LessonReadDto>? lessons = c?.Lessons?.Select(t => new LessonReadDto(t.Id, t.Name, t.Description ?? "", t.VideoURL, t.IsPublished));

        if (c == null) return null;
        string publisher = c.User.UserName ?? "";

        return new CourseDisplayDto(courseId,
                                    c.Name,
                                    c.Description,
                                    c.CourseImage ?? DefaultCourseImage,
                                    c.Date.ToShortDateString(),
                                    c.UpVotes,
                                    c.DownVotes,
                                    c.IsPublished,
                                    c.CategoryId,
                                    publisher,
                                    tags,
                                    feedbacks,
                                    lessons);
    }

    public ICollection<MyLearningDTO>GetLearningCoursesById(string UserId)
    {
        var courses = _coursesRepo.GetAllCoursesIsLearining(UserId);
        
        return courses.Select(c => new MyLearningDTO( image: c.Course.CourseImage, name: c.Course.Name,
            Creatorname: _coursesRepo.GetCourseNameById(c.CourseId))).ToList();
    }

    public ICollection<MyLearningDTO> GetLearningCoursesIsBookMarked(string UserId)
    {
        throw new NotImplementedException();
    }

    public ICollection<MyLearningDTO> GetLearningCoursesIsLearning(string UserId)
    {
        throw new NotImplementedException();
    }
}
