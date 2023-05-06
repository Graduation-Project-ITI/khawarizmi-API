using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string CourseImage { get; set; } = string.Empty;
    public int? UpVotes { get; set; }
    public int? DownVotes { get; set; }
    public bool IsPublished { get; set; }
    public bool? IsBookmarked { get; set; }
    public bool? IsLearning { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;
    public ICollection<Tag>? Tags { get; set; } = new HashSet<Tag>();
    public ICollection<Feedback>? Feedbacks { get; set; } = new HashSet<Feedback>();
    public ICollection<Lesson>? Lessons { get; set; } = new HashSet<Lesson>();
    public User User { get; set; } = null!;
    public Category? Category { get; set; }

}
