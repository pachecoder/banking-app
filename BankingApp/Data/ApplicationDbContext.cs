using BankingApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasMany(a => a.Account)
                .WithOne(c => c.Customer)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Customer_Accounts");

            modelBuilder.Entity<Account>()
                .ToTable("Accounts")
                .HasOne(c => c.Customer)
                .WithMany(a => a.Account);
        }

    }
}