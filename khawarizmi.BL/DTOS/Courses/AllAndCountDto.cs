using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Dtos.Courses
{
    public class AllAndCountDto
    {
        public int Count { get; set; }
        public List<AllCoursesDto> AllCourses { get; set; } = new List<AllCoursesDto>();
    }
}
