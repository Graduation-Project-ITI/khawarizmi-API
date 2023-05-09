using khawarizmi.BL.DTOS.RegisterDTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
}
