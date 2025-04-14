using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.DataAccess.Models.IdentiyModel
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
    }
}
