
using System.ComponentModel.DataAnnotations.Schema;
namespace khawarizmi.DAL.Models;
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public string? CourseImage { get; set; } = string.Empty;
    [Column(TypeName = "Date")]
    public DateTime Date { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
    public bool IsPublished { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    [ForeignKey(nameof(User))]
    public string PublisherId { get; set; } = string.Empty;
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public ICollection<Feedback>? Feedbacks { get; set; } = new HashSet<Feedback>();
    public ICollection<Lesson>? Lessons { get; set; } = new HashSet<Lesson>();
    public ICollection<UserCourses>? UserCourses { get; set; } = new HashSet<UserCourses>();
    public User User { get; set; } = null!;
    public Category? Category { get; set; }

}
