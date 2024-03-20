using System.ComponentModel.DataAnnotations;

namespace ProductAPIMock.Models
{
	public class Images
	{
		[Key]
		public int ImageId { get; set; }
		public string Url { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
