using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Modals.Dto;
using ProductAPI.Modals;
using ProductAPI.Service.IService;

namespace ProductAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
        private readonly IProductService _productService;
		private ResponseDto _response;
		public ProductController(IProductService productService)
		{
			_productService = productService;
			_response = new ResponseDto();
		}
		[HttpPost]
		[Consumes("multipart/form-data")]
		public ResponseDto Post([FromForm] ProductAddDto? ProductDto)
		{
			if(ProductDto == null)
			{
				_response.IsSuccess = false;
				_response.Message = "Object Is Null Or Empty";
				return _response;
			}
			try
			{
				_productService.Add(ProductDto);
				if (ProductDto.Image != null)
				{

					string fileName = Guid.NewGuid()+ Path.GetExtension(ProductDto.Image.FileName);
					string filePath = @"wwwroot\ProductImages\" + fileName;

					//I have added the if condition to remove the any image with same name if that exist in the folder by any change
					var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
					FileInfo file = new FileInfo(directoryLocation);
					if (file.Exists)
					{
						file.Delete();
					}

					var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
					using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
					{
						ProductDto.Image.CopyTo(fileStream);
					}
					var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
					ProductDto.ImageUrl = baseUrl + "/ProductImages/" + fileName;
					ProductDto.ImageLocaleUrl = filePath;
				}
				else
				{
					ProductDto.ImageUrl = "https://placehold.co/600x400";
				}
				//_db.Products.Update(product);
				//_db.SaveChanges();
				//_response.Result = _mapper.Map<ProductDto>(product);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
