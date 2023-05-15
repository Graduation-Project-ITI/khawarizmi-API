using khawarizmi.BL.Dtos.ProfileDTO;
using khawarizmi.DAL;
using khawarizmi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace khawarizmi.BL.Managers.Profile
{

    public interface IProfileManager
    {
        
        Task<List<ProfileCourseDTO>> GetCoursesByPublisherIdAsync(string publisherId);

    }
}
