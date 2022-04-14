using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Core.Models
{
    public class EmailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
