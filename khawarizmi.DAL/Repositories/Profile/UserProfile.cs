

using khawarizmi.DAL.Context;
using khawarizmi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace khawarizmi.DAL;
public class UserProfile : IUserProfile
{
    private readonly KhawarizmiContext context;
    public UserProfile(KhawarizmiContext _context)
    {
        context= _context;
    }

    public async Task<List<Course>> GetCoursesByPublisherIdAsync(string publisherId)
    {
        return await context.Courses
            .Where(c => c.PublisherId == publisherId)
            .ToListAsync();
    }

    public void save()
    {
        context.SaveChanges();
    }
}



  


