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
                    Category = p.Categoty,
                    AllowSize = p.AllowSize,
                    Description = p.Description,
                    Subcategory = p.Subcategory
                });
        }

        public IEnumerable<ProductsListViewModel> GetAllDeletedProducts()
        {
            return repo.All<DeletedItem>()
                .Select(p => new ProductsListViewModel()
                {
                    Id = p.Id,
                    Label = p.Label,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Categoty,
                    AllowSize = p.AllowSize,
                    Description = p.Description,
                    Subcategory = p.Subcategory
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
                    AllowSize = c.AllowSize,
                    Label = c.Label,
                    Description = c.Description,
                    Price = c.Price,
                    Category = c.Categoty,
                    Subcategory = c.Categoty
                })
                .FirstOrDefault();
        }

        public OrderAndItemViewModel? GetItemsAndOrdersById(Guid id)
        {
            return repo.All<Item>()
                .Where(c => c.Id == id)
                .Select(c => new OrderAndItemViewModel()
                {
                    ItemsDetailsViewModel = new ItemsDetailsViewModel()
                    {
                        Id = id,
                        ImageUrl = c.ImageUrl,
                        AllowSize = c.AllowSize,
                        Label = c.Label,
                        Description = c.Description,
                        Price = c.Price,
                        Category = c.Categoty,
                        Subcategory = c.Categoty
                    }
                })
                .FirstOrDefault();
        }

        public async Task<bool> OrderItem(OrderAndItemViewModel model)
        {
            bool result = false;

            await repo.AddAsync(new Transaction()
            {
                OrderDate = model.OrderItemViewModel.OrderDate,
                Size = model.OrderItemViewModel.Size,
                CustomImage = model.OrderItemViewModel.CustomImage,
                FirstName = model.OrderItemViewModel.FirstName,
                LastName = model.OrderItemViewModel.LastName,
                Country = model.OrderItemViewModel.Country,
                Province = model.OrderItemViewModel.Province,
                City = model.OrderItemViewModel.City,
                Zip = model.OrderItemViewModel.Zip,
                Address = model.OrderItemViewModel.Address,
                ItemId = model.OrderItemViewModel.ItemId,
                Quantity = model.OrderItemViewModel.Quantity,
                UserId = model.OrderItemViewModel.UserId,
                Price = model.OrderItemViewModel.Price
            });

            result = true;

            await repo.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteItem(ProductsListViewModel model)
        {
            bool result = false;
            var item = await repo.GetByIdAsync<Item>(model.Id);

            if (item != null)
            {
                await repo.AddAsync(new DeletedItem()
                {
                    AllowSize = item.AllowSize,
                    Label = item.Label,
                    Price = item.Price,
                    Description = item.Description,
                    Categoty = item.Categoty,
                    Subcategory = item.Subcategory,
                    ImageUrl = item.ImageUrl
                });

                repo.Delete(item);

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<bool> UndoDeleteItem(ProductsListViewModel model)
        {
            bool result = false;
            var item = await repo.GetByIdAsync<DeletedItem>(model.Id);

            if (item != null)
            {
                await repo.AddAsync(new Item()
                {
                    AllowSize = item.AllowSize,
                    Label = item.Label,
                    Price = item.Price,
                    Description = item.Description,
                    Categoty = item.Categoty,
                    Subcategory = item.Subcategory,
                    ImageUrl = item.ImageUrl
                });

                repo.Delete(item);

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}