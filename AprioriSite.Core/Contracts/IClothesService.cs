using AprioriSite.Core.Models.ListViewModels;

namespace AprioriSite.Core.Contracts
{
    public interface IClothesService
    {
        IEnumerable<ClothesListViewModel> GetAllClothes();
        //ClothesDetailsViewModel? GetClothesById(int id);
    }
}
