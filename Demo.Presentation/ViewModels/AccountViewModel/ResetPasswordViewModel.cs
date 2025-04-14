using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModel
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }    
    }
}
