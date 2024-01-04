using Microsoft.EntityFrameworkCore;

namespace DogsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Dogs> Dogs { get; set; }
    }
}
