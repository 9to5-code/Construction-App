using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text; // For Encoding
using System.IdentityModel.Tokens.Jwt; // For JwtSecurityTokenHandler
using Microsoft.IdentityModel.Tokens; // For SecurityTokenDescriptor, SigningCredentials, SymmetricSecurityKey
using System.Security.Claims; // For ClaimsIdentity, Claim
using SignUpApp.Database;
using SignUpApp.Model;
namespace SignUpApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
   private readonly IConfiguration _config;


 private readonly IUserService _userService;

    public AuthController(IConfiguration config,IUserService userService)
    {
        _config = config;
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login( [FromBody] LoginModel model)
    { 
        var user = _userService.GetUser(model);
           
            var token = GenerateJwtToken(user.Id);
            return Ok(new { token });
        
        return Unauthorized();
    }

    private string GenerateJwtToken(int userId)
    {
        var secretKey = _config["SecretKey"];
        var key = Encoding.ASCII.GetBytes("HG4s0YDoPAmul8aPGrbf8Gc1OjjaC9UjNaLq2H71rEU");
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", Convert.ToString(userId) )}),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
           
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}



        
    }

