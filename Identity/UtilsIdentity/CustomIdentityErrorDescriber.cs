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
    }
}