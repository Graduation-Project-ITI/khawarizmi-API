using khawarizmi.BL.Dtos;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public class CategoriesManager : ICategoriesManager
{
    private readonly ICategoriesRepo _categoriesRepo;
    public CategoriesManager(ICategoriesRepo categoriesRepo)
	{
        _categoriesRepo = categoriesRepo;
    }
    public List<CategoryReadDto> GetAllCategories()
    {
        IQueryable<CategoryReadDto> categories = _categoriesRepo.GetAll().Select(c => new CategoryReadDto(c.Id,c.Name));

        return categories.ToList();
    }
}
