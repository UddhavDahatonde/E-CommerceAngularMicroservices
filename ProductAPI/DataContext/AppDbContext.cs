using Microsoft.EntityFrameworkCore;
using ProductAPI.Modals;

namespace ProductAPI.DataContext
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {             
        }
        public DbSet<Product> Products { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>(x =>
			{
				x.Property(e=>e.ImageUrl).HasMaxLength(500);
				x.Property(e=>e.Name).HasMaxLength(100);
				x.Property(e=>e.Name).IsRequired();
				x.Property(e=>e.CategoryId).IsRequired();
				x.Property(e=>e.Discount).HasPrecision(precision:5,scale:2);
				x.Property(e => e.Quentity).HasMaxLength(1000);
				x.Property(e=>e.Discount).HasPrecision(precision:5,scale:2);
				x.Property(e=>e.Discription).HasMaxLength(2000);
				x.Property(e=>e.ImageLocaleUrl).HasMaxLength(200);
				x.Property(e=>e.Price).IsRequired();
				x.Property(e=>e.Price).HasPrecision(precision:8,scale:2);
				x.HasKey(e=>e.Id);
			});
		}
	}
}
