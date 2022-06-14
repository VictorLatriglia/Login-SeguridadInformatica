using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class UserSavedInformation
    {
        [Key]
        public int UserId { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
