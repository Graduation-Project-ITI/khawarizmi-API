using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos;

public record CourseUsersOverviewDto (int Id, int CourseId, string UserId, bool IsBookmarked, bool IsLearning, bool IsVoted, bool IsUpVoted);
