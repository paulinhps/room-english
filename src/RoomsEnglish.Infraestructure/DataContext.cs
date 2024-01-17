using Microsoft.EntityFrameworkCore;

namespace RoomsEnglish.Infraestructure
{
    public class DataContext : DbContext
    {
       // public DbSet<User> User { get; private set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserMap());

        }
    }
}