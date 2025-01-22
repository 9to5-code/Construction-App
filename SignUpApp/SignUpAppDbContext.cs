using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignUpApp.Model;
namespace SignUpApp
{
    public class SignUpAppDbContext:DbContext
    {

   public SignUpAppDbContext(DbContextOptions<SignUpAppDbContext> options) : base(options) { }

    // DbSet for each model
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configurations (optional)
    }
        
    }
}