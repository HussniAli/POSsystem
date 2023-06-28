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
        public CatagoryController(POSDbContext posDbContext)
        {
            _posDbContext = posDbContext;
        }
        [HttpGet]
        [Route("GetCatagory")]
        public async Task<IEnumerable<CatagoryVM>> GetCatagory(int itemId)
        {
            var Catagory = await _posDbContext.Catagory
                     .Include(p => p.SubCatagory)
                     .ThenInclude(s => s.item)
                     .Where(p => p.SubCatagory.ItemId == itemId)
                     .ToListAsync();
                    //  var CatagorywithItem = await _posDbContext.Catagory
                    //  .Include(p => p.SubCatagory)
                    // //  .ThenInclude(s => s.item)
                    //  .Where(p => p.SubCatagory.ItemId == itemId)
                    //  .ToListAsync();
                    //  https://stackoverflow.com/questions/5010110/entityframework-join-using-join-method-and-lambdas
                    var test = _posDbContext.Catagory
                    .Join(_posDbContext.SubCatagory,
                    p =>p.SubCatagoryId,
                    s =>s.Id,
                    (p,s)=>new {p,s})
                    .Join(_posDbContext.Items,
                    i=>i.s.ItemId,
                    p => p.Id,
                    (p,c)=>new {p,c})
                    .Where(p => p.c.Id == itemId);
                    var result = await test.ToListAsync();

            return Catagory.Select(p => new CatagoryVM
            {
                Id = p.catId,
                Name = p.Name,
                SubCatagory = new SubCatagoryVM
                {
                    Id = p.SubCatagory.Id,
                    Name = p.SubCatagory.Name,
                }
            }).ToList(); // var catagory = await _posDbContext.Catagory.Include(i =>i.SubCatagory).ThenInclude(p=>p.item)
                         // .Where(i =>i.SubCatagory.ItemId == itemId)
                         // .ToListAsync();
                         // var catagoryVMs = new List<CatagoryVM>();
                         // foreach (var i in catagory)
                         // {
                         //     catagoryVMs.Add(new CatagoryVM
                         //     {

            //         Id = i.catId,
            //         Name = i.Name,
            //         SubCatagory = new SubCatagoryVM 
            //         {
            //               =i.SubCatagory.Id,
            //              Name = i.SubCatagory.Name
            //         }
            //     }).ToList();
        
        // return catagoryVMs;
    }
    [HttpPost]
    [Route("AddCatagory")]
    public async Task<bool> AddCatagory(CatagoryVM model)
    {
        var catagory = new Catagory();
        catagory.catId = model.Id;
        catagory.Name = model.Name;
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
            catagory.catId = model.Id;
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
