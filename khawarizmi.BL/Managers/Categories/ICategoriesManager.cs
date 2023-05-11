using khawarizmi.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public interface ICategoriesManager
{
    List<CategoryReadDto> GetAllCategories();
}
