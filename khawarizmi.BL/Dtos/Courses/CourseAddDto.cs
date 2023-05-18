using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public class CourseAddDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public IFormFile? File { get; set; }
    public int CategoryId { get; set; }
    public string TagsIds { get; set; } = string.Empty;
}