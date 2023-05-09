namespace Blog.Shared
{
    public static class StringHelper
    {
        public static string GenerateSlug(string title)
        {
            title = title.ToLower().Replace(" ", "-");

            return title;
        }
    }
}
