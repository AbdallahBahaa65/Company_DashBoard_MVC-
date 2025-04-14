using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModel
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email Is Requerd !!!!!")]
        public string Email { get; set; } = null!;
    }
}
