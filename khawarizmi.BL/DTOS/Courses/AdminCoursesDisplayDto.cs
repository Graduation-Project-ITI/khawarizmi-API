using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.Courses;

public record AdminCoursesDisplayDto(int Id,string Name, string Publisher, int UpVotes, int DownVotes, int NetVotes, string Date);
