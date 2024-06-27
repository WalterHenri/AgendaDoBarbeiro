using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        [HttpPost("register")]

        public ActionResult<User> Register(UserDto request)
        {
            User newUser = new User();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            newUser.PhoneNumber = request.Phone;
            newUser.Password = passwordHash;
            newUser.Roles.Add(new Role { RoleId = (long)Roles.USUARIO});
            _service.Create(newUser);
            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            var users = await _service.GetAll();
            var user = users.Where(u => u.Equals(request.Phone)).ToList().FirstOrDefault();
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Senha Errada");
            }

            string token = CreateWebToken(user);
            return Ok(token);
            
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string CreateWebToken(User user)
        {
            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Usuario"),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }
}
