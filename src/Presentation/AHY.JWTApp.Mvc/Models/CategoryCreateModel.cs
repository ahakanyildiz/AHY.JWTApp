using System.ComponentModel.DataAnnotations;

namespace AHY.JWTApp.Mvc.Models
{
    public class CategoryCreateModel
    {
        [Required(ErrorMessage = "Bu alan gereklidir.")]
        public string? Definition { get; set; }
    }
}
