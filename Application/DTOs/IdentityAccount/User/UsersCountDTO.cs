namespace Application.DTOs.IdentityAccount.User
{
    public class UsersCountDTO
    {

        //تعداد کل کاربران 
        public int TotalUsers { get; set; }

        //تعداد کاربران فعال
        public int ActiveUsers { get; set; }

        //تعداد کاربران جدبد
        public int NewUsers { get; set; }

        //تعداد کاربران حذف شده
        public int InactiveUsers { get; set; }
    }
}
