using AprioriSite.Core.Contracts;
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
            return repo.All<Item>().Where(x => x.Categoty == "Clothes")
                .Select(p => new ProductsListViewModel()
                {
                    Id = p.Id,
                    Label = p.Label,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Categoty
                });
        }
    }
}
