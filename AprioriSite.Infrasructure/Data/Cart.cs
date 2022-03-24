using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprioriSite.Infrasructure.Data
{
	public class Cart
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		public IList<Item> Items { get; set; } = new List<Item>();

		//public Dictionary<Item, int> ?ItemsQuantity { get; set; }

		[Required]
		public Guid UserId { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
