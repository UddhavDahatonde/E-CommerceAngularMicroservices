using ProductAPI.Modals;
using ProductAPI.Modals.Dto;
using System.Linq.Expressions;

namespace ProductAPI.Service.IService
{
	public interface IProductService
	{
		Task<List<ProductDto>> GetAll();
		Task<ProductDto> GetById(Guid Id);
		Task<List<ProductDto>> GetByCondition(Expression<Func<Product, bool>> Predicate);
		Task<ProductDto> Add(ProductAddDto product);
		Task<ProductDto> Update(ProductUpdateDto product);
		Task<ProductDto> Delete(Guid Id);
	}
}
