using System;


namespace Mvc.Utilities
{
    public static class StringExtensions
    {
        public static string OmitControllerWord(this string original)
            => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
    }
}
