using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/[controller]")]
    public class CatagoryController : Controller
    {
        private readonly POSDbContext _posDbContext;
        public CatagoryController(POSDbContext pOSDbContext)
        {
            _posDbContext = pOSDbContext;
        }
        [HttpGet]
        [Route("GetCatagory")]
        public async Task<List<CatagoryVM>> GetCatagory()
        {
            var catagory = await _posDbContext.Catagory.Include(i =>i.subcatagory).ToListAsync();
            List<CatagoryVM> catagoryVMs = new List<CatagoryVM>();
            foreach (var i in catagory)
            {
                catagoryVMs.Add(new CatagoryVM
                {

                    Id = i.Id,
                    Name = i.Name,
                    SubCatagoryId =i.subcatagory.Id,
                });
            }
            return catagoryVMs;
        }
        [HttpPost]
        [Route("AddCatagory")]
        public async Task<bool> AddCatagory(CatagoryVM model)
        {
            var catagory = new Catagory();
            catagory.Id =  model.Id;
            catagory.Name =model.Name;
            _posDbContext.Add(catagory);
            await _posDbContext.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        [Route("EditCatagory")]
        public async Task<bool> EditCatagory(CatagoryVM model)
        {
            var catagory = await _posDbContext.Catagory.FindAsync(model.Id);
            if (catagory != null)
            {
            catagory.Id = model.Id;
            catagory.Name = model.Name;
            
                await _posDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpDelete]
        [Route("DeleteCatagory")]
        public async Task<bool> DeleteCatagory(int Id)
        {
            var catagory = await _posDbContext.Catagory.FindAsync(Id);
            _posDbContext.Catagory.Remove(catagory);
            return true;
        }
    }
}