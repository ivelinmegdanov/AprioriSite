namespace AprioriSite.Core.Models.ListViewModels
{
    public class ProductsListViewModel
    {
        public Guid Id { get; set; }

        public string Label { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public int Upvotes { get; set; }
    }
}
