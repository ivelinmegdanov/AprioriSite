using AprioriSite.Infrasructure.Data.Identity;
using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Infrasructure.Data
{
    public class DeletedUsers
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
		public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public ICollection<Item> Favorited { get; set; } = new List<Item>();
	}
}
