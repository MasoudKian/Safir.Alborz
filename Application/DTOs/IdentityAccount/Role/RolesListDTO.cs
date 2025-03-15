namespace Application.DTOs.IdentityAccount.Role
{
    public class RolesListDTO
    {
        public string RoleId { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } // تاریخ ثبت رول
        public DateTime UpdateDate { get; set; } // تاریخ ویرایش رول
        public int UserCount { get; set; } // تعداد کاربران مرتبط با این رول
        public List<string> UserNames { get; set; } = new(); // لیست نام کاربران
    }
}
