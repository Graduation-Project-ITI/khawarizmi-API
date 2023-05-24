using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.BL.Dtos.Users;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using khawarizmi.DAL.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepo _usesrRepo;
        private readonly ICoursesRepo _coursesRepo;

        public UsersManager(IUsersRepo usesrRepo, ICoursesRepo coursesRepo)
        {
            _usesrRepo = usesrRepo;
            _coursesRepo = coursesRepo;
        }

        public PaginationDisplayDto<UsersDisplayDto> UserPaginator(int pageIndex, string searchBy, string orderBy, int pageSize)
        {
            List<User> users;
            if (orderBy == "topCreators")
            {
                users = _usesrRepo.GetAll()
                    .Where(u => u.UserName.Contains(searchBy))
                    //.OrderByDescending(u => u.)
                    .ToList();
            }
            else
            {
                users = _usesrRepo.GetAll()
                .Where(u => u.UserName.Contains(searchBy))
                .ToList();
            }

            int length = users.Count;

            // courses created, in courses table count all courses that its publisher is this user
            //var coursesCreated = _coursesRepo.GetAll().Where(c => c.PublisherId ==)

            // number of bookmarks, in courses table count all bookmarks in all courses that he is the publisher
            //var courses = _coursesRepo.GetCoursesWithUsers().GroupBy(c => c.PublisherId);

            //foreach (var course in courses)
            //{
            //    foreach (var x in course)
            //    {
            //        int? courseBookmarks = x.UserCourses?.Where(cu => cu.IsBookmarked == true).Count();
            //        int? courseLearnings = x.UserCourses?.Where(cu => cu.IsLearning == true).Count();
            //    }
            //}

            // number of learning, in courses table count all learning in all courses that he is the publisher


            // pages start with 0
            var queryResultPage = users.Skip(pageIndex * pageSize).Take(pageSize);

            // user to admin dto
            List<UsersDisplayDto> UserDTO = queryResultPage.Select(c => new UsersDisplayDto
            (
                Id:c.Id,
                Name:c.UserName,
                CoursesCreated: 5,
                NumberOfBookmarks: 5,
                NumberOfLearning:5
            )).ToList();

            return new PaginationDisplayDto<UsersDisplayDto>
                (
                    Length: length,
                    Data: UserDTO
                );
        }
    }
}
