using Microsoft.EntityFrameworkCore;
using RazorPages.Model.Domain;

namespace RazorPages.Data
{
    public class DbContextRazor : DbContext
    {
        public DbContextRazor(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> EMPLOYEE { get; set; }
    }
}
