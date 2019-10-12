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
    }
}
