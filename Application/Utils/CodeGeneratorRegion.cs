using System.Text;

namespace Application.Utils
{
    public static class CodeGeneratorRegion
    {
        private static readonly Dictionary<char, string> PersianToEnglishMap = new Dictionary<char, string>
        {
            { 'ا', "A" }, { 'ب', "B" }, { 'پ', "P" }, { 'ت', "T" }, { 'ث', "S" },
            { 'ج', "J" }, { 'چ', "CH" }, { 'ح', "H" }, { 'خ', "KH" }, { 'د', "D" },
            { 'ذ', "Z" }, { 'ر', "R" }, { 'ز', "Z" }, { 'ژ', "ZH" }, { 'س', "S" },
            { 'ش', "SH" }, { 'ص', "S" }, { 'ض', "Z" }, { 'ط', "T" }, { 'ظ', "Z" },
            { 'ع', "A" }, { 'غ', "GH" }, { 'ف', "F" }, { 'ق', "GH" }, { 'ک', "K" },
            { 'گ', "G" }, { 'ل', "L" }, { 'م', "M" }, { 'ن', "N" }, { 'و', "V" },
            { 'ه', "H" }, { 'ی', "Y" }
        };

        public static string GenerateRegionCode(string regionName)
        {
            if (string.IsNullOrWhiteSpace(regionName))
                return "REG000"; // مقدار پیش‌فرض برای نام‌های نامعتبر

            // گرفتن ۳ حرف اول نام منطقه
            string persianPrefix = new string(regionName.Take(3).ToArray());

            // تبدیل به انگلیسی
            StringBuilder englishPrefix = new StringBuilder();
            foreach (char c in persianPrefix)
            {
                if (PersianToEnglishMap.ContainsKey(c))
                    englishPrefix.Append(PersianToEnglishMap[c]);
            }

            if (englishPrefix.Length == 0)
                englishPrefix.Append("REG"); // مقدار پیش‌فرض در صورت عدم توانایی در تبدیل

            // تولید ۳ عدد تصادفی
            Random random = new();
            string randomNumbers = random.Next(100, 999).ToString();

            return englishPrefix.ToString() + randomNumbers;
        }
    }
}
