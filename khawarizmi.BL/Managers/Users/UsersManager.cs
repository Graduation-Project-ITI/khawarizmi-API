using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.BL.Dtos.Users;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using khawarizmi.DAL.Repositories.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public void DeleteUser(string id)
        {
            var user = _usesrRepo.GetUserById(id);
            if (user is null) return;
            _usesrRepo.Delete(user);
            _usesrRepo.SaveChanges();
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
            var coursesCreate = _coursesRepo.GetAll().GroupBy(c => c.PublisherId)
                    .Select(g => new { publisher = g.Key, count = g.Count() }).ToList();

        // number of bookmarks, in courses table count all bookmarks in all courses that he is the publisher
        //var CourseBookmarks = (from uc in _context.UserCourses
        //              join c in _coursesRepo.GetAll()
        //              on uc.CourseId equals c.Id
        //              where uc.IsBookmarked
        //              group c by c.PublisherId into g
        //              select new { PublisherId = g.Key, count = g.Count() }).ToList();

        //var courses = _coursesRepo.GetCoursesWithUsers().GroupBy(c => c.PublisherId, (counter, y) => new { x = y.Count() });

        //foreach (var course in courses)
        //{
        //    foreach (var x in course)
        //    {
        //        int? courseBookmarks = x.UserCourses?.Where(cu => cu.IsBookmarked == true).Count();
        //        int? courseLearnings = x.UserCourses?.Where(cu => cu.IsLearning == true).Count();
        //    }
        //}

        //CoursesCreated: index < coursesCreate.Count ? coursesCreate[index].count : 0

            //var publisherCourses = _usesrRepo.GetPublisherCourses();

            // number of learning, in courses table count all learning in all courses that he is the publisher


            // pages start with 0
            var queryResultPage = users.Skip(pageIndex * pageSize).Take(pageSize);

            // user to admin dto
            List<UsersDisplayDto> UserDTO = queryResultPage.Select(u => new UsersDisplayDto
            (
                Id: u.Id,
                Name: u.UserName ?? "",
                Email: u.Email ?? "",
                CoursesCreated: _coursesRepo.GetAll().Where(c => c.PublisherId == u.Id).Count()
            )).ToList();

            return new PaginationDisplayDto<UsersDisplayDto>
                (
                    Length: length,
                    Data: UserDTO
                );
        }
    }
}
