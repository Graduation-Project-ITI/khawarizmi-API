using khawarizmi.BL.Dtos.ProfileDTO;
using khawarizmi.DAL.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL;

public record ProfileReadDTO
{
    public string Name { get; init; }
    public string UserImage { get; init; } 
    public string Email { get; init; }
    public Gender Gender { get; init; }
    public ICollection<ProfileCourseDTO> Courses { get; set; } = new HashSet<ProfileCourseDTO>();
}

