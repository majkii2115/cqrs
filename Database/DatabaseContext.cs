using cqrs.Domain;
using Microsoft.EntityFrameworkCore;

namespace cqrs.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}