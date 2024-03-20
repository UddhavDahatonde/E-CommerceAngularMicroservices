using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProductAPIMock.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string? Title { get; set; }
		public int? Price { get; set; }
		public string? Description { get; set; }
		public int? CategoryId {  get; set; }
		public Category? Category { get; set; }
		public ICollection<Images>? Images { get; set; }
	}
}
