using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/[controller]")]
    public class SalesMController : Controller
    {
        private readonly POSDbContext _POSDbContext;
        public SalesMController(POSDbContext pOSDbContext)
        {
            _POSDbContext = pOSDbContext;
        }
        [HttpGet]
        [Route("GetSales")]
        public async Task<List<SalesMVM>> GetSales()
        {
            var sales = await _POSDbContext.Sales.ToListAsync();
            List<SalesMVM> salesMVMs = new List<SalesMVM>();
            foreach (var i in sales)
            {
                salesMVMs.Add(new SalesMVM
                {

                    OrderType = i.OrderType,
                    OrderNumber = i.OrderNumber,
                    SubTotal = i.SubTotal,
                    Total = i.Total,
                });
            }
            return salesMVMs;
        }
        [HttpPost]
        [Route("AddSales")]
        public async Task<bool> AddSales(SalesMVM model)
        {
            var sales = new SalesM();
            sales.OrderType = model.OrderType;
            sales.OrderNumber = model.OrderNumber;
            sales.SubTotal = model.SubTotal;
            sales.Total = model.Total;
            _POSDbContext.Add(sales);
            await _POSDbContext.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        [Route("EditSales")]
        public async Task<bool> EditSales(SalesMVM model)
        {
            var sales = await _POSDbContext.Sales.FindAsync(model.OrderNumber);
            if (sales != null)
            {
                sales.OrderType = model.OrderType;
                sales.OrderNumber = model.OrderNumber;
                sales.SubTotal = model.SubTotal;
                sales.Total = model.Total;
                await _POSDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpDelete]
        [Route("DeleteSales")]
        public async Task<bool> DeleteSales(int OrderNumber)
        {
            var sales = await _POSDbContext.Users.FindAsync(OrderNumber);
            _POSDbContext.Users.Remove(sales);
            return true;
        }
    }
}