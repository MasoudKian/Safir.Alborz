namespace Application.DTOs.IdentityAccount.User
{
    public class UserListDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

        public int AccessFailedCount { get; set; } // تعداد تلاش‌های ناموفق
        public bool IsLockedOut { get; set; } // آیا کاربر قفل شده است؟
    }
}
