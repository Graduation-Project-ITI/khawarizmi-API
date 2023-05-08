using khawarizmi.BL;
using khawarizmi.BL.DTOS.RegisterDTO;
using khawarizmi.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace khawarizmi_API.Controllers.SingingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration config;

        public LoginController(UserManager<User> userManager,IConfiguration _config)
        {
            this.userManager = userManager;
            config = _config;
        }
        [HttpPost]
        public async Task<ActionResult<TokenDTO>> SignIn([FromBody]LoginDTO Credtentials)
        {
            User? user = await userManager.FindByNameAsync(Credtentials.name);
            if (user == null) 
            {
                return BadRequest(new { Message = "error user or pass" });
            }
            var IsPasswordCorrect= await userManager.CheckPasswordAsync(user,Credtentials.password);
            if (!IsPasswordCorrect)
            {
                return Unauthorized();
            }

            var claims= await userManager.GetClaimsAsync(user);
            var exp=DateTime.Now.AddDays(1);

          var token=  Helper.GenrateToken(claims, exp, config);

            return new TokenDTO(token);

        }
    }
}
