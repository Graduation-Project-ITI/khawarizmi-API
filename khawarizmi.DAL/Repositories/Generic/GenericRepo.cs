using khawarizmi.DAL.Context;
using Microsoft.EntityFrameworkCore;
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
    public T? Get(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
