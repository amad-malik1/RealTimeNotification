using Microsoft.EntityFrameworkCore;
using UpWorkTask.Models;

namespace UpWorkTask.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
