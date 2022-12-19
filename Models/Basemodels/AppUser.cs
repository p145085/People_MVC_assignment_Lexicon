using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace People_MVC_assignment_Lexicon.Models.Basemodels
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NickName { get; set; }
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? PasswordConfirm { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
