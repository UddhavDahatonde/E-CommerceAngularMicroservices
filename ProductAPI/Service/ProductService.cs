using ProductAPI.ExtenstionMethod;
using ProductAPI.Modals;
using ProductAPI.Modals.Dto;
using ProductAPI.Repositery.IRepositery;
using ProductAPI.Service.IService;
using System.Linq.Expressions;

namespace ProductAPI.Service
{
	public class ProductService : IProductService
	{
		private readonly IProductRepositry _productRepositery;

		public ProductService(IProductRepositry productRepositery)
		{
			_productRepositery = productRepositery;
		}

		public async Task<ProductDto> Add(ProductAddDto product)
		{
			return ProductExtension.ProductToProductDto(await _productRepositery.Add(ProductExtension.ProductAddDtoToProduct(product)));
			
		}

		public async Task<ProductDto> Delete(Guid Id)
		{
			return ProductExtension.ProductToProductDto(await _productRepositery.Delete(Id));
		}

		public async Task<List<ProductDto>> GetAll()
		{
			return ProductExtension.ListProductToListProductDto(await _productRepositery.GetAll());
		}

		public async Task<List<ProductDto>> GetByCondition(Expression<Func<Product, bool>> Predicate)
		{
			return ProductExtension.ListProductToListProductDto(await _productRepositery.GetByCondition(Predicate));
		}

		public async Task<ProductDto> GetById(Guid Id)
		{
			return ProductExtension.ProductToProductDto(await _productRepositery.GetById(Id));
		}

		public async Task<ProductDto> Update(ProductUpdateDto product)
		{
			return ProductExtension.ProductToProductDto(await _productRepositery.Update(ProductExtension.ToProductUpdateDto(product)));
		}
	}
}
