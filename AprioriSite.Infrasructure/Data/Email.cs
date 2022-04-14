using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprioriSite.Infrasructure.Data
{
    public class Email
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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
