using System.ComponentModel.DataAnnotations;

namespace ProductAPIMock.Models
{
	public class Category
	{
        public int Id { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
}
