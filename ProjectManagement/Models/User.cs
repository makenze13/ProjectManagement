namespace ProjectManagement.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Login { get; set;  }
        public string Password { get; set; }
        public string Role { get; set;  }
        public int? IdEmployee { get; set; }

        public virtual Employee? IdEmployeeNavigation { get; set; }
    }
}
