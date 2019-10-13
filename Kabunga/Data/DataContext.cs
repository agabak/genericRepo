using Kabunga.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kabunga.Data
{
    public class DataContext: IdentityUserContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasData(new Order
            {
               Id = 1,
               OrderDate = DateTime.UtcNow,
               OrderNumber = "1234"
            });
            base.OnModelCreating(builder);
        }
    }
}
