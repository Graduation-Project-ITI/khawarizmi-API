using khawarizmi.DAL.Datatypes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class User: IdentityUser
{
    [NotMapped]
    private readonly static string DefaultUserImage = "http://res.cloudinary.com/dzjcky6eb/image/upload/v1677747807/vyvdoxetqkgbelmrdl3f.png";
    public bool IsAdmin { get; set; }
    public Gender Gender { get; set; }
    public string UserImage { get; set; } = DefaultUserImage;
    public ICollection<Feedback>? Feedbacks { get; set; } = new HashSet<Feedback>();
    public ICollection<UserCourses>? UserCourses { get; set; } = new HashSet<UserCourses>();
}
