using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductAPIMock.DataContext;
using ProductAPIMock.Mapper;
using ProductAPIMock.Models;
using ProductAPIMock.Service.IService;
using System;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace ProductAPIMock.Service
{
	public class ProductService:IProductService
	{
		private readonly AppDbContext _appDb;
		private IHttpClientFactory _httpClientFactory;

		public ProductService(IHttpClientFactory httpClientFactory, AppDbContext appDb)
		{
			_httpClientFactory = httpClientFactory;
			_appDb = appDb;
		}
		public async Task<productDto[]> GetAllMock()
		{
			HttpClient _httpClient=_httpClientFactory.CreateClient("Mock");
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
			httpRequestMessage.Method = HttpMethod.Get;
			httpRequestMessage.RequestUri = new Uri("https://api.escuelajs.co/api/v1/products");
			httpRequestMessage.Headers.Add("Accept", "application/json");
		    HttpResponseMessage _apiResponse =await _httpClient.SendAsync(httpRequestMessage);
			var result= await _apiResponse.Content.ReadAsStringAsync();
			var apiResponseDto = JsonConvert.DeserializeObject<productDto[]>(result);
			  return apiResponseDto;
		}

		public async Task AddMock(productDto[] product)
		{
			_appDb.Products.AddRange(ProductMapper.ToProduct(product));
			await _appDb.SaveChangesAsync();
		}

		public async Task Add(Product product)
		{
			_appDb.Add(product);
		await _appDb.SaveChangesAsync();
		}

		public async Task Update(Product product)
		{
			_appDb.Update(product);
			await _appDb.SaveChangesAsync();
		}

		public Task Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _appDb.Products.ToListAsync();
		}

		public async Task<Product> GetById(int id)
		{
			return await _appDb.Products.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Product>> GetByCondition(Expression<Func<Product, bool>> predicate)
		{
			return await _appDb.Products.Where(predicate).ToListAsync();
		}
	}
}
