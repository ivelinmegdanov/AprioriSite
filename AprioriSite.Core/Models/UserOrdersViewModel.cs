using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Core.Models
{
    public class UserOrdersViewModel
    {
		[Required]
		public string CustomImage { get; set; }


		[Required(ErrorMessage = "First name cannot be empty!")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name cannot be empty!")]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
        public bool Confirmed { get; set; }

		[Required]
		public bool Shipped { get; set; }

		[Required]
		public bool Arrived { get; set; }

		[Required]
		public bool Paid { get; set; }

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

		[Required]
		public Guid ItemId { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public Guid UserId { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
