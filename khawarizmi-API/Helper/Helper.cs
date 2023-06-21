using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using khawarizmi.BL.DTOS.RegisterDTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Net.Http.Headers;

namespace khawarizmi_API;

 public static class Helper
{
    public static String GenrateToken(IList<Claim> claims,DateTime exp, IConfiguration configuration)
    {

        var SecretKeyInString = configuration.GetValue<string>("SecretKey") ?? "";
      
        var SecretKeyInBytes= Encoding.ASCII.GetBytes(SecretKeyInString);
        var SecretKey = new SymmetricSecurityKey(SecretKeyInBytes);
        var SigningCredintails = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);

        var JWT = new JwtSecurityToken(

            claims: claims,
            expires: exp,
            signingCredentials: SigningCredintails);
        var TokenHandler = new JwtSecurityTokenHandler();
        var StringToken = TokenHandler.WriteToken(JWT);
        return StringToken;

    }

    public static async Task<string> /*string*/ UploadImageOnCloudinary(IFormFile? file)
    {
        if (file is not null)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"Img{DateTime.Now.Ticks}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Images", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var cloudinary = new Cloudinary(new Account("dohd3qizc", "291665793866531", "k48cbVPUttntt6aMdE0ZMXQTuZQ"));
            ImageUploadParams uploadParams = new() { File = new FileDescription(path), FilenameOverride = fileName };
            //ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
            ImageUploadResult uploadResult = await cloudinary.UploadAsync(uploadParams);

            FileSystem.DeleteFile(path);

            return uploadResult.Url.ToString();
        }
        else
        {
            return string.Empty;
        }
    }

    public static async Task<string> UploadvideoOnCloudinary(IFormFile? file)
    {
        if (file is not null)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"Vid{DateTime.Now.Ticks}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Videos", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var cloudinary = new Cloudinary(new Account("dohd3qizc", "291665793866531", "k48cbVPUttntt6aMdE0ZMXQTuZQ"));
            VideoUploadParams uploadParams = new() { File = new FileDescription(path), FilenameOverride = fileName };
            VideoUploadResult uploadResult = await cloudinary.UploadAsync(uploadParams);

            FileSystem.DeleteFile(path);

            return uploadResult.Url.ToString();
        }
        else
        {
            return string.Empty;
        }



    }
}
