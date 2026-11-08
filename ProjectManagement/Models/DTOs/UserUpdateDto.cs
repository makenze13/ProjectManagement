namespace ProjectManagement.Models.DTOs
{
    public class UserUpdateDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string? NewPassword { get; set; }
        public string Role { get; set; }
        public int? IdEmployee { get; set; }
    }
}
