using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
		public async Task GetAll()
		{
			 var result =await _productService.GetAll();
		     // await _productService.Add(result);
		}
	}
}
