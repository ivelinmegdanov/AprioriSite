using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Infrasructure.Data
{
	public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public IList<Item> Items { get; set; } = new List<Item>();
    }
}
