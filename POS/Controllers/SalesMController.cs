using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Entity;
using POS.Models;

namespace POS.Controllers
{
    [Route("api/[controller]")]
    public class SalesMController : Controller
    {
        private readonly POSDbContext _posDbContext;
        public SalesMController(POSDbContext pOSDbContext)
        {
            _posDbContext = pOSDbContext;
        }
        [HttpGet]
        [Route("GetSales")]
        public async Task<List<SalesMVM>> GetSales()
        {
            var sales = await _posDbContext.Sales.ToListAsync();
            List<SalesMVM> salesMVMs = new List<SalesMVM>();
            foreach (var i in sales)
            {
                salesMVMs.Add(new SalesMVM
                {

                    SalesNumber = i.SalesNumber,
                    SalesDate = i.SalesDate,
                    SubTotal = i.SubTotal,
                    Total = i.Total,
                    CustomerName = i.CustomerName,
                    Tax = i.Tax,
                    Status = i.Status
                });
            }
            return salesMVMs;
        }
        [HttpPost]
        [Route("AddSales")]
        public async Task<bool> AddSales(SalesMVM model)
        {
            var sales = new SalesM();
            sales.SalesNumber = model.SalesNumber;
            sales.SalesDate = model.SalesDate;
            sales.SubTotal = model.SubTotal;
            sales.Total = model.Total;
            sales.CustomerName = model.CustomerName;
            sales.Tax = model.Tax;
            sales.Status = model.Status;
            _posDbContext.Add(sales);
            await _posDbContext.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        [Route("EditSales")]
        public async Task<bool> EditSales(SalesMVM model)
        {
            var sales = await _posDbContext.Sales.FindAsync(model.SalesNumber);
            if (sales != null)
            {
            sales.SalesNumber = model.SalesNumber;
            sales.SalesDate = model.SalesDate;
            sales.SubTotal = model.SubTotal;
            sales.Total = model.Total;
            sales.CustomerName = model.CustomerName;
            sales.Tax = model.Tax;
            sales.Status = model.Status;
                await _posDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpDelete]
        [Route("DeleteSales")]
        public async Task<bool> DeleteSales(int SalesNumber)
        {
            var sales = await _posDbContext.Sales.FindAsync(SalesNumber);
            _posDbContext.Sales.Remove(sales);
            return true;
        }
    }
}