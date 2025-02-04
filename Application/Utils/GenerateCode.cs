namespace Application.Utils
{
    public static class GenerateCode
    {
        public static string GenerateEmployeeCode()
        {
            Random random = new();
            // تولید عددی بین 0 و 99999
            int randomNumber = random.Next(0, 100000);
            // تبدیل عدد به رشته و اضافه کردن صفرهای جلو در صورت نیاز
            string randomString = randomNumber.ToString("D5"); // 5 رقم
            return "m_" + randomString; // افزودن 'm' در ابتدای رشته
        }
    }
}
