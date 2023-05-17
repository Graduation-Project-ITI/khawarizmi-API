using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public interface IGenericRepo<T> where T : class
{
    IQueryable<T> GetAll();
    void SaveChanges();
}
