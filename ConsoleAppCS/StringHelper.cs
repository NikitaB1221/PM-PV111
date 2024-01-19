using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class StringHelper
    {
        public String Ellipsis(String input, bool isDotsCounts = true, int maxLength = 80)
        {
            if (String.IsNullOrEmpty(input)) throw new ArgumentNullException("input must be not null or empty");

            if (input.Length <= maxLength) return input;

            if (isDotsCounts)
            {

                return input.Substring(0, maxLength - 3) + "...";
            }
            return $"{input[0..maxLength]}...";
        }
        public String UrlCombine(params string[] parts)
        {
            if (parts == null || parts.Length == 0)
            {
                throw new ArgumentException("Empty path parts");
            }

            try
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = parts[i]?.Trim('/');
                }

                string combinedPath = Path.Combine(parts);
                combinedPath = combinedPath.Replace('\\', '/');

                return $"/{combinedPath}";
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Path mapping error: {ex.Message}");
            }
        }

        public string Spacefy(double number)
        {
            if (number % 1 == 0 || number < 0 && (number * -1) % 1 == 0)
            {
                return ((long)number).ToString("N0").Replace("\u00A0", " ");
            }
            else
            {
                return number.ToString("N10", System.Globalization.CultureInfo.InvariantCulture).Replace("\u00A0", " ").Replace(",", " ").TrimEnd('0');
            }
        }
    }
}
