using FillmyHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FillmyHub.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Viewer { get; set; }
    }
}
