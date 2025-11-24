using Microsoft.EntityFrameworkCore;
using ShopyAPP.Models;
using System.Collections.Generic;

namespace ShopyAPP.Context
{
    public class ShopyAPPContext : DbContext
    {
      
        public ShopyAPPContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set; }

    }
}
