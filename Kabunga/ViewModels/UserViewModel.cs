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
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }  
        public string Username { get; set; }
        public string Email { get; set; }
       
    }
}
