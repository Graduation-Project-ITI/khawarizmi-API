using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories.Users;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{
    public UsersRepo(KhawarizmiContext context) : base(context)
    {
    }
}
