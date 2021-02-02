using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager,SignInManager<User> signInManager,IConfiguration configuration)
        {
        _userManager=userManager;
            _signInManager = signInManager;
           _configuration = configuration;
        }


[HttpPost("register")]
    public async Task<IActionResult> Register(userForRegisterDTO model){
        
var user=new User{
    UserName=model.UserName,
    Email=model.Email,
    Name=model.Name,
    Gender=model.Gender,
    Created=DateTime.Now,
    LastActive=DateTime.Now 

}; 
var result= await _userManager.CreateAsync(user,model.Password);

if(result.Succeeded)
{
return StatusCode(201);

}
return BadRequest(result.Errors);

    }


[HttpPost("login")]
public async Task<IActionResult> Login(UserForLoginDTO model){

throw new Exception("Interval exception");

var user=await _userManager.FindByNameAsync(model.UserName);
if(user==null)
    return BadRequest( new {message="kullanıcı adını kontrol et gadasını aldığım"});


var result=await _signInManager.CheckPasswordSignInAsync(user,model.Password,false);

if(result.Succeeded)
{
//Login
return Ok(new {
     token=GenerateJwtToken(user)
     
     });

}
return Unauthorized();


}

  private string GenerateJwtToken(User user)
        {
            var tokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);
            

            var tokenDescriptor=new SecurityTokenDescriptor{
                Subject=new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)

                }),//token içerisinde yer almasını istediğimiz bilgiler
                Expires=DateTime.UtcNow.AddDays(1),
                 //token ne kadar süre geçerli oalcak
                 SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
                    //token hangi şifreleme algoritması kullancak vs onu belirttik.
            };

            var token=tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        

       
    }} 
