using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public class TagsRepo : GenericRepo<Tag>, ITagsRepo
{
    private readonly KhawarizmiContext _context;
    private readonly ICategoriesRepo _categoriesRepo;
    public TagsRepo(KhawarizmiContext context, ICategoriesRepo categoriesRepo) : base(context)
    {
        _context = context;
        _categoriesRepo = categoriesRepo;
    }
    public ICollection<Tag> GetTagsByCategoryId(int categoryId)
    {
        Category? category = _categoriesRepo.GetCategoryByIdWithTags(categoryId);

        return category.Tags;
    }
}
