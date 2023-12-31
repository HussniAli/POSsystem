using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using POS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using POS.Entity;

namespace POS.Entity
{
    public class POSDbContext : IdentityDbContext<UserOne>
    {
        public POSDbContext(DbContextOptions<POSDbContext> options):base(options)
        {
           
        }
        public DbSet<User> Users {get;set;}
        public DbSet<SalesM> Sales {get;set;}
        public DbSet<Catagory> Catagory {get;set;}
        public DbSet<SubCatagory> SubCatagory {get;set;}
        public DbSet<Item> Items {get;set;}
        public DbSet<UserOne>UsersOne {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // builder.UseNpgsql("host=localhost ;port=5432; Database=POS System; username=postgres; password=MUNIA&12 ;IncludeErrorDetail=true;");
            builder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        } 
    }
    
}