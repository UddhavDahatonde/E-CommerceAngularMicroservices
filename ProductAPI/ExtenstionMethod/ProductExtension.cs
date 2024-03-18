using ProductAPI.Modals;
using ProductAPI.Modals.Dto;

namespace ProductAPI.ExtenstionMethod
{
	public static class ProductExtension
	{
		public static Product ToProductUpdateDto(this ProductUpdateDto? productUpdateDto)
		{
			if (productUpdateDto == null) 
				throw new ArgumentNullException(nameof(productUpdateDto));
			return new Product
			{
				Id = productUpdateDto.Id,
				Active = productUpdateDto.Active,
				CategoryId = productUpdateDto.CategoryId,
				CreatedDate = productUpdateDto.Createddate,
				Discount = productUpdateDto.Discount,
				Discription = productUpdateDto.Discription,
				ImageLocaleUrl = productUpdateDto.ImageLocaleUrl,
				ImageUrl = productUpdateDto.ImageUrl,
				Name = productUpdateDto.Name,
				Price = productUpdateDto.Price,
				Quentity = productUpdateDto.Quentity,
			};
		}

		public static Product ProductAddDtoToProduct(this ProductAddDto? product)
		{
			if(product == null) throw new ArgumentNullException(nameof(product));
			return new Product()
			{
				Active = product.Active,
				CategoryId = product.CategoryId,
				Discount = product.Discount,
				Discription = product.Discription,
				ImageLocaleUrl = product.ImageLocaleUrl,
				ImageUrl = product.ImageUrl,
				Name = product.Name,
				Price = product.Price,
				Quentity = product.Quentity,

			};
		}

		public static ProductDto ProductToProductDto(this Product? product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));
			decimal? result = product.Discount / 100;
			decimal? listPrice = 0;
			if (result.HasValue)
			{
				listPrice=product.Price-result.Value;
			}
			return new ProductDto()
			{
				Active = product.Active,
				CategoryId = product.CategoryId,
				Discount = product.Discount,
				Discription = product.Discription,
				ImageLocaleUrl = product.ImageLocaleUrl,
				ImageUrl = product.ImageUrl,
				Name = product.Name,
				Price = product.Price,
				Quentity = product.Quentity,
				Id = product.Id,
				Createddate = product.CreatedDate,
				AfterDiscount = product.Price - listPrice
			};
		}

		public static List<ProductDto> ListProductToListProductDto(this List<Product>? product)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));
			List<ProductDto>Result = new List<ProductDto>();
			decimal? result = 0;
			decimal? listPrice = 0;

			foreach (var item in product)
			{
				result = item.Discount / 100;
				listPrice = item.Price - result;
				Result.Add(new ProductDto()
				{
					Active = item.Active,
					CategoryId = item.CategoryId,
					Discount = item.Discount,
					Discription = item.Discription,
					ImageLocaleUrl = item.ImageLocaleUrl,
					ImageUrl = item.ImageUrl,
					Name = item.Name,
					Price = item.Price,
					Quentity = item.Quentity,
					Id = item.Id,
					Createddate = item.CreatedDate,
				    AfterDiscount= item.Price - listPrice
				});
			}
			return Result;	
		}
	}
}
