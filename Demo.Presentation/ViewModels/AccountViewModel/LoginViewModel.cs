using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels.AccountViewModel
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        
        
        [DataType(DataType.Password)]

        public string Password { get; set; }=null!;

        public bool RememberMe { get; set; }

    }
}
