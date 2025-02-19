using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignUpApp.Database;

namespace SignUpApp
{

    public class JwtMiddleware
    {
        private readonly IConfiguration _config;

        private readonly RequestDelegate _next;

        
        public JwtMiddleware(RequestDelegate next,IConfiguration config)
        {
            _next = next;
            _config =config;
           
        }
        public async Task Invoke(HttpContext context,IUserService userservice)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                attachUserToContext(context,userservice, token);
            await _next(context);
        }
        private void attachUserToContext(HttpContext context,IUserService userservice, string token)
        {
            try
            {   var secretKey = _config["SecretKey"];
                var tokenHandler = new JwtSecurityTokenHandler();
               var key = Encoding.ASCII.GetBytes(secretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var user = userservice.GetUserByIdAsync(Convert.ToInt32(userId));
                if(user!=null){

                    context.Items["User"] = user;
                }
                
                // attach user to context on successful jwt validation
             
            }
            catch(Exception e)
            {
                return;
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}

