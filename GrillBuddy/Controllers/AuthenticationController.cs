using GrillBuddy.DAL.Entities;
using GrillBuddy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrillBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        //il metodo lo facciamo asyncronous perché tutti i metodi della classe UserManager sono async in modo che quando li vado a richiamare vengono eseguiti in parallelo
        //e non uno dopo l'altro
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)  //restituisce un tipo Task come promessa che restituirò un oggetto di quel tipo
        {
            var User = await _userManager.FindByNameAsync(model.Username); //verifichiamo se l'utente esiste e appena finito la ricerca lo assegna alla variabile 
            if (User != null && await _userManager.CheckPasswordAsync(User, model.Password))
            {
                List<Claim> AuthClaim = new List<Claim>()  //forniamo al token delle informazioni: al token diamo il nome dell'utente e un identification (guid)
                {
                    new Claim(ClaimTypes.Name, User.UserName),   //un claim è un infornazione che ha un token
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var UserRoles = await _userManager.GetRolesAsync(User);
                foreach (string role in UserRoles)     //diamo al token le informazioni dei ruoli
                    AuthClaim.Add(new Claim(ClaimTypes.Role, role));
                SymmetricSecurityKey singhingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                JwtSecurityToken token = new JwtSecurityToken
                    (
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: AuthClaim,
                        signingCredentials: new SigningCredentials(singhingKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), Expiration = token.ValidTo }); //restituisco un token con tutte le informazioni

            }
            return Unauthorized(); //se User è null non autorizziamo l'accesso
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var UserExists = await _userManager.FindByNameAsync(model.Username);
            if (UserExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            User user = new User()
            {
                Email = model.EMail,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);  //prende la password, la crittografa e la controlla col DB
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok();

        }
    }
}
