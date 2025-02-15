namespace Application.DTOs.IdentityAccount.Role
{
    public class RolesResponseDTO
    {
        public int TotalCount { get; set; } // تعداد کل رول‌ها
        public List<RolesListDTO> Roles { get; set; } = new(); // لیست رول‌ها
    }
}
