using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprioriSite.Infrasructure.Data
{
	public class Transaction
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
		[NotMapped]
		public Dictionary<Item, int> ?Cart { get; set; }

		[Required]
		public bool Confirmed { get; set; } = false;

		[Required]
		public bool Shipped { get; set; } = false;

		[Required]
		public bool Arrived { get; set; } = false;

		[Required]
		public bool Paid { get; set; } = false;

		public string? Promocode { get; set; }

		[Required(ErrorMessage = "Country name should not exceed 90 characters!")]
		[StringLength(90)]
		public string Country { get; set; }

		[Required(ErrorMessage = "Province name should not exceed 90 characters!")]
		[StringLength(90)]
		public string Province { get; set; }

		[Required(ErrorMessage = "City name should not exceed 189 characters!")]
		[StringLength(189)]
		public string City { get; set; }

		[Required(ErrorMessage = "Zip code must be a positive number!")]
		[Range(0, int.MaxValue)]
		public int Zip { get; set; }

		[Required(ErrorMessage = "Address name should not exceed 200 characters!")]
		[StringLength(200)]
		public string Address { get; set; }

		public IList<Item> Items { get; set; } = new List<Item>();

		[Required]
		public Guid UserId { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
