

using khawarizmi.DAL.Models;

namespace khawarizmi.DAL;
    public interface IUserProfile
    {
    void save();
 Task<List<Course>> GetCoursesByPublisherIdAsync(string publisherId);

    }

