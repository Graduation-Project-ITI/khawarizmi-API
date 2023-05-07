using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public interface ITagsRepo : IGenericRepo<Tag>
{
    IQueryable<Tag> GetTagsByCategory(string category);
}
