using AprioriSite.Core.Contracts;
using AprioriSite.Core.Models;
using AprioriSite.Infrasructure.Data;
using AprioriSite.Infrasructure.Data.Identity;
using AprioriSite.Infrastructure.Data;
using AprioriSite.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AprioriSite.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IApplicatioDbRepository repo;

        private readonly ApplicationDbContext context;

        public EmailService(IApplicatioDbRepository _repo, ApplicationDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        public void AddEmail(EmailViewModel model)
        {
            repo.AddAsync(new Email()
            {
                Name = model.Name,
                UserEmail = model.UserEmail,
                PhoneNumber = model.PhoneNumber,
                Subject = model.Subject,
                Message = model.Message,
                UserId = model.UserId
            });

            repo.SaveChanges();
        }
    }
}
