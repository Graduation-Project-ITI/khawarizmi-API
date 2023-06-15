using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.Users;
public record UsersDisplayDto(string Id, string Name, int CoursesCreated, int NumberOfBookmarks, int NumberOfLearning);

