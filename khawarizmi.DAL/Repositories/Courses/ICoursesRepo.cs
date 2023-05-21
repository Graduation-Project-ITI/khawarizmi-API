using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public interface ICoursesRepo : IGenericRepo<Course>
{
    int AddNewCourse(Course course);
    Course? GetCourseById(int courseId);
    ICollection<UserCourses> GetAllCourses(string UserId, int pagenumber=1);
    ICollection<UserCourses> GetAllCoursesIsBookMarked(string UserId);
    ICollection<UserCourses> GetAllCoursesIsLearining(string UserId);
    string? GetPublisherNameById(string UserId);
    string? GetCourseNameById(int courseId);

    List<Course> Search(string keyWord);

}

