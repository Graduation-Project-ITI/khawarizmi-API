using khawarizmi.DAL.Datatypes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Models;

public class User: IdentityUser
{
    public bool IsAdmin { get; set; }
    public Gender Gender { get; set; }
    public string UserImage { get; set; } = string.Empty;
    public ICollection<Feedback>? Feedbacks { get; set; } = new HashSet<Feedback>();
    public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
}
