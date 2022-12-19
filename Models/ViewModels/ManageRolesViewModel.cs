using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class ManageRolesViewModel
    {

        public IdentityRole Role { get; set; }

        public IList<AppUser> UserWithRole { get; set; }
        public IList<AppUser> UserNoRole { get; set; }
    }
}
