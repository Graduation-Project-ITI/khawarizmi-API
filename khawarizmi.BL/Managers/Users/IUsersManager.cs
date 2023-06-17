using khawarizmi.BL.Dtos.Courses;
using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.BL.Dtos.Users;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Users
{
    public interface IUsersManager
    {
        PaginationDisplayDto<UsersDisplayDto> UserPaginator(int pageIndex, string searchBy, string orderBy, int pageSize);
        void DeleteUser(string id);
    }
}
