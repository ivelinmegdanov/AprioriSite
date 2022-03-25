using AprioriSite.Infrastructure.Data;
using AprioriSite.Infrastructure.Data.Common;

namespace AprioriSite.Infrastructure.Data.Repositories
{
    public class ApplicatioDbRepository : Repository, IApplicatioDbRepository
    {
        public ApplicatioDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}