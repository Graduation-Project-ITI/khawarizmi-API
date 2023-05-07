using khawarizmi.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly KhawarizmiContext _context;

    public GenericRepo(KhawarizmiContext context)
    {
        _context = context;
    }
    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }
}
