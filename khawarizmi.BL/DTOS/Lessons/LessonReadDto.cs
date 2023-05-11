using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.Lessons;

public record LessonReadDto(int Id,string Title, string Description, string VideoURL, bool IsPublish);