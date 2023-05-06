using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Category>? Categories { get; set; } = new HashSet<Category>();
    public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
}
