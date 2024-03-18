using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Modals
{
	public class Product
	{
		[Key]
        public Guid Id { get; set; }
		[Required]
		public string? Name { get; set; }
		public string?Discription { get; set; }
		[Required]
		public decimal? Price { get; set; }
		public string?ImageUrl { get; set; }
		public string? ImageLocaleUrl { get; set; }
		public int? Quentity { get; set; }
		[Required]
		public int? CategoryId { get; set; }
		public bool? Active { get; set; } = true;
		public decimal? Discount { get; set; }
		public DateTime? CreatedDate { get; set; } =DateTime.Now;
    }
}
