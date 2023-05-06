using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{
    private readonly KhawarizmiContext _context;
    public CategoriesRepo(KhawarizmiContext context) : base(context)
    {
        _context = context;
    }
    public Category? GetCategoryByName(string category)
    {
        Category? _category = _context.Set<Category>().FirstOrDefault(c => c.Name == category);
        if(_category == null) { return null; }
        return _category;
    }
}
