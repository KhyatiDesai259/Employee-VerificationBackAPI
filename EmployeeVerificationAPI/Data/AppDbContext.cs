using EmployeeVerificationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVerificationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> tblEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("tblEmployees"); // Explicit table mapping
        }
    }
}

