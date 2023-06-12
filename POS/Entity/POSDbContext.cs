using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace POS.Entity
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> option):base(option){
        }
        public DbSet<User> Users {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("host=localhost ;port=5432; Database=Employee Manager; username=postgres; password=MUNIA&12 ;IncludeErrorDetail=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        } 
    }
    
}