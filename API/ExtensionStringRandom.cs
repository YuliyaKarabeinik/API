using System;
using System.Linq;

namespace API
{
    public static class ExtensionStringRandom
    {
        public static string GetRandomString(this string message, int length)
        {
            string chars = "wrtpsdfghjklxcvbznm";
            Random random = new Random();

	        return string.Concat(message,new string(Enumerable.Repeat(chars, length)
		        .Select(s => s[random.Next(s.Length)]).ToArray()));

        }
    }
}
