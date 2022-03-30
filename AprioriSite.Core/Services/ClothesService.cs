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
    public class ClothesService : IClothesService
    {
        private readonly IApplicatioDbRepository repo;

        public ClothesService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
        }

        public IEnumerable<ClothesListViewModel> GetAllClothes()
        {
            return repo.All<Item>()
                .Select(i => new ClothesListViewModel()
                {
                    Id = i.Id,
                    Label = i.Label,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price
                });
        }
    }
}
