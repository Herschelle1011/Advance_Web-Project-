using Advance_web_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Advance_web_Project.Data

{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options)
                : base(options)
            {

            }

            // Example table
            public DbSet<User> Users { get; set; }
        
    }
}
