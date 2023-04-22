using AurumMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.EntityFramework
{
    public class AurumMarketDbContext : DbContext
    {      
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public AurumMarketDbContext(DbContextOptions options) : base(options) { }
    }
}
