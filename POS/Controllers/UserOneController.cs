using System.Xml.Schema;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace POS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserOneController : Controller
    {
        public readonly POSDbContext _posDbContext;
        public readonly UserManager<UserOne> _userManager;
        public readonly SignInManager<UserOne> _signInManager;
        public readonly IConfiguration _config;

        public UserOneController(POSDbContext posDbContext,
         UserManager<UserOne> userManager,
         SignInManager<UserOne> signInManager,
         IConfiguration config )
        {
            _posDbContext = posDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _config =config;
        }

        [HttpGet]
        [Authorize(Policy=IdentityData.AdminPolicyName)]
        [Route("GetUsersOne")]
        public async Task<List<UserOne>> Get()
        {
            return await _posDbContext.UsersOne.ToListAsync();
        }

        [HttpGet]
        [Authorize(Policy =IdentityData.UsersPolicyName)]
        [Route("GetUsers")]
        public async Task<List<UserOne>> GetById(string Id)
        {
            return await _posDbContext.UsersOne.ToListAsync();
        }

        [HttpPost(Name = "Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //get user
             var userone = await _userManager.FindByNameAsync(model.UserName);
             if (userone is not null)
             {
                 var result = await _signInManager.PasswordSignInAsync(userone, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Login", "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
               
             }
             var claims =await _userManager.GetClaimsAsync(userone);
             var Securitykey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]!));
              var signingCredentials = new SigningCredentials(Securitykey, SecurityAlgorithms.HmacSha256);
              var Token =new JwtSecurityToken(
                issuer:_config["JwtSettings:Issuer"],
                audience:_config["JwtSettings:Audiience"],
                claims:claims,
                expires:DateTime.UtcNow.AddMinutes(10),
                signingCredentials:signingCredentials);
              return Ok(new {Token=new JwtSecurityTokenHandler().WriteToken(Token)});
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userone = new UserOne { UserName = model.UserName, Email = model.Email }; //creat user model
                var result = await _userManager.CreateAsync(userone, model.Password);         //register user

                if (result.Succeeded)
                {
                    var claims = new List<Claim>();
                    if(model.IsAdmin)
                    {
                        claims.Add(new Claim(IdentityData.AdminClaimName,IdentityData.AdminClaimName));
                    }else
                    {
                        claims.Add(new Claim(IdentityData.UsersClaimName,IdentityData.UsersClaimName));

                    }
                    await _userManager.AddClaimsAsync(userone,claims);
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
                       return BadRequest(ModelState);
        }
    }
}
