using System.Xml.Schema;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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

        public UserOneController(POSDbContext posDbContext,
         UserManager<UserOne> userManager,
         SignInManager<UserOne> signInManager)
        {
            _posDbContext = posDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("GetUsersOne")]
        public async Task<List<UserOne>> Get()
        {
            return await _posDbContext.UsersOne.ToListAsync();
        }

        [HttpGet]
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
                var isPasswordCorrect = await _userManager.CheckPasswordAsync(userone , model.Password);
                if(isPasswordCorrect)
                {
                    var result =await _signInManager.PasswordSignInAsync(userone ,model.Password,
                
                model.RememberMe,lockoutOnFailure: false );
                 if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                     ModelState.AddModelError("Login", "Invalid login attempt.");
                }
                }
               
             }
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
