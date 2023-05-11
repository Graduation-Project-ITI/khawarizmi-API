using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public ICollection<Course>? Courses { get; set;} = new HashSet<Course>();
}
