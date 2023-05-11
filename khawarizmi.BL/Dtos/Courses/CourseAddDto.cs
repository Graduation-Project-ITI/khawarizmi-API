using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public record CourseAddDto(string Title, string Description, string? Image, int CategoryId, List<string> TagsIds);