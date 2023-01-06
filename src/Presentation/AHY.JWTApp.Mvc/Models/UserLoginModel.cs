using System.ComponentModel.DataAnnotations;

namespace AHY.JWTApp.Mvc.Models
{
    //Single Responsibilitye aykırı fakat işlemi hızlandırabilmek adına data annotation kullandım.
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username alanı gereklidir.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password alanı gereklidir.")]
        public string Password { get; set; } = null!;
    }
}
