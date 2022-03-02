using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tracker_bar_admin_api.DataModels;
using tracker_bar_admin_api.Models;

namespace tracker_bar_admin_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public AuthController(
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretHash"));
                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    expires: DateTime.Now.AddDays(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                return new OkObjectResult(new TokenDetails(
                    Token: new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration: token.ValidTo
                ));
            }
            return new BadRequestObjectResult($"User with email {model.Email} couldn't be found");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return new BadRequestObjectResult("Passwords do no match");
            }

            if (await userManager.FindByNameAsync(model.Email) is not null)
            {
                return new BadRequestObjectResult("Email is taken");
            }

            var role = await roleManager.FindByNameAsync(model.Role);

            if (role == null)
            {
                return new BadRequestObjectResult("Nonexistent role");
            }

            var user = new User
            {
                Name = model.Name,
                Last = model.Last,
                Email = model.Email,
                Password = model.Password,
                BirthDate = model.BirthDate,
                Role = role
            };

            var userCreated = await userManager.CreateAsync(user, model.Password);

            if (!userCreated.Succeeded)
            {
                return new BadRequestObjectResult(string.Join(", ", userCreated.Errors.Select(error => $"{error.Code} {error.Description}")));
            }
            return new OkObjectResult(user);
        }
    }
}
