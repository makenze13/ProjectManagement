namespace ProjectManagement.Models.DTOs
{
    public class UserAddDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? IdEmployee { get; set; }
    }
}
