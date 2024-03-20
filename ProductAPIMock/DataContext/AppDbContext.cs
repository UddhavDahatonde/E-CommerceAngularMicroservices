using Microsoft.EntityFrameworkCore;
using ProductAPIMock.Models;
using System.Reflection.Metadata;

namespace ProductAPIMock.DataContext
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Images>Images { get; set; }

	}
}
