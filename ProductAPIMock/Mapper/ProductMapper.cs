using ProductAPIMock.Models;

namespace ProductAPIMock.Mapper
{
	public static class ProductMapper
	{
		public static List<Product> ToProduct(this productDto[] productDto)
		{
			if(productDto == null) throw new ArgumentNullException(nameof(productDto));
			var products = new List<Product>();
			foreach(var productDtoItem in productDto)
			{
				 products.Add(new Product()
				{
					Category = productDtoItem.Category,
					Description = productDtoItem.Description,
					Price = productDtoItem.Price,
					Title = productDtoItem.Title,
					Images = productDtoItem.Images.Select(x=>new Images { Url = x }).ToList(),
				});
			}
			return products;
		}
	}
}
