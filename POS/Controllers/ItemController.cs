using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/[controller]")] 
    public class ItemController : Controller
    {
        private readonly POSDbContext _posDbContext;
        public ItemController(POSDbContext pOSDbContext)
        {
            _posDbContext = pOSDbContext;
        }
        [HttpGet]
        [Route("GetItem")]
        public async Task<List<ItemVm>> GetCatagory()
        {
            var item = await _posDbContext.Items.ToListAsync();
            List<ItemVm> ItemVms = new List<ItemVm>();
            foreach (var i in item)
            {
                ItemVms.Add(new ItemVm
                {

                    Id = i.Id,
                    Name = i.Name,
                });
            }
            return ItemVms;
        }
        [HttpPost]
        [Route("AddItem")]
        public async Task<bool> AddItem(ItemVm model)
        {
            var items = new Item();
            items.Id = model.Id;
            items.Name = model.Name;
            _posDbContext.Add(items);
            await _posDbContext.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        [Route("EditItem")]
        public async Task<bool> EditItem(ItemVm model)
        {
            var items = await _posDbContext.Items.FindAsync(model.Id);
            if (items != null)
            {
                items.Id = model.Id;
                items.Name = model.Name;

                await _posDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<bool> DeleteItem(int Id)
        {
            var item = await _posDbContext.Items.FindAsync(Id);
            _posDbContext.Items.Remove(item);
            return true;
        }
    }
}