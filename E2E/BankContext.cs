using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BankApp;Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.AccountNo).HasName("Pk_Accounts");

                entity.Property(a => a.AccountNo).ValueGeneratedOnAdd();


                entity.Property(a => a.EmailAddress).IsRequired().HasMaxLength(100);
                entity.Property(a => a.AccountName).HasMaxLength(100);
                entity.Property(a => a.Accounttype).IsRequired();
                entity.ToTable("Account"); ;
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(a => a.ID).HasName("Pk_Transaction");

                entity.Property(a => a.ID).ValueGeneratedOnAdd();

                entity.Property(a => a.Amount).IsRequired();
                entity.HasOne(a => a.Account).WithMany().HasForeignKey(a => a.AccountNumber);

            });


        }
    }
}
