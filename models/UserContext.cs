using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETradingAPI.models
{
    public class UserContext : DbContext
    {
        public UserContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
         public DbSet<BusinessOwner> BusinessOwners { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Share> Shares { get; set; }
    }

}
