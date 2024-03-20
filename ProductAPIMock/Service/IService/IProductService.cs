using ProductAPIMock.Models;
using System.Linq.Expressions;

namespace ProductAPIMock.Service.IService
{
	public interface IProductService
	{
		Task<productDto[]> GetAllMock();
		public Task AddMock(productDto[] product);
		public Task Add(Product product);
		public Task Update(Product product);
		public Task Delete(int Id);
		public Task<IEnumerable<Product>> GetAll();
		public Task<Product> GetById(int id);
		public Task<IEnumerable<Product>>GetByCondition(Expression<Func<Product, bool>> predicate);
	}
}
