using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public class CoursesRepo : GenericRepo<Course>, ICoursesRepo
{
    private readonly KhawarizmiContext _context;
    public CoursesRepo(KhawarizmiContext context) : base(context)
    {
        _context = context;
    }
    public int AddNewCourse(Course course)
    {
        _context.Set<Course>().Add(course);

        _context.SaveChanges();

        return course.Id;
    }

    public ICollection<UserCourses> GetAllCourses(string UserId,int pagenumber=1)
    {
        var courses = _context.Set<UserCourses>()
      .Where(c => c.UserId == UserId && c.IsLearning || c.IsBookmarked)
      .Include(c => c.Course)
      .Skip((pagenumber-1)*12)
      .Take(12)
      .ToList();
        return courses;

    }

    public ICollection<UserCourses> GetAllCoursesIsBookMarked(string UserId)
    {
        var CoursesIsBookMarked = _context.Set<UserCourses>()
            .Where(c => c.IsBookmarked==true&& c.UserId==UserId)
            .Include(c => c.Course)
            .Take(12)
            .ToList();
        return CoursesIsBookMarked;
    }

    public ICollection<UserCourses> GetAllCoursesIsLearining(string UserId)
    {
        var coursesIsLearning = _context.Set<UserCourses>()
            .Where(c => c.IsLearning==true&&c.UserId==UserId)
            .Include(c => c.Course).Take(12).ToList();
        return coursesIsLearning;
    }

    public Course? GetCourseById(int courseId)
    {
        return _context.Set<Course>()
                        .Include(c => c.Tags)
                        .Include(c => c.Feedbacks)
                        .Include(c => c.Lessons)
                        .Include(c => c.User)
                        .Include(c => c.UserCourses)
                        .FirstOrDefault(c => c.Id == courseId);
    }

    public string? GetPublisherNameById(string UserId)

    {
        var PublisherName = _context.Set<User>()
            .FirstOrDefault(c => c.Id == UserId)?.UserName;
        return PublisherName;
    }


}
