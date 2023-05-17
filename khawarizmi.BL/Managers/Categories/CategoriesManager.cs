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
        IEnumerable<CategoryReadDto> categories = _categoriesRepo.GetCategories().Select(c => new CategoryReadDto(c.Id, c.Name));

        return categories.ToList();
    }
}
