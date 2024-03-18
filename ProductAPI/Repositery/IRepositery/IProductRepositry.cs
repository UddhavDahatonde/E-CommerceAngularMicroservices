using ProductAPI.Modals;
using System.Linq.Expressions;

namespace ProductAPI.Repositery.IRepositery
{
	public interface IProductRepositry
	{
		Task<List<Product>> GetAll();
		Task<Product> GetById(Guid Id);
		Task<List<Product>>GetByCondition(Expression<Func<Product, bool>> Predicate);
		Task<Product>Add(Product product);	
		Task<Product>Update(Product product);
		Task<Product> Delete(Guid Id);
	}
}
