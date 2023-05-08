using khawarizmi.BL;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace khawarizmi_API.Controllers.SingingControllers;

[Route("api/[controller]")]
[ApiController]
public class SignUpController : ControllerBase
{
    private readonly UserManager<User> usermanger;

    public SignUpController(UserManager<User> Usermanger)
    {
        usermanger = Usermanger;
    }
    [HttpPost]
    [EnableCors("MyCorsPolicy")]
    public async Task<ActionResult> SignUp([FromForm]SignUpDTO NewUser)
    {
        User user = new User()
        {
            UserName = NewUser.name,
            Email = NewUser.email
        };
        var IsEmailExist = await usermanger.FindByEmailAsync(NewUser.email);
        if(IsEmailExist !=null)
        {
           
            return BadRequest(new {Message= "Email Already Exist" });

        }

        var ClientCreationResult = await usermanger.CreateAsync(user, NewUser.password);
        if (!ClientCreationResult.Succeeded)
        {
            return BadRequest(ClientCreationResult.Errors);
        }
        var ListOfclaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Role,"User"),


        };
        await usermanger.AddClaimsAsync(user, ListOfclaims);
        return Accepted();
    }
}
