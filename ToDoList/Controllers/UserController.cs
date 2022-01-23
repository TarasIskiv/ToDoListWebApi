using Application.DTO;
using Application.Interfaces;
using Application.TokenData.Active;
using Application.TokenData.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JWTSettings _jwtSettings;

        public UserController(IUserService userService, IOptions<JWTSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpGet]
        [Route("register")]
        public ActionResult<string> Register([FromBody] CreateUserDto userDto)
        {
            _userService.Create(userDto);
            return Ok("Go to api/user/login to get your token");
        }


        [HttpGet]
        [Route("login")]
        public ActionResult<string> Login([FromBody] CreateUserDto userDto)
        {
            var user = _userService.GetAllUsers().Where(x => x.Login == userDto.Login && x.Password == userDto.Password).FirstOrDefault();

            if (user == null) return NotFound();

            
            //sign token here
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginedUserToken = tokenHandler.WriteToken(token);

            var loginedUser = new LoginedUser()
            {
                Id = user.Id,
                Token = loginedUserToken
            };

            var list = new ActiveLoginedUsers();
            list.addUser(loginedUser);
            //CurrentUsers.currentUsers.Add(userWithToken);
            return Ok(loginedUser.Token);
        }
    }
}
