using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Core.Models
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}
