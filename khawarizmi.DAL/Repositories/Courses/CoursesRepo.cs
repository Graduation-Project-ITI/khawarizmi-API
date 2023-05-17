using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
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

    public ICollection<UserCourses> GetAllCourses(string UserId)
    {
        var courses = _context.Set<UserCourses>()
      .Where(c => c.UserId == UserId && c.IsLearning && c.IsBookmarked)
      .Include(c => c.Course)
      .ToList();
        return courses;

    }

    public ICollection<UserCourses> GetAllCoursesIsBookMarked(string UserId)
    {
        var CoursesIsBookMarked = _context.Set<UserCourses>().Where(c => c.IsBookmarked).Include(c => c.Course).ToList();
        return CoursesIsBookMarked;
    }

    public ICollection<UserCourses> GetAllCoursesIsLearining(string UserId)
    {
        var coursesIsLearning = _context.Set<UserCourses>().Where(c => c.IsLearning).Include(c => c.Course).ToList();
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


    public string? GetCourseNameById(int courseId)
    {
        var courseName = _context.Set<Course>().FirstOrDefault(c => c.Id == courseId)?.Name;
        return courseName;
    }


}
