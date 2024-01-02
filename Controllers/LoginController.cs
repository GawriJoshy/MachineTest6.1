using MachineTest6._1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using MachineTest6._1.Repository;

namespace MachineTest6._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginRepository;
        private readonly IConfiguration _config;

        //Construction injection
        public LoginController(ILogin loginRepository, IConfiguration config)
        {
            _loginRepository = loginRepository;
            _config = config;

        }

        //Get a User
        
        private Login AuthenticateUser(string username, string password)
        {
            Login user = _loginRepository.ValidateUser(username, password);

            if (user != null)
            {
                return user;
            }
            return null;
        }

        //Generate Json web token
        private string GenerateJSONWebToken(Login user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate Token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("{userName}/{password}")]
        public IActionResult userLogin(string username, string password)
        {
            IActionResult response = Unauthorized();

            //Authenticate the user by passing username, password
            Login dbLogin = AuthenticateUser(username, password);

            if (dbLogin != null)
            {
                var tokenString = GenerateJSONWebToken(dbLogin);
                response = Ok(new
                {
                    userName = dbLogin.Username,
                    userPassword = dbLogin.Password,
                    token = tokenString
                });
            }
            return response;

        }
    }
}
