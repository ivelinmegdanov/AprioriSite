using AprioriSite.Core.Constants;
using AprioriSite.Core.Models;
using AprioriSite.Infrasructure.Data;
using AprioriSite.Infrasructure.Data.Identity;
using AprioriSite.Infrastructure.Data;
using AprioriSite.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AprioriSite.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicatioDbRepository repo;

        private readonly ApplicationDbContext context;

        public UserService(IApplicatioDbRepository _repo, ApplicationDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        public void AddItem(AddItemViewModel model)
        {
            repo.AddAsync(new Item()
            {
                Label = model.Label,
                Price = model.Price,
                Description = model.Description,
                Categoty = model.Category,
                Subcategory = model.Subcategory,
                ImageUrl = model.PictureUrl
            });

            repo.SaveChanges();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<IdentityUser>(id);

            if (user != null)
            {
                return new UserEditViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email
                };
            }

            return new UserEditViewModel()
            {
                Id = id,
                Username = "Invalid User",
                Email = "Invalid User"
            };
        }

        public async Task<IEnumerable<UserOrdersViewModel>> GetUserOrders(string id)
        {
            try
            {
                var model = context.Transactions.Select(u => new UserOrdersViewModel()
                {
                    Id = u.Id,
                    Size = u.Size,
                    OrderDate = u.OrderDate,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    CustomImage = u.CustomImage,
                    Confirmed = u.Confirmed,
                    Shipped = u.Shipped,
                    Arrived = u.Arrived,
                    Paid = u.Paid,
                    Country = u.Country,
                    Province = u.Province,
                    City = u.City,
                    Zip = u.Zip,
                    Address = u.Address,
                    UserId = u.UserId,
                    Quantity = u.Quantity,
                    ItemId = u.ItemId,
                    Price = u.Price
                }).Where(x => x.UserId == Guid.Parse(id)).ToListAsync();

                return await model;
            }
            catch (Exception)
            {
                var model = context.Transactions.Select(u => new UserOrdersViewModel()
                {
                    Id = new Guid(),
                    Size = "Error",
                    OrderDate = "Error",
                    FirstName = "Error",
                    LastName = "Error",
                    CustomImage = "Error",
                    Confirmed = false,
                    Shipped = false,
                    Arrived = false,
                    Paid = false,
                    Country = "Error",
                    Province = "Error",
                    City = "Error",
                    Zip = 0000,
                    Address = "Error",
                    Quantity = 0,
                    Price = 0
                }).Where(x => x.UserId == Guid.Parse(id)).ToListAsync();

                return await model;
            }

        }

        public async Task<IEnumerable<UserOrdersViewModel>> GetAllUserOrders()
        {
            try
            {
                var model = context.Transactions.Select(u => new UserOrdersViewModel()
                {
                    Size = u.Size,
                    OrderDate = u.OrderDate,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    CustomImage = u.CustomImage,
                    Confirmed = u.Confirmed,
                    Shipped = u.Shipped,
                    Arrived = u.Arrived,
                    Paid = u.Paid,
                    Country = u.Country,
                    Province = u.Province,
                    City = u.City,
                    Zip = u.Zip,
                    Address = u.Address,
                    UserId = u.UserId,
                    Quantity = u.Quantity,
                    ItemId = u.ItemId,
                    Price = u.Price
                }).ToListAsync();

                return await model;
            }
            catch (Exception)
            {
                var model = context.Transactions.Select(u => new UserOrdersViewModel()
                {
                    Size = "Error",
                    OrderDate = "Error",
                    FirstName = "Error",
                    LastName = "Error",
                    CustomImage = "Error",
                    Confirmed = false,
                    Shipped = false,
                    Arrived = false,
                    Paid = false,
                    Country = "Error",
                    Province = "Error",
                    City = "Error",
                    Zip = 0000,
                    Address = "Error",
                    Quantity = 0,
                    Price = 0
                }).ToListAsync();

                return await model;
            }

        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<IdentityUser>().Select(u => new UserListViewModel()
            {
                Email = u.Email,
                Id = u.Id,
                Name = $"{u.UserName}"
            }).ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<IdentityUser>(model.Id);

            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Username;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
