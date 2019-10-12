using System.ComponentModel.DataAnnotations;

namespace Kabunga.ViewModels
{
    public class UpdateUserModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
