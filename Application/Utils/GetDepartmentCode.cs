namespace Application.Utils
{
    public static class GetDepartmentCode
    {
        private static readonly Dictionary<string, string> departmentCodeMap = new Dictionary<string, string>
        {
            { "منابع انسانی", "HR" },
            { "شبکه", "IT" },
            { "حسابداری", "FIN" },
            { "فروش و بازاریابی", "CRM" },
            { "حفاظت", "SEC" },
            { "نرم افزار", "DEV" },
            { "تولید و بسته بندی", "PAP" },
            { "صادرات و واردات", "EAI" },
        };

        public static string GetDepartmentCodeByName(string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName))
                return "SA"; // مقدار پیش‌فرض برای نام‌های نامعتبر

            return departmentCodeMap.TryGetValue(departmentName.Trim(), out var code) ? code : "SA";
        }
    }
}
