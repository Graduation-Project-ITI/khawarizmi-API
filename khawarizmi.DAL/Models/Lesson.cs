using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class Lesson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string VideoURL { get; set; } = string.Empty;
    public bool? IsPublished { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
