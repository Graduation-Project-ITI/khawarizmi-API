using khawarizmi.BL.Dtos;
using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
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
    void DeleteCourse(int courseId);
    void UpdateUserCourseVote(int courseId, string userId, bool vote);
    void UpdateUserCourseLearn(int courseId, string userId, bool learn);
    void UpdateUserCourseBookmark(int courseId, string userId, bool bookmark);
    void UpdateCoursePublish(int courseId, string userId, bool publish);
    void AddCourseFeedback(int courseId, string userId, string feedback);

    ICollection<MyLearningDTO> GetLearningCoursesById(string UserId);
    ICollection<MyLearningDTO> GetLearningCoursesIsBookMarked(string UserId);
    ICollection<MyLearningDTO> GetLearningCoursesIsLearning(string UserId);
    List<AllCoursesDto> GetAll();
    AllAndCountDto GetPaginationCourse(int PageNumber, int catId = 0);
    //List<AllCoursesDto> GetPaginationCourse(int PageNumber);
    object GetAdminDashbordinfo();

    AllAndCountDto? Search(string keyWord);
    //List<AllCoursesDto> GetPaginationCourse(int PageNumber);
    PaginationDisplayDto<AdminCoursesDisplayDto> CoursePaginator(int pageIndex, string searchBy, string orderBy, int pageSize);
    List<AllCoursesDto> GetLatestCourses();
    List<AllCoursesDto> GetTopCourses();
}
