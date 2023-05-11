using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class UserCourses
{
    public int Id { get; set; }
    public bool IsBookmarked { get; set; }
    public bool IsLearning { get; set; }
    public bool IsVoted { get; set; }
    public bool IsUpVoted { get; set; }
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;
    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public User User { get; set; } = null!;
    public Course Course { get; set; } = null!;

}
