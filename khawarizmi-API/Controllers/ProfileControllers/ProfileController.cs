using khawarizmi.BL;
using khawarizmi.BL.Managers.Profile;
using khawarizmi.DAL;
using khawarizmi.DAL.Context;
using khawarizmi.DAL.Datatypes;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.Security.Claims;

namespace khawarizmi_API.Controllers.ProfileControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IUserProfile userprofile;
        private readonly IProfileManager profile;

        public ProfileController(UserManager<User> userManager, IUserProfile userProfile, IProfileManager profile)
        {
            this.userManager = userManager;
            this.userprofile = userProfile;
            this.profile = profile;
        }


        [HttpPost]
        public async Task<ActionResult> EditProfileInfo([FromForm] ProfileEditDTO userdata)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) { return NotFound("ABC"); }
            user.UserName = userdata.Name;
            user.Email = userdata.Email;

            if (userdata.Gender == "male")
            {
                user.Gender = Gender.male;
            }
            else
            {
                user.Gender = Gender.female;
            }


            // Update the user's password if a new one is provided
            if (!string.IsNullOrEmpty(userdata.Password))
            {
                var result = await userManager.ChangePasswordAsync(user, userdata.Password, userdata.Password);
                if (!result.Succeeded)
                {
                    // Handle password change failure
                    return BadRequest(result.Errors);
                }
            }


            // how i can store image 

            if (userdata.UserImage != null)
            {

                //get extention
                //abanoub.jpg
                var extention = Path.GetExtension(userdata.UserImage.FileName).ToLower(); //=jpg
                                                                                          //i want save image in wwwroot   "newguid.jpg"
                var now = DateTime.Now;
                var newImageName = $"{now.Year}{now.Month}{now.Day}{now.Hour}{now.Minute}{now.Second}{now.Millisecond}{extention}";                //make a path consist of www root path(base url) / image name   "localhost/newguid.jpg"
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newImageName); // specify the path to save the image
                //go to stream and copy user image 
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await userdata.UserImage.CopyToAsync(stream); // copy the image to the specified location
                }
                user.UserImage = newImageName;
            }


            //await userManager.UpdateAsync(user);
            this.userprofile.save();

            return Ok(" Edited successfully");
        }



        ///api/profile/john.doe @example.com
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileReadDTO>> GetProfileInfo()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Hello");
            }

            // Construct the URL to the user's image
            var imageUrl = $"{Request.Scheme}://{Request.Host}/" + Path.Combine($"{user.UserImage}");

            ProfileReadDTO userProfile = new ProfileReadDTO()
            {
                Name = user.UserName,
                UserImage = imageUrl,
                Email = user.Email,
                Gender = user.Gender,
                Courses = await profile.GetCoursesByPublisherIdAsync(userId)

            };

            return Ok(userProfile);
        }
    }
}
