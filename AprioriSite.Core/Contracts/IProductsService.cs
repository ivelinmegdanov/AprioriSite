using AprioriSite.Core.Models.ListViewModels;

namespace AprioriSite.Core.Contracts
{
    public interface IProductsService
    {
        IEnumerable<ProductsListViewModel> GetAllProducts();

        //ClothesDetailsViewModel? GetClothesById(int id);
    }
}
