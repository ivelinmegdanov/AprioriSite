using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Core.Models
{
    public class ItemsDetailsViewModel
    {
		public Guid Id { get; set; }

		public bool AllowSize { get; set; }

		public string ImageUrl { get; set; }

		public string Label { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public string Category { get; set; }

		public string Subcategory { get; set; }

        public int Upvotes { get; set; }
    }
}
