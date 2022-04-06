using AprioriSite.Core.Constants;
using AprioriSite.Core.Models;
using AprioriSite.Infrasructure.Data;
using AprioriSite.Infrasructure.Data.Identity;
using AprioriSite.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AprioriSite.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicatioDbRepository repo;

        public UserService(IApplicatioDbRepository _repo)
        {
            repo = _repo;
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
