using khawarizmi.BL.Dtos.Lessons;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public record CourseDisplayDto(int Id,
                               string Title,
                               string Description,
                               string CourseImage,
                               string Date,
                               int? UpVotes, 
                               int? DownVotes, 
                               bool IsPublished,
                               int CategoryId,
                               string Publisher,
                               IEnumerable<TagReadDto>? Tags,
                               IEnumerable<FeedbackReadDto>? Feedbacks,
                               IEnumerable<LessonReadDto>? Lessons );
