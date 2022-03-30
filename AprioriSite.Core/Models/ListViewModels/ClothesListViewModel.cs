using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprioriSite.Core.Models.ListViewModels
{
    public class ClothesListViewModel
    {
        public Guid Id { get; set; }

        public string Label { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }
    }
}
