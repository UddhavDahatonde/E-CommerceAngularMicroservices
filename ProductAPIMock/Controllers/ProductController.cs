using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPIMock.Models;
using ProductAPIMock.Service.IService;

namespace ProductAPIMock.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		[Route("GetAll")]
		public async Task<IEnumerable<Product>> GetAll()
		{
			 return await _productService.GetAll();
		}
		[HttpGet]
		[Route("Id:int")]
		public async Task<Product> GetById(int Id)
		{
			return await _productService.GetById(Id);
		}
		[HttpGet]
		[Route("GetByName")]
		public async Task<IEnumerable<Product>> GetByName(string Name)
		{
			return await _productService.GetByCondition(x=>x.Title.Contains(Name));
		}
		[HttpPost]
		public async Task Add(Product product)
		{
			 await _productService.Add(product);
		}
		[HttpPut]
		public async Task Update(Product product)
		{
			 await _productService.Update(product);
		}
		[HttpDelete("Id:int")]
		public async Task Delete(int Id)
		{
			await _productService.Delete(Id);
		}
	}
}
