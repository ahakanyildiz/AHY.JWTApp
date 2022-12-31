namespace AHY.JWPApp.Api.Core.Domain
{
    public class AppRole : IEntity
    {
        public int Id { get; set; }
        public string Definition { get; set; } = string.Empty; // Nullable or give string.Empty !
        public List<AppUser>? AppUsers { get; set; }
    }
}
