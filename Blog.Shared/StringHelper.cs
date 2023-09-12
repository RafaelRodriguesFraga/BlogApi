using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Blog.Shared
{
    public static class StringHelper
    {
        public static string GenerateSlug(string title)
        {
            title = RemoveDiacritics(title);
            title = title.Trim();
            title = Regex.Replace(title, "[^a-zA-Z0-9- ]", "");
            title = title.Replace(" ", "-");
            title = Regex.Replace(title, "-{2,}", "-");
            title = title.ToLower();

            return title;
        }

        public static string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
