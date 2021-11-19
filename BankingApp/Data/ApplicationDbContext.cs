using BankingApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Customer>(s =>
            {
                s.ToTable("Customers");

                s.HasMany(a => a.Account)
                .WithOne(c => c.Customer)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Customer_Accounts");

                s.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });



            modelBuilder.Entity<Transaction>(s =>
            {

                s.ToTable("Transactions");

                s.HasOne(c => c.Account)
                .WithMany(t => t.Transaction)
                .IsRequired()
                .HasForeignKey(s => s.AccountId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Transaction_Accounts");

                s.HasOne(c => c.Customer)
                .WithMany(t => t.Transaction)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s => s.CustomerId)
                .HasConstraintName("FK_Transaction_Customers");

                s.Property(p => p.Created).HasDefaultValueSql("getdate()");

            });



            modelBuilder.Entity<Account>(s =>
            { 
                s.ToTable("Accounts")
                .HasOne(c => c.Customer)
                .WithMany(a => a.Account);

                s.Property(p => p.Created).HasDefaultValueSql("getdate()");
            });
                
        }

    }
}