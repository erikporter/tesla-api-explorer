using System.ComponentModel.DataAnnotations;

namespace TeslaApiExplorer.Models
{
    public class LoginInfo
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
