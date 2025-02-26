using Hospital.Api.Models;
using Hospital.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWorkerService _workerService;

        public AuthController(IConfiguration configuration, IWorkerService workerService)
        {
            _configuration = configuration;
            _workerService = workerService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            var workers = await _workerService.GetWorkersListAsync();
            var worker = workers.FirstOrDefault(w=> w.UserName.Equals(loginModel.UserName)&&
                         w.Password.Equals(loginModel.Password));
            if (worker != null)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, worker.Name),
                new Claim(ClaimTypes.Role, worker.Role.ToString())
            };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
