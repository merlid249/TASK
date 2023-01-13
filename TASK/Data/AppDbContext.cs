using Microsoft.EntityFrameworkCore;
using TASK.Models;

namespace TASK.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) :base(options)
        {

        }
        
        public DbSet<Taskk> Tasks { get; set; }
    }
}
