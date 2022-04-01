using AprioriSite.Core.Contracts;
using AprioriSite.Core.Models;
using AprioriSite.Core.Models.ListViewModels;
using AprioriSite.Infrasructure.Data;
using AprioriSite.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprioriSite.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IApplicatioDbRepository repo;

        public ProductsService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public IEnumerable<ProductsListViewModel> GetAllProducts()
        {
            return repo.All<Item>()
                .Select(p => new ProductsListViewModel()
                {
                    Id = p.Id,
                    Label = p.Label,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Categoty
                });
        }

		public ItemsDetailsViewModel? GetItemsById(Guid id)
		{
            return repo.All<Item>()
                .Where(c => c.Id == id)
                .Select(c => new ItemsDetailsViewModel()
                {

                    Id = id,
                    ImageUrl = c.ImageUrl,
                    Label = c.Label,
                    Description = c.Description,
                    Price = c.Price,
                    Category= c.Categoty,
                    Subcategory = c.Categoty
                })
                .FirstOrDefault();
        }
    }
}