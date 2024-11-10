using Lab01Ak.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriumASPNET.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { 
        get; 
        set;
    }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source = {DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    PhoneNumber = "123123123",
                    BirthDate = new DateTime(1980, 1, 1),
                    Email = "ewa@wsei.edu.pl",
                    Created = DateTime.Now,
                    Category = Category.Friend
                }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Ola",
                    LastName = "Matysiak",
                    PhoneNumber = "123123123",
                    BirthDate = new DateTime(1990, 1, 1),
                    Email = "Ola@wsei.edu.pl",
                    Created = new DateTime(2000, 12, 1),
                    Category = Category.Friend
                }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 3,
                    FirstName = "Katarzyna",
                    LastName = "Majewska",
                    PhoneNumber = "333555222",
                    BirthDate = new DateTime(1999, 1, 1),
                    Email = "Katarzyna@wsei.edu.pl",
                    Created = new DateTime(2000, 12, 1),
                    Category = Category.Friend
                }
            );
    }
}