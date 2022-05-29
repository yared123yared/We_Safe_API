
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;
using System;
namespace WeSafe.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Evidence> Evidences { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FilePath> Paths { get; set; }
        public  DbSet<Criminal> Criminals { get; set; }
    }
}