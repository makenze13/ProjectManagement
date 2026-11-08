namespace ProjectManagement.Models.DTOs
{
    public class UserGetDto
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public int? IdEmployee { get; set; }
    }
}
