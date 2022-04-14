using AprioriSite.Core.Models;
using AprioriSite.Infrasructure.Data.Identity;

namespace AprioriSite.Core.Constants
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<UserEditViewModel> GetUserForEdit(string id);

        Task<bool> UpdateUser(UserEditViewModel model);

        Task<bool> DeleteEmail(EmailViewModel model);

        Task<bool> ConfirmOrder(UserOrdersViewModel model);

        Task<IEnumerable<UserOrdersViewModel>> GetUserOrders(string id);

        Task<IEnumerable<EmailViewModel>> GetAllEmails();

        Task<IEnumerable<UserOrdersViewModel>> GetAllUserOrders();

        Task<ApplicationUser> GetUserById(string id);

        void AddItem(AddItemViewModel model);

        Task<bool> DeleteUser(UserEditViewModel model);
    }
}
