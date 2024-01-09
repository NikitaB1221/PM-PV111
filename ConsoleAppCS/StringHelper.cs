﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class StringHelper
    {
        public String Ellipsis(String input, bool isDotsCounts, int maxLength = 80)
        {
            if (isDotsCounts)
            {
                if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
                {
                    return input;
                }

                return input.Substring(0, maxLength - 3) + "...";
            }
            return $"{input[..maxLength]}...";
        }
        static string UrlCombine(params string[] parts)
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
    }
}