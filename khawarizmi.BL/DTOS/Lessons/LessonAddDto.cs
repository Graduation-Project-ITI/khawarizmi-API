using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.Lessons;

public record LessonAddDto(string title, string description, bool isPublish, int courseId);
