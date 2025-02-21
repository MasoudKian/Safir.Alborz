namespace Application.Utils
{
    public static class CodeGeneratorMarketer
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

        public static string GenerateMarketerCode(string provinceName, string cityName, string regionName)
        {
            // استخراج حروف اول
            string provinceInitial = GetFirstLetter(provinceName);
            string cityInitial = GetFirstLetter(cityName);
            string regionInitial = GetFirstLetter(regionName);

            // تبدیل حروف به مقادیر عددی
            int provinceCode = ConvertLettersToNumber(provinceInitial);
            int cityCode = ConvertLettersToNumber(cityInitial);
            int regionCode = ConvertLettersToNumber(regionInitial);

            // تولید کد نهایی
            return $"{provinceCode}{cityCode}{regionCode}-marketer";
        }

        private static string GetFirstLetter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "X";

            char firstChar = name[0];
            return PersianToEnglishMap.ContainsKey(firstChar) ? PersianToEnglishMap[firstChar] : firstChar.ToString().ToUpper();
        }

        private static int ConvertLettersToNumber(string letter)
        {
            if (string.IsNullOrEmpty(letter))
                return 0;

            return letter[0] - 'A' + 1; // تبدیل A=1, B=2, ..., Z=26
        }

    }
}
