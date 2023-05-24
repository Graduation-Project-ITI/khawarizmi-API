using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories.Pagination;
public interface IPaginationRepo<T>: IGenericRepo<T> where T : class
{

}
