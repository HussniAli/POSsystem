using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS.Models;

namespace POS.Entity
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> option):base(option){
        }
        public DbSet<User> Users {get;set;}
        public DbSet<SalesM> Sales {get;set;}
        public DbSet<Catagory> Catagory {get;set;}
        public DbSet<SubCatagory> SubCatagory {get;set;}
        public DbSet<Item> Items {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("host=localhost ;port=5432; Database=POS System; username=postgres; password=MUNIA&12 ;IncludeErrorDetail=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        } 
    }
    
}