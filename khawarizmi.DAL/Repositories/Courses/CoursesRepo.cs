using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories;

public class CoursesRepo : GenericRepo<Course>, ICoursesRepo
{
    private readonly KhawarizmiContext _context;
    public CoursesRepo(KhawarizmiContext context) : base(context)
    {
        _context = context;
    }
    public void AddNewCourse(Course course)
    {
        _context.Set<Course>().Add(course);

        _context.SaveChanges();
    }
}
