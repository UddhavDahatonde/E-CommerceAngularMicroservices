using ProductAPIMock.Models;
namespace ProductAPIMock.Models
{
	public class productDto
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public int Price { get; set; }
		public string? Description { get; set; }
		public Category? Category { get; set; }
		public List<string>? Images { get; set; }
	}
}
