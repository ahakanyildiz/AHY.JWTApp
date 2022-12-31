using Microsoft.AspNetCore.Mvc.Rendering;

namespace AHY.JWTApp.Mvc.Models
{
    public class ProductCreateModel
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public SelectList? Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
