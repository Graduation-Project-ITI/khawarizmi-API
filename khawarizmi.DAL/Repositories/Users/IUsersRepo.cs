using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories.Users;

public interface IUsersRepo: IGenericRepo<User>
{
    IQueryable<User> GetPublisherCourses();
    User? GetUserById(string id);
}
