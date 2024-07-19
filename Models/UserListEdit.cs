namespace DigitalDataStructure.Models
{
    public class UserListEdit
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string UserProfile { get; set; } = null!;

        public string UserAddress { get; set; } = null!;

        public string UserRole { get; set; } = null!;

        public bool UserStatus { get; set; }

        public string EncId { get; set; } = string.Empty;
    }
}
