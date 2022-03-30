﻿using System.ComponentModel.DataAnnotations;
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
        [StringLength(100, ErrorMessage = "The name of the item is required and must be below 100 characters!")]
        public string Label { get; set; }

        [Required(ErrorMessage = "ImageUrl is required!")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The color of the item is required and must be below 20 characters!")]
        public string Color { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The size of the item is required and must be below 10 characters!")]
        public string Size { get; set; }

        public string? CustomPicture { get; set; }

        [Required]
        [Column(TypeName ="money")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The category of the item is required and must be below 20 characters!")]
        public string Categoty { get; set; }


        public string? Subcategory { get; set; }
    }
}
