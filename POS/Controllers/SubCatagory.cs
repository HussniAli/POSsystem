using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using POS.Models;

namespace POS.Controllers
{
[Route("api/[controller]")]
public class SubCatagoryController : Controller
{
private readonly POSDbContext _posDbContext;
        public SubCatagoryController(POSDbContext pOSDbContext)
        {
            _posDbContext = pOSDbContext;
        }
        [HttpGet]
        [Route("GetSubCatagory")]
        public async Task<List<SubCatagoryVM>> GetSubCatagory()
        {
            var subcatagory = await _posDbContext.SubCatagory.Include(i=>i.item).ToListAsync();
            List<SubCatagoryVM> subCatagoryVM = new List<SubCatagoryVM>();
            foreach (var i in subcatagory)
            {
                subCatagoryVM.Add(new SubCatagoryVM
                {

                    Id = i.Id,
                    Name = i.Name,
                    ItemId =i .item.Id,
                });
            }
            return subCatagoryVM;
        }
        [HttpPost]
        [Route("AddSubCatagory")]
        public async Task<bool> AddSubCatagory(SubCatagoryVM model)
        {
            var subcatagory = new SubCatagory();
            subcatagory .Id =  model.Id;
            subcatagory.Name =model.Name;
            _posDbContext.Add(subcatagory);
            await _posDbContext.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        [Route("EditCatagory")]
        public async Task<bool> EditSubCatagory(SubCatagoryVM model)
        {
            var subcatagory = await _posDbContext.SubCatagory.FindAsync(model.Id);
            if (subcatagory != null)
            {
            subcatagory.Id = model.Id;
            subcatagory.Name = model.Name;
            
                await _posDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpDelete]
        [Route("DeleteSubCatagory")]
        public async Task<bool> DeleteSubCatagory(int Id)
        {
            var subcatagory = await _posDbContext.SubCatagory.FindAsync(Id);
            _posDbContext.SubCatagory.Remove(subcatagory);
            return true;
        }
}
}