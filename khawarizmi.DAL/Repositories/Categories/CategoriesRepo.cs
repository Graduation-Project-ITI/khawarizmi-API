using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
    public Category? GetCategoryByIdWithTags(int categoryId)
    {
        Category? _category = _context.Set<Category>().Include(c => c.Tags).FirstOrDefault(c => c.Id == categoryId);
        if(_category == null) { return null; }
        return _category;
    }

    public IEnumerable<Category> GetCategories() 
    { 
        return _context.Categories;
    }
}
