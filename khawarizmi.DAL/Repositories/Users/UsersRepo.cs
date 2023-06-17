using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories.Users;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{
    private readonly KhawarizmiContext _context;
    public UsersRepo(KhawarizmiContext context) : base(context)
    {
        _context = context;
    }
    public IQueryable<User> GetPublisherCourses()
    {
        return _context.Set<User>().Include(u => u.UserCourses);
    }
    public User? GetUserById(string id)
    {
        return _context.Set<User>().Find(id);
    }
}
