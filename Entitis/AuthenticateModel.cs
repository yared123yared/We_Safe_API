using System.ComponentModel.DataAnnotations;

namespace WeSafe.Entity
{
    public class AuthenticateModel
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}