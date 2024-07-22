using System.ComponentModel.DataAnnotations;

namespace DigitalDataStructure.Models
{
    public class UserListEdit
    {
        public int UserId { get; set; }

        [Display(Name ="Name")]
        [Required(ErrorMessage="Please, Enter your full name!")]
        public string UserName { get; set; } = null!;


        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        [Required(ErrorMessage = "Please, Enter your password!")]
        public string UserPassword { get; set; } = null!;

        [Display(Name ="Email Address")]    
        [Required(ErrorMessage = "Please, Enter your email address!")]
        public string EmailAddress { get; set; } = null!;

        [Display(Name ="Profile")]
        [Required(ErrorMessage = "Please, Enter your profile!")]
        public string UserProfile { get; set; } = null!;

        [Display(Name ="Address")]
        [Required(ErrorMessage = "Please, Enter your address!")]
        public string UserAddress { get; set; } = null!;

        [Display(Name ="Role")]
        [Required(ErrorMessage = "Please, Enter your role!")]
        public string UserRole { get; set; } = null!;


        public bool UserStatus { get; set; }

        public string EncId { get; set; } = string.Empty;


        [DataType(DataType.Upload)]
        [Display(Name ="Upload File")]
        [Required(ErrorMessage = "Please, Upload your file!")]
        public IFormFile? UserFile { get; set; }
    }
}
