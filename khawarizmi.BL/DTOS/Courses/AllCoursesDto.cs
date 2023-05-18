using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public class AllCoursesDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? CourseImage { get; set; } = string.Empty;
    [Column(TypeName = "Date")]
    public DateTime Date { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }

}
