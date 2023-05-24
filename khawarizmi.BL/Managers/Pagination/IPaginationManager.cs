using khawarizmi.BL.Dtos.Helpers;
using khawarizmi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Generic;

public interface IPaginationManager
{
    PaginationDisplayDto<V> CoursePaginator<V, M>(int pageIndex, string searchBy, string orderBy, int pageSize);
}
