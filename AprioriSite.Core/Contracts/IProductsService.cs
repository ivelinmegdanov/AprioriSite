using AprioriSite.Core.Models;
using AprioriSite.Core.Models.ListViewModels;

namespace AprioriSite.Core.Contracts
{
    public interface IProductsService
    {
        IEnumerable<ProductsListViewModel> GetAllProducts();

        ItemsDetailsViewModel? GetItemsById(Guid id);

        OrderAndItemViewModel? GetItemsAndOrdersById(Guid id);

        Task<bool> OrderItem(OrderAndItemViewModel model);

        Task<bool> DeleteItem(ProductsListViewModel model);
    }
}
