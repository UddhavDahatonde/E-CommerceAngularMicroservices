namespace ProductAPI.Modals.Dto
{
	public class ProductUpdateDto
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Discription { get; set; }
		public decimal? Price { get; set; }
		public string? ImageUrl { get; set; }
		public string? ImageLocaleUrl { get; set; }
		public int? Quentity { get; set; }
		public int? CategoryId { get; set; }
		public bool? Active { get; set; } = true;
		public decimal? Discount { get; set; }
		public DateTime? Createddate { get; set; }
	}
}
