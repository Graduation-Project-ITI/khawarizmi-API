using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using khawarizmi.DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Generic;

//public class PaginationManager<T>: PaginationRepo<T>, IPaginationManager where T : class
//{
//    private readonly IPaginationRepo<T> _paginationRepo;

//    public PaginationManager(IPaginationRepo<T> paginationRepo):base(paginationRepo<T>)
//    {
//        _paginationRepo = paginationRepo;
//    }

//    // V -> view model
//    // M -> DB Model
//    public PaginationDisplayDto<V> CoursePaginator<V, M>(int pageIndex, string searchBy, string orderBy, int pageSize)
//    {
//        List<M> courses;
//        if (orderBy == "topVoted")
//        {
//            courses = GetAll()
//                .Where(c => c.Name.Contains(searchBy))
//                .OrderByDescending(c => c.UpVotes - c.DownVotes)
//                .ToList();
//        }
//        else
//        {
//            courses = GetAll()
//            .Where(c => c.Name.Contains(searchBy))
//            .ToList();
//        }

//        int length = courses.Count;

//        // pages start with 0
//        var queryResultPage = courses.Skip(pageIndex * pageSize).Take(pageSize);

//        // course to admin dto
//        List<AdminCoursesDisplayDto> AdminDTO = queryResultPage.Select(c => new AdminCoursesDisplayDto
//        (
//            Id: c.Id,
//            Name: c.Name,
//            Publisher: c.PublisherId,
//            UpVotes: c.UpVotes,
//            DownVotes: c.DownVotes,
//            NetVotes: c.UpVotes - c.DownVotes,
//            Date: c.Date
//        )).ToList();

//        return new PaginationDisplayDto<AdminCoursesDisplayDto>
//            (
//                Length: length,
//                Data: AdminDTO
//            );
//    }
//}
