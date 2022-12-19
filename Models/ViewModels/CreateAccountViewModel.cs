using System.ComponentModel.DataAnnotations;

namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string? LastName { get; set; }
        [MinLength(1)]
        [Display(Name = "NickName")]
        public string? NickName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        public string? PasswordConfirm { get; set; }
        [Required]
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }
    }
}
