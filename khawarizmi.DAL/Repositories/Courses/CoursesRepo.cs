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

        SaveChanges();

        return course.Id;
    }

    public int Coursesnumber()
    {
      var Coursesnum = _context.Set<Course>().Count();
        return Coursesnum;

    }
    public int Creatorsnumber()
    {
        
        var Creators=_context.Set<Course>().Select(c => c.PublisherId).Distinct().Count();
        return Creators;

    }
    public int Vistorssnumber()
    {
        
        var Visitors= _context.Set<User>().Count();
        return Visitors;

    }

    public ICollection<UserCourses> GetAllCourses(string UserId)
    {
        var courses = _context.Set<UserCourses>()
      .Where(c => c.UserId == UserId)
      .Where(c => c.IsLearning || c.IsBookmarked)
      .Include(c => c.Course)
      .ToList();
        return courses;

    }

    public ICollection<UserCourses> GetAllCoursesIsBookMarked(string UserId)
    {
        var CoursesIsBookMarked = _context.Set<UserCourses>()
            .Where(c => c.UserId==UserId)
            .Where(c => c.IsBookmarked==true)
            .Include(c => c.Course)
            .ToList();
        return CoursesIsBookMarked;
    }

    public ICollection<UserCourses> GetAllCoursesIsLearining(string UserId)
    {
        var coursesIsLearning = _context.Set<UserCourses>()
            .Where(c => c.UserId==UserId)
            .Where(c => c.IsLearning==true)
            .Include(c => c.Course)
            .ToList();
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

    public IQueryable<Course> GetCoursesWithUsers()
    {
        return _context.Set<Course>().Include(c => c.UserCourses);
    }

    public string? GetPublisherNameById(string UserId)

    {
        var PublisherName = _context.Set<User>()
            .FirstOrDefault(c => c.Id == UserId)?.UserName;
        return PublisherName;
    }

    public List<Course> Search(string keyWord)
    {

        return _context.Courses.Where(c => c.Name.Contains(keyWord)).ToList();
    }
    //public IQueryable<Course> GetCoursesWithUsers()
    //{
    //    IQueryable<Course> courses = _context.Set<Course>().Include(c => c.UserCourses);
    //    return courses;
    //}
}
