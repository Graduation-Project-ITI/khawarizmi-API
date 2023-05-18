using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public interface IGenericRepo<T> where T : class
{
    List<T> GetAll();
    T? Get(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    int SaveChanges();
}
