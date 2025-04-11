using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Furst Name Must Be with Value ")]
        [MaxLength(50)]

        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage ="Furst Name Must Be with Value ")]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword{ get; set; }
        [Required(ErrorMessage = " User Name  Must Be with Value ")]
        [MaxLength(50)]
        public string UserName{ get; set; }
        public bool IsAgree{ get; set; }


    }
}
