using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class Lesson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string VideoURL { get; set; } = string.Empty;
    [Column(TypeName = "Date")]
    public DateTime Date { get; set; }
    public bool IsPublished { get; set; }
    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
