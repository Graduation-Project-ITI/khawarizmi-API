using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.ProfileDTO
{
    public class ProfileCourseDTO
    {
        public int id { get; init; }

        public string Name { get; init; }
        public string Description { get; init; }
        public string CourseImage { get; init; }
        public DateTime Date { get; init; }
        public int UpVotes { get; init; }
        public int DownVotes { get; init; }
        public bool IsPublished { get; init; }

    }
}
