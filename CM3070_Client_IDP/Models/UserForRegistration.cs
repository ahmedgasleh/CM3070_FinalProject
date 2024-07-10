using System.ComponentModel.DataAnnotations;

namespace CM3070_Client_IDP.Models
{
    public class UserForRegistration
    {
     
        [Required(ErrorMessage = "Email is required")]
        public string? Email{ get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "The password and confirmation password do not match")]
        public string? ConfirmPassword { get; set; }
    }

    public class RegistrationResponse
    {
       public bool IsSuccessfulRegistraion { get; set; }
        
       public IEnumerable<string>? Errors { get; set; }
    }
}
