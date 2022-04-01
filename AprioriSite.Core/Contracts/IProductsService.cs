using AprioriSite.Core.Models;
using AprioriSite.Core.Models.ListViewModels;

namespace AprioriSite.Core.Contracts
{
    public interface IProductsService
    {
        IEnumerable<ProductsListViewModel> GetAllProducts();

        ItemsDetailsViewModel? GetItemsById(Guid id);
    }
}
