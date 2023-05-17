using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public record CourseEditDto(int Id,
                            string Name, 
                            string Description, 
                            string? CourseImage);
