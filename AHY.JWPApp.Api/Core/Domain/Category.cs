namespace AHY.JWPApp.Api.Core.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<Product>? Products { get; set; }
    }
}
