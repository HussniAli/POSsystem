using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly POSDbContext _POSDbContext;
        public UserController(POSDbContext pOSDbContext) { 
            _POSDbContext= pOSDbContext;    
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<List<UserVM>> GetUsers()
        {
            var users = await _POSDbContext.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (var item in users)
            {
                userVMs.Add(new UserVM
                {
                    
                    Email = item.Email,
                    Id = item.Id,
                    Pssword = item.Pssword,
                    UserName = item.UserName,
                });
            }
            return userVMs; 
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<bool> AddUser(UserVM model)
        {
            User user = new User();
            user.Email = model.Email;
            user.Id = model.Id;
            user.Pssword = model.Pssword;
            user.UserName = model.UserName;
            _POSDbContext.Add(user);
            await _POSDbContext.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        [Route("EditUser")]
        public async Task<bool> EditUser(UserVM model)
        {
            var user = await _POSDbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                user.Id = model.Id;
                user.Pssword = model.Pssword;
                user.UserName = model.UserName;
                await _POSDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;   
            }
           
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<bool> DeleteUser(int Id)
        {
            var user = await _POSDbContext.Users.FindAsync(Id);
            _POSDbContext.Users.Remove(user);
            return true;    
        }
    }
}
