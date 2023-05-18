using khawarizmi.BL.Dtos;
using khawarizmi.BL.Dtos.Courses;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public interface ICoursesManager
{
    void AddNewCourse(string userId, CourseAddDto newCourse);
    CourseDisplayDto? GetCourseById(int courseId);
    ICollection<MyLearningDTO> GetLearningCoursesById(string UserId, int pagenumber=1);
    ICollection<MyLearningDTO> GetLearningCoursesIsBookMarked(string UserId);
    ICollection<MyLearningDTO> GetLearningCoursesIsLearning(string UserId);
}
