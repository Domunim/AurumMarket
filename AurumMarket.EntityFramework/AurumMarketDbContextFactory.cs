using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AurumMarket.EntityFramework
{
    public class AurumMarketDbContextFactory : IDesignTimeDbContextFactory<AurumMarketDbContext>
    {
        public AurumMarketDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AurumMarketDbContext>();
            
            options.UseSqlServer("Server=DESKTOP-PUGRN1O\\SQLEXPRESS;Database=AurumDB;Trusted_Connection=True;TrustServerCertificate=True");
            
            return new AurumMarketDbContext(options.Options);
        }
    }
}
