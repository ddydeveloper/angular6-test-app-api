namespace MedicalApi.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperFirst(this string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var a = value.ToCharArray();
            a[0] = char.ToUpper(a[0]);

            return new string(a);
        }
    }
}
