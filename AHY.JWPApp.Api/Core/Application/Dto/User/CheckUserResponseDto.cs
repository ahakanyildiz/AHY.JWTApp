namespace AHY.JWTApp.Api.Core.Application.Dto.User
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}
