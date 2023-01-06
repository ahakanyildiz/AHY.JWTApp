namespace src.Core.Onion.JwtApp.Domain.Entities
{
    public class AppRole
    {
        public int Id { get; set; }
        public string Definition { get; set; } = string.Empty; // Nullable or give string.Empty !
        public List<AppUser>? AppUsers { get; set; }
    }
}
