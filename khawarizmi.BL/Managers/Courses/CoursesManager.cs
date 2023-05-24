using khawarizmi.BL.Dtos;
using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.BL.Dtos.Courses;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using Microsoft.AspNetCore.Http.Authentication.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

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

    public CourseDisplayDto? GetCourseById(int courseId)
    {
        Course? c = _coursesRepo.GetCourseById(courseId);

        IEnumerable<TagReadDto> tags = c?.Tags?.Select(t => new TagReadDto(t.Id, t.Name)) ?? new List<TagReadDto>();
        IEnumerable<FeedbackReadDto> feedbacks = c?.Feedbacks?.Select(t => new FeedbackReadDto(t.Id, t.body)) ?? new List<FeedbackReadDto>();
        IEnumerable<LessonReadDto> lessons = c?.Lessons?.Select(t => new LessonReadDto(t.Id, t.Name, t.Description ?? "", t.VideoURL, t.IsPublished)) ?? new List<LessonReadDto>();
        IEnumerable<CourseUsersOverviewDto> courseUsers = c?.UserCourses?.Select(cu => new CourseUsersOverviewDto(cu.Id, cu.CourseId, cu.UserId, cu.IsBookmarked, cu.IsLearning, cu.IsVoted, cu.IsUpVoted)) ?? new List<CourseUsersOverviewDto>();

        if (c == null) return null;
        string publisherId = c.User.Id;
        string publisherName = c.User.UserName ?? "";

        return new CourseDisplayDto(courseId,
                                    c.Name,
                                    c.Description,
                                    c.CourseImage ?? DefaultCourseImage,
                                    c.Date.ToShortDateString(),
                                    c.UpVotes,
                                    c.DownVotes,
                                    c.IsPublished,
                                    c.CategoryId,
                                    publisherId,
                                    publisherName,
                                    tags,
                                    feedbacks,
                                    lessons,
                                    courseUsers);
    }

    public int AddNewCourse(string userId, CourseAddDto newCourse)
    {
        string[] tagsIds = newCourse.TagsIds.Split(',');

        var tagsString = _tagsRepo.GetTagsByCategoryId(newCourse.CategoryId);

        Category? category = _categoriesRepo.GetCategoryByIdWithTags(newCourse.CategoryId);
        if(category == null) { return -1; }

        var tags = tagsString?.Where(t => tagsIds.Contains(t.Id.ToString())).ToList() ?? new List<Tag>();

        if (newCourse.Image.IsNullOrEmpty()) newCourse.Image = DefaultCourseImage;

        Course CourseToAdd = new() 
        {
            Name = newCourse.Title,
            Description = newCourse.Description,
            CourseImage = newCourse.Image,
            Date = DateTime.Now,
            UpVotes = 0,
            DownVotes = 0,
            IsPublished = false,
            CategoryId = newCourse.CategoryId,
            PublisherId = userId,
            Tags = tags
        };

        int NewCourseId = _coursesRepo.AddNewCourse(CourseToAdd);

        return NewCourseId;
    }

    public void EditCourse(CourseEditDto course)
    {
        Course? courseInDB = _coursesRepo.GetCourseById(course.Id);
        Category? category = _categoriesRepo.GetCategoryByIdWithTags(course.CategoryId);
        if (courseInDB is null || category is null) return;
        string[] tagsIds = course.TagsIds.Split(',');
        var tagsString = _tagsRepo.GetTagsByCategoryId(course.CategoryId);
        var tags = tagsString?.Where(t => tagsIds.Contains(t.Id.ToString())).ToList() ?? new List<Tag>();

        courseInDB.Name = course.Name;
        courseInDB.Description = course.Description;
        courseInDB.CategoryId = category.Id;
        courseInDB.Tags = tags;
        if (!course.CourseImage.IsNullOrEmpty()) courseInDB.CourseImage = course.CourseImage;

        _coursesRepo.SaveChanges();
    }

    public void DeleteCourse(int CourseId)
    {
        var course = _coursesRepo.Get(CourseId);
        if(course is null) return;

        _coursesRepo.Delete(course);
        _coursesRepo.SaveChanges();
    }

    public void UpdateUserCourseVote(int courseId, string userId, bool vote)
    {
        Course? course = _coursesRepo.GetCourseById(courseId);
        if (course == null) return;

        UserCourses? userCourse = course.UserCourses?.FirstOrDefault(uc => uc.UserId == userId);

        if (userCourse != null)
        {
            if (userCourse.IsVoted)
            {
                if(userCourse.IsUpVoted) { course.UpVotes--; }
                if(!userCourse.IsUpVoted) { course.DownVotes--; }

                userCourse.IsUpVoted = vote;
            }
            else
            {
                userCourse.IsVoted = true;
                userCourse.IsUpVoted = vote;
            }

        }
        else
        {
            course.UserCourses?.Add(new UserCourses()
            {
                UserId = userId,
                CourseId = courseId,
                IsVoted = true,
                IsUpVoted = vote,
                IsBookmarked = false,
                IsLearning = false
            });
        }

        if (vote == true) { course.UpVotes++; }
        if (vote == false) { course.DownVotes++; }

        _coursesRepo.SaveChanges();
    }

    public void UpdateUserCourseLearn(int courseId, string userId, bool learn)
    {
        Course? course = _coursesRepo.GetCourseById(courseId);
        if (course == null) return;

        UserCourses? userCourse = course.UserCourses?.FirstOrDefault(uc => uc.UserId == userId);

        if (userCourse != null)
        {
            userCourse.IsLearning = learn;
        }
        else
        {
            course.UserCourses?.Add(new UserCourses()
            {
                UserId = userId,
                CourseId = courseId,
                IsVoted = false,
                IsUpVoted = false,
                IsBookmarked = false,
                IsLearning = learn
            });

        }
        _coursesRepo.SaveChanges();
    }

    public void UpdateUserCourseBookmark(int courseId, string userId, bool bookmark)
    {
        Course? course = _coursesRepo.GetCourseById(courseId);
        if (course == null) return;

        UserCourses? userCourse = course.UserCourses?.FirstOrDefault(uc => uc.UserId == userId);

        if (userCourse != null)
        {
            userCourse.IsBookmarked = bookmark;
        }
        else
        {
            course.UserCourses?.Add(new UserCourses()
            {
                UserId = userId,
                CourseId = courseId,
                IsVoted = false,
                IsUpVoted = false,
                IsLearning = false,
                IsBookmarked = bookmark
            });

        }
        _coursesRepo.SaveChanges();
    }

    public void UpdateCoursePublish(int courseId, string userId, bool publish)
    {
        Course? course = _coursesRepo.GetCourseById(courseId);
        if (course == null) return;

        if (course.PublisherId == userId)
        {
            course.IsPublished = publish;
            _coursesRepo.SaveChanges();
        }
    }

    public void AddCourseFeedback(int courseId, string userId, string feedback)
    {
        Course? course = _coursesRepo.GetCourseById(courseId);
        if (course == null) return;

        Feedback? UserFeedback = course.Feedbacks?.FirstOrDefault(f => f.UserId == userId);

        if (UserFeedback != null)
        {
            UserFeedback.body = feedback;
        }
        else
        {
            course.Feedbacks?.Add(new Feedback()
            {
                CourseId = courseId,
                UserId = userId,
                body = feedback
            });
        }

        _coursesRepo.SaveChanges();
    }

    public ICollection<MyLearningDTO> GetLearningCoursesById(string UserId,int pagenumber)
    {
        var courses = _coursesRepo.GetAllCourses(UserId, pagenumber);
        return courses.Select(c => new MyLearningDTO(image: c.Course?.CourseImage??"", name: c.Course?.Name??"",
            Creatorname: _coursesRepo.GetPublisherNameById(c.Course?.PublisherId??"")??"")).ToList();
      
    }

    public ICollection<MyLearningDTO> GetLearningCoursesIsBookMarked(string UserId)
    {
        var courses = _coursesRepo.GetAllCoursesIsBookMarked(UserId);
        return courses
            .Select(c => new MyLearningDTO(image: c.Course?.CourseImage??"", name: c.Course?.Name??"",
            Creatorname: _coursesRepo.GetPublisherNameById(c.Course?.PublisherId??"")??""))
            .ToList();
    }

    public ICollection<MyLearningDTO> GetLearningCoursesIsLearning(string UserId)
    {
        var courses = _coursesRepo.GetAllCoursesIsLearining(UserId);
        return courses
            .Select(c => new MyLearningDTO(image: c.Course?.CourseImage??"", name: c.Course?.Name??"",
            Creatorname: _coursesRepo.GetPublisherNameById(c.Course?.PublisherId??"")??""))
            .ToList();
    }

    public List<AllCoursesDto> GetPaginationCourse(int PageNumber)
    {
        List<Course> coursePageDb = _coursesRepo.GetAll().Where(c => c.IsPublished == true).Skip((PageNumber - 1) * 1).Take(8).ToList();
        return coursePageDb.Select(c => new AllCoursesDto
        {
            Name = c.Name,
            Description = c.Description,
            CourseImage = c.CourseImage,
            Date = c.Date,
            UpVotes = c.UpVotes,
            DownVotes = c.DownVotes
        }).ToList();
    }
    public List<AllCoursesDto> GetAll()
    {
        List<Course> coursesDb = _coursesRepo.GetAll().Where(c => c.IsPublished == true).ToList();
        return coursesDb.Select(c => new AllCoursesDto
        {
            Name = c.Name,
            Description = c.Description,
            CourseImage = c.CourseImage,
            Date = c.Date,
            UpVotes = c.UpVotes,
            DownVotes = c.DownVotes

        }).ToList();
    }
}