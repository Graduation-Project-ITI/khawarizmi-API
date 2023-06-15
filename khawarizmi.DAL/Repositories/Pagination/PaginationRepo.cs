using khawarizmi.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories.Pagination;
public class PaginationRepo<T> : GenericRepo<T>, IPaginationRepo<T> where T : class
{
    public PaginationRepo(KhawarizmiContext context) : base(context)
    {
    }
}
