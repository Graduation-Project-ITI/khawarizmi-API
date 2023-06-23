using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class Feedback
{
    public int Id { get; set; }
    public string body { get; set; } = string.Empty;
    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;
    public Course Course { get; set; } = null!;
    public User User { get; set; } = null!;
}