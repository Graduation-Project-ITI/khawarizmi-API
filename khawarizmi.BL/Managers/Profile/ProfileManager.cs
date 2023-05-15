using khawarizmi.BL.Dtos.ProfileDTO;
using khawarizmi.BL.Managers.Profile;
using khawarizmi.DAL;
using khawarizmi.DAL.Models;
using khawarizmi.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace khawarizmi.BL
{
    public class ProfileManager : IProfileManager
    {
        private readonly string DefaultCourseImage = "https://chemonics.com/wp-content/uploads/2017/08/JobsPages_GenericBanner.jpg";
        private readonly IUserProfile _profile;

        public ProfileManager(IUserProfile profile, ICoursesRepo courseRepository)
        {
            _profile = profile;
        }

        public async Task<List<ProfileCourseDTO>> GetCoursesByPublisherIdAsync(string publisherId)
        {
            var courses = await _profile.GetCoursesByPublisherIdAsync(publisherId);

            var courseDTOs = courses.Select(c => new ProfileCourseDTO
            {
                Name = c.Name,
                Description = c.Description,
                CourseImage = string.IsNullOrEmpty(c.CourseImage) ? DefaultCourseImage : c.CourseImage,
                Date = c.Date,
            }).ToList();
            return courseDTOs;
        }
    }
}