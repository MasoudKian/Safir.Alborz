namespace Application.Utils
{
    public static class GenerateCode
    {
        public static string GenerateCodeUser()
        {
            Random random = new();
            // تولید عددی بین 10000 و 99999
            string randomNumber = random.Next(10000, 100000).ToString();
            return randomNumber;
        }

        public static string GenerateEmployeeCode()
        {
            Random random = new();
            // تولید عددی بین 0 و 99999
            int randomNumber = random.Next(0, 100000);
            // تبدیل عدد به رشته و اضافه کردن صفرهای جلو در صورت نیاز
            string randomString = randomNumber.ToString("D5"); // 5 رقم
            return randomString; 
        }
    }
}
