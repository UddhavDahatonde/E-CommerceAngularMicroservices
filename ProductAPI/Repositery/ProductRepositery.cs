using Microsoft.EntityFrameworkCore;
using ProductAPI.DataContext;
using ProductAPI.Modals;
using ProductAPI.Repositery.IRepositery;
using System.Linq.Expressions;

namespace ProductAPI.Repositery
{
	public class ProductRepositery : IProductRepositry
	{
		private readonly AppDbContext _db;

		public ProductRepositery(AppDbContext db)
		{
			_db = db;
		}
		public async Task<Product> Add(Product product)
		{
			await _db.Products.AddAsync(product);
			await _db.SaveChangesAsync();
			return product;
		}

		public async Task<Product> Delete(Guid Id)
		{
			var result = await GetById(Id);
			_db.Products.Remove(result);
			await _db.SaveChangesAsync();
			return result;
		}

		public async Task<List<Product>> GetAll()
		{
			return await _db.Products.ToListAsync();
		}

		public async Task<List<Product>> GetByCondition(Expression<Func<Product, bool>> Predicate)
		{
			return await _db.Products.Where(Predicate).ToListAsync();
		}

		public async Task<Product> GetById(Guid Id)
		{
			return await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);
		}

		public async Task<Product> Update(Product product)
		{
			_db.Products.Update(product);
			await _db.SaveChangesAsync();
			return product;
		}
	}
}
