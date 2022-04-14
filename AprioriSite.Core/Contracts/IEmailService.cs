using AprioriSite.Core.Models;
using AprioriSite.Core.Models.ListViewModels;

namespace AprioriSite.Core.Contracts
{
    public interface IEmailService
    {
        void AddEmail(EmailViewModel model);
    }
}
