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
    CourseDisplayDto? GetCourseById(int courseId);
    int AddNewCourse(string userId, CourseAddDto newCourse);
    void EditCourse(CourseEditDto course);
    void UpdateUserCourseVote(int courseId, string userId, bool vote);
    void UpdateUserCourseLearn(int courseId, string userId, bool learn);
    void UpdateUserCourseBookmark(int courseId, string userId, bool bookmark);
    void UpdateCoursePublish(int courseId, string userId, bool publish);
    void AddCourseFeedback(int courseId, string userId, string feedback);

    ICollection<MyLearningDTO> GetLearningCoursesById(string UserId);
    ICollection<MyLearningDTO> GetLearningCoursesIsBookMarked(string UserId);
    ICollection<MyLearningDTO> GetLearningCoursesIsLearning(string UserId);
    List<AllCoursesDto> GetAll();
    AllAndCountDto GetPaginationCourse(int PageNumber);
    AllAndCountDto Search(string keyWord);
}
