using Microsoft.AspNetCore.Identity;

namespace Identity.UtilsIdentity
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = "یه خطا رخ داده!"
            };
        }

        // متدهای دیگه که هنوز توی نسخه 9.0.1 هستن رو می‌تونی اضافه کنی
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $"رمز عبور باید حداقل {length} کاراکتر باشد."
            };
        }
    }
}