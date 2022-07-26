using System.ComponentModel.DataAnnotations;


namespace Mvc.Models
{
    public class AdvancedContact
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool? AllowContactSpecialOffers { get; set; }

        [Display(Name = "Favorite Color?")]
        public string FavoriteColor { get; set; }
    }
}
