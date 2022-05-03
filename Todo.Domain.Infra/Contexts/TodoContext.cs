using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasColumnType("varchar(120)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}