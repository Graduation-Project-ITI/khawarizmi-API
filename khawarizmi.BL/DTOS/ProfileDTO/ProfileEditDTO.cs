
using khawarizmi.DAL.Datatypes;
using Microsoft.AspNetCore.Http;

namespace khawarizmi.BL;

    public record ProfileEditDTO
    {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public IFormFile UserImage { get; set; }

}

