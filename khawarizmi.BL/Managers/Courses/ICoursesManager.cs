using khawarizmi.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers;

public interface ICoursesManager
{
    void AddNewCourse(string userId, CourseAddDto newCourse);
}
