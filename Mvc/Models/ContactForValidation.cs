using System.ComponentModel.DataAnnotations;


namespace Mvc.Models
{
    public class ContactForValidation
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
