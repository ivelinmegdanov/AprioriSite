using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Core.Models
{
    public class AddItemViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Label { get; set; }

        [Required]
        public bool AllowSize { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        [Required]
        public string Category { get; set; }

        public string? Subcategory { get; set; }

        [Required]
        [StringLength(10)]
        public string Size { get; set; }

        public string? CustomPicture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
