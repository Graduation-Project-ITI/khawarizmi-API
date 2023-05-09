using khawarizmi.BL.Dtos;
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
    private string DefaultCourseImage = "https://chemonics.com/wp-content/uploads/2017/08/JobsPages_GenericBanner.jpg";
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
        //IQueryable<Tag> tags = _tagsRepo.GetTagsByCategoryId(newCourse.CategoryId);

        Category? category = _categoriesRepo.GetCategoryByIdWithTags(newCourse.CategoryId);
        if(category == null) { return; }

        Course CourseToAdd = new Course() 
        {
            Name = newCourse.Title,
            Description = newCourse.Description, 
            CourseImage = newCourse.Image ?? DefaultCourseImage,
            CategoryId = newCourse.CategoryId,
            Tags = category?.Tags?.Where(t => newCourse.TagsIds.Contains(t.Id.ToString())).ToList(),
            UserId = userId,
            DownVotes = 0,
            UpVotes = 0
        };

        _coursesRepo.AddNewCourse(CourseToAdd);
    }

    public CourseDisplayDto? GetCourseById(int courseId)
    {
        Course? c = _coursesRepo.GetCourseById(courseId);

        IEnumerable<TagReadDto>? tags = c?.Tags?.Select(t => new TagReadDto(t.Id, t.Name));
        IEnumerable<FeedbackReadDto>? feedbacks = c?.Feedbacks?.Select(t => new FeedbackReadDto(t.Id, t.body));
        IEnumerable<LessonReadDto>? lessons = c?.Lessons?.Select(t => new LessonReadDto(t.Id, t.Name, t.Description??"", t.VideoURL, t.IsPublished));
        
        if (c == null) return null;
        string publisher = c.User.UserName ?? "";

        return new CourseDisplayDto(courseId,
                                    c.Name,
                                    c.Description,
                                    c.CourseImage ?? DefaultCourseImage,
                                    c.UpVotes,
                                    c.DownVotes,
                                    c.IsPublished,
                                    c.CategoryId,
                                    publisher,
                                    tags,
                                    feedbacks,
                                    lessons );
    }
}
