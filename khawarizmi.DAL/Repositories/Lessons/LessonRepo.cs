using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.DAL.Repositories.Lessons;
public class LessonRepo : GenericRepo<Lesson>, ILessonRepo
{
    public LessonRepo(KhawarizmiContext context) : base(context)
    {

    }

}
