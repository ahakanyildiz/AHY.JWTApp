namespace AHY.JWPApp.Api.Core.Domain
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole? AppRole { get; set; }
    }
}
