using AprioriSite.Core.Constants;
using AprioriSite.Core.Models;
using AprioriSite.Infrasructure.Data.Identity;
using AprioriSite.Infrastructure.Data.Repositories;
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

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            return new UserEditViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>().Select(u => new UserListViewModel()
            {
                Email = u.Email,
                Id = u.Id,
                Name = $"{u.FirstName} {u.LastName}"
            }).ToListAsync();
        }
    }
}
