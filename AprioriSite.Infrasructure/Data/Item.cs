using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprioriSite.Infrasructure.Data
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        //[Required]
        //[Range(0, int.MaxValue)]
        //public int UpVote { get; set; } = 0;

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        [Required]
		public string PictureUrl { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        [Required]
        [StringLength(10)]
        public string Size { get; set; }

        [Required]
        public string CustomPicture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public Guid CaregoryId { get; set; }

        [ForeignKey(nameof(CaregoryId))]
        public Category Category { get; set; }
    }
}
