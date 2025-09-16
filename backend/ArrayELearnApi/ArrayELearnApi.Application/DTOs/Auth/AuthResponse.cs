namespace ArrayELearnApi.Application.DTOs.Auth
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
        public bool IsSuccessed { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
