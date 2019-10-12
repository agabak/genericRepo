using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kabunga.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        [StringLength(maximumLength:100, MinimumLength = 3)]
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
        [Required]
        [Compare("Email")]
        public string EmailConfirm { get; set; }
    }
}
