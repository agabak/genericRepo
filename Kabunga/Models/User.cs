using Kabunga.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kabunga.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static implicit operator User(UserViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
